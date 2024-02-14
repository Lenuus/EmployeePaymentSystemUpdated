using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Application.Services.Season.Dtos
{
    public class CreateSeasonRequestDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
