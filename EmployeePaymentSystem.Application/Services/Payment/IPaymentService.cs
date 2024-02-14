using EmployeePaymentSystem.Application.Services.Payment.Dtos;
using EmployeePaymentSystem.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Payment
{
    public interface IPaymentService
    {
        Task<ServiceResponse<PaymentDetailDto>> GetPaymentDetail(Guid id);

        Task<ServiceResponse<PagedResponseDto<PaymentListDto>>> GetAllPayments(PaymentPagedRequestDto request);

        Task<ServiceResponse<List<PaymentListDto>>> GetAllPaymentsOfEmployee(Guid employeeId);

        Task<ServiceResponse> AddPayment(AddPaymentRequestDto request);

        Task<ServiceResponse> UpdatePayment(UpdatePaymentRequestDto request);

        Task<ServiceResponse> DeletePayment(Guid id);

        Task<ServiceResponse> CopyPaymentToLastSeason(Guid id);
    }
}
