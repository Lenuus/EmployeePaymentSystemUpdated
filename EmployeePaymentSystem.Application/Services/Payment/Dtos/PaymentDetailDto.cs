using EmployeePaymentSystem.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Payment.Dtos
{
    public class PaymentDetailDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// EmployeeName
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// SeasonName
        /// </summary>
        public string SeasonName { get; set; }

        /// <summary>
        /// PaymentType - Prim, Maaş 
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Payment
        /// </summary>
        public decimal Payment { get; set; }

        /// <summary>
        /// Currency - TL - EUR
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// EmployeeId
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// SeasonId
        /// </summary>
        public Guid SeasonId { get; set; }
    }
}
