using EmployeePaymentSystem.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Season.Dtos
{
    public class GetAllSeasonsRequestDto: PagedRequestDto
    {
        public string Search { get; set; }
    }
}
