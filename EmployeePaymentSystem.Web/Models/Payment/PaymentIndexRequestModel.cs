namespace EmployeePaymentSystem.Web.Models.Payment
{
    public class PaymentIndexRequestModel: PagedRequestModel
    {
        /// <summary>
        /// SeasonIds
        /// </summary>
        public List<Guid> SeasonIds { get; set; } = new List<Guid>();

        /// <summary>
        /// EmployeeIds
        /// </summary>
        public List<Guid> EmployeeIds { get; set; } = new List<Guid>();
    }
}
