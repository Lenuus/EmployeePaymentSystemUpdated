namespace EmployeePaymentSystem.Web.Models
{
    public class PagedResponseModel<T> where T : class
    {
        /// <summary>
        /// CurrentPage
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// TotalPage
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public List<T> Data { get; set; }
    }
}
