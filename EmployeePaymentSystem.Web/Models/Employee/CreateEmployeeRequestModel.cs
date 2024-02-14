using System.ComponentModel.DataAnnotations;

namespace EmployeePaymentSystem.Web.Models.Employee
{
    public class CreateEmployeeRequestModel
    {
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
        public string Tckn { get; set; }

        /// <summary>
        /// Hiring Date
        /// </summary>
        public DateTime HiringDate { get; set; }
    }
}
