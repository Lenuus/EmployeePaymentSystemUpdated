namespace EmployeePaymentSystem.Web.Models.Employee
{
    public class IndexResponseModel
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
    }
}
