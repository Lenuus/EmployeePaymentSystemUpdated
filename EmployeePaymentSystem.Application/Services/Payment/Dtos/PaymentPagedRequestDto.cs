using EmployeePaymentSystem.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Payment.Dtos
{
    public class PaymentPagedRequestDto : PagedRequestDto
    {
        /// <summary>
        /// SeasonIds
        /// </summary>
        public List<Guid> SeasonIds { get; set; } = new List<Guid>();

        /// <summary>
        /// EmployeeIds
        /// </summary>
        public List<Guid> EmployeeIds { get; set; } = new List<Guid>();
    }
}
