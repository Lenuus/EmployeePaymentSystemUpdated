namespace EmployeePaymentSystem.Web.Models.Season
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
        /// EndDate
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }
    }
}
