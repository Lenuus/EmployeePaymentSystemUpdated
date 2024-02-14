namespace EmployeePaymentSystem.Web.Models.Season
{
    public class IndexRequestModel: PagedRequestModel
    {
        public string Search { get; set; } = string.Empty;
    }
}
