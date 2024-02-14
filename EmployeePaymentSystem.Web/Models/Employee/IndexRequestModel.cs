namespace EmployeePaymentSystem.Web.Models.Employee
{
    public class IndexRequestModel: PagedRequestModel
    {
        public string Search { get; set; } = string.Empty;
    }
}
