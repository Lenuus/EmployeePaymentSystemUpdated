using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Employee.Dtos
{
    public class EmployeeListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Tckn
        /// </summary>
        public string Tckn { get; set; }

        /// <summary>
        /// Hiring Date
        /// </summary>
        public DateTime HiringDate { get; set; }

        /// <summary>
        /// FullName
        /// </summary>
        public string FullName { get; set; }
    }
}
