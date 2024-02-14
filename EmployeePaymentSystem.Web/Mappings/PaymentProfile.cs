using AutoMapper;
using EmployeePaymentSystem.Application.Services.Payment.Dtos;
using EmployeePaymentSystem.Application.Services.Season.Dtos;
using EmployeePaymentSystem.Common.Dto;
using EmployeePaymentSystem.Web.Models;
using EmployeePaymentSystem.Web.Models.Payment;

namespace EmployeePaymentSystem.Web.Mappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentIndexRequestModel, PaymentPagedRequestDto>();
            CreateMap<PaymentListDto, PaymentListResponseModel>();
            CreateMap<PaymentCreateRequestModel, AddPaymentRequestDto>();
            CreateMap<PaymentUpdateRequestModel, UpdatePaymentRequestDto>();
            CreateMap<PagedResponseDto<PaymentListDto>, PagedResponseModel<PaymentListResponseModel>> ();
        }
    }
}
