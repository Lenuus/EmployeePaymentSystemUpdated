using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Domain
{
    [Table("Employee")]
    public class Employee: BaseEntity, ISoftDeletable
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
        /// Surname
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Surname { get; set; }

        /// <summary>
        /// Tckn
        /// </summary>
        [MaxLength(11)]
        public string Tckn { get; set; }

        /// <summary>
        /// Hiring Date
        /// </summary>
        public DateTime HiringDate { get; set; }

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
