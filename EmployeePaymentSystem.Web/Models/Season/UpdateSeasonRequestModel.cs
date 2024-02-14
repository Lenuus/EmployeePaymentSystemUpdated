﻿using System.ComponentModel.DataAnnotations;

namespace EmployeePaymentSystem.Web.Models.Season
{
    public class UpdateSeasonRequestModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }
    }
}
