using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Domain
{
    [Table("Season")]
    public class Season : BaseEntity, ISoftDeletable
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Payments
        /// </summary>
        public ICollection<Payment> Payments { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }
    }
}
