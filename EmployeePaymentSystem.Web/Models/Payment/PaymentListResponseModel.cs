using EmployeePaymentSystem.Common.Enums;

namespace EmployeePaymentSystem.Web.Models.Payment
{
    public class PaymentListResponseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// EmployeeName
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// SeasonName
        /// </summary>
        public string SeasonName { get; set; }

        /// <summary>
        /// PaymentType - Prim, Maaş 
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Payment
        /// </summary>
        public decimal Payment { get; set; }

        /// <summary>
        /// Currency - TL - EUR
        /// </summary>
        public string Currency { get; set; }
    }
}
