using EmployeePaymentSystem.Common.Enums;

namespace EmployeePaymentSystem.Web.Models.Payment
{
    public class PaymentUpdateRequestModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// EmployeeId
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// SeasonId
        /// </summary>
        public Guid SeasonId { get; set; }

        /// <summary>
        /// PaymentType
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// Payment
        /// </summary>
        public decimal Payment { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }
    }
}
