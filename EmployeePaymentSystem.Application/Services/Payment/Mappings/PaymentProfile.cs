using AutoMapper;
using EmployeePaymentSystem.Application.Services.Payment.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Payment.Mappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<AddPaymentRequestDto, Domain.Payment>()
                .ForMember(dest => dest.PaymentTotal, targ => targ.MapFrom(src => src.Payment));
        }
    }
}
