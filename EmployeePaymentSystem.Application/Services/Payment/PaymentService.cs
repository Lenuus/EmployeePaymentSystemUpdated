using AutoMapper;
using Azure.Core;
using EmployeePaymentSystem.Application.Services.Payment.Dtos;
using EmployeePaymentSystem.Application.Services.Season;
using EmployeePaymentSystem.Common.Dto;
using EmployeePaymentSystem.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Domain.Payment> _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Season> _seasonRepository;

        public PaymentService(
            IRepository<Domain.Payment> paymentRepository,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PaymentDetailDto>> GetPaymentDetail(Guid id)
        {
            var payment = await _paymentRepository.GetAll().Include(f => f.Employee).Include(f => f.Season).FirstOrDefaultAsync(f => f.Id == id && !f.IsDeleted).ConfigureAwait(false);
            if (payment == null)
            {
                return new ServiceResponse<PaymentDetailDto>(null, false, "Not found");
            }

            return new ServiceResponse<PaymentDetailDto>(
                new PaymentDetailDto
                {
                    Id = payment.Id,
                    EmployeeName = $"{payment.Employee.Name} {payment.Employee.Surname}",
                    SeasonName = payment.Season.Name,
                    Currency = payment.Currency,
                    Payment = payment.PaymentTotal,
                    PaymentType = payment.PaymentType,
                    EmployeeId = payment.EmployeeId,
                    SeasonId = payment.SeasonId,
                }, true, string.Empty);
        }

        public async Task<ServiceResponse<PagedResponseDto<PaymentListDto>>> GetAllPayments(PaymentPagedRequestDto request)
        {
            var response = await _paymentRepository.GetAll()
                .Include(f => f.Employee)
                .Include(f => f.Season)
                .Where(f => !f.IsDeleted &&
                            (request.EmployeeIds.Any() ? request.EmployeeIds.Contains(f.EmployeeId) : true) &&
                            (request.SeasonIds.Any() ? request.SeasonIds.Contains(f.SeasonId) : true))
                .Select(f => new PaymentListDto
                {
                    Id = f.Id,
                    Currency = f.Currency,
                    EmployeeName = f.Employee.Name + " " + f.Employee.Surname,
                    Payment = f.PaymentTotal,
                    PaymentType = f.PaymentType,
                    SeasonName = f.Season.Name,
                }).ToPagedListAsync(request.PageSize, request.PageIndex).ConfigureAwait(false);

            return new ServiceResponse<PagedResponseDto<PaymentListDto>>(response, true, string.Empty);
        }

        public async Task<ServiceResponse<List<PaymentListDto>>> GetAllPaymentsOfEmployee(Guid employeeId)
        {
            var response = await _paymentRepository.GetAll()
                .Include(f => f.Employee)
                .Include(f => f.Season)
                .Where(f => !f.IsDeleted && f.EmployeeId == employeeId)
                .Select(f => new PaymentListDto
                {
                    Id = f.Id,
                    Currency = f.Currency,
                    EmployeeName = f.Employee.Name + " " + f.Employee.Surname,
                    Payment = f.PaymentTotal,
                    PaymentType = f.PaymentType,
                    SeasonName = f.Season.Name,
                }).ToListAsync().ConfigureAwait(false);

            return new ServiceResponse<List<PaymentListDto>>(response, true, string.Empty);
        }

        public async Task<ServiceResponse> AddPayment(AddPaymentRequestDto request)
        {
            if (request == null)
            {
                return new ServiceResponse(false, "Boş yapma birader");
            }

            var lastPaymentsOfUser = await _paymentRepository.GetAll()
                .Where(f => f.EmployeeId == request.EmployeeId &&
                            f.SeasonId == request.SeasonId &&
                            f.PaymentType == request.PaymentType).AnyAsync().ConfigureAwait(false);
            if (lastPaymentsOfUser)
            {
                return new ServiceResponse(false, "Zaten kaydı var!");
            }

            var entity = _mapper.Map<Domain.Payment>(request);
            await _paymentRepository.Create(entity).ConfigureAwait(false);
            return new ServiceResponse(true, string.Empty);
        }

        public async Task<ServiceResponse> DeletePayment(Guid id)
        {
            try
            {
                await _paymentRepository.DeleteById(id).ConfigureAwait(false);
                return new ServiceResponse(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new ServiceResponse(false, ex.Message);
            }
        }

        public async Task<ServiceResponse> UpdatePayment(UpdatePaymentRequestDto request)
        {
            var payment = await _paymentRepository.GetById(request.Id).ConfigureAwait(false);
            if (payment == null)
            {
                return new ServiceResponse(false, "Not found");
            }

            payment.Currency = request.Currency;
            payment.EmployeeId = request.EmployeeId;
            payment.SeasonId = request.SeasonId;
            payment.PaymentTotal = request.Payment;
            payment.PaymentType = request.PaymentType;
            await _paymentRepository.Update(payment).ConfigureAwait(false);
            return new ServiceResponse(true, string.Empty);
        }

        public async Task<ServiceResponse> CopyPaymentToLastSeason(Guid id)
        {
            var payment = await _paymentRepository.GetById(id).ConfigureAwait(false);
            if (payment == null)
            {
                return new ServiceResponse(false, "Not found");
            }
            
            var lastSeasonId = await _seasonRepository.GetAll()
                .OrderByDescending(f => f.EndDate)
                .Where(f => !f.IsDeleted)
                .Select(f => f.Id)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            if (lastSeasonId == Guid.Empty)
            {
                return new ServiceResponse(false, "Season not found");
            }

            var entity = new Domain.Payment()
            {
                Currency = payment.Currency,
                EmployeeId = payment.EmployeeId,
                SeasonId = lastSeasonId,
                PaymentTotal = 0,
                PaymentType = payment.PaymentType
            };
            await _paymentRepository.Create(entity).ConfigureAwait(false);
            return new ServiceResponse(true, string.Empty);
        }
    }
}
