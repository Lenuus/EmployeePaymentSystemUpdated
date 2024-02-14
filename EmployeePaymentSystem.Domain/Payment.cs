using EmployeePaymentSystem.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Domain
{
    [Table("Payment")]
    public class Payment : BaseEntity, ISoftDeletable
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// EmployeeId
        /// </summary>
        [Required]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Employee
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// SeasonId
        /// </summary>
        [Required]
        public Guid SeasonId { get; set; }

        /// <summary>
        /// Season
        /// </summary>
        public Season Season { get; set; }

        /// <summary>
        /// PaymentType
        /// </summary>
        [Required]
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// PaymentTotal
        /// </summary>
        [Required]
        public decimal PaymentTotal { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        [Required]
        public string Currency { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }
    }
}
