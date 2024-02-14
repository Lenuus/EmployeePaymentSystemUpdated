using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeePaymentSystem.Application
{
    public class ServiceResponse
    {
        public ServiceResponse(bool isSuccessful, string errorMessage)
        {
            IsSuccessful = isSuccessful;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public bool IsSuccessful { get; set; }
    }

    public class ServiceResponse<T> where T : class
    {
        public ServiceResponse(T data, bool isSuccessful, string errorMessage)
        {
            Data = data;
            IsSuccessful = isSuccessful;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; } = string.Empty;

        public bool IsSuccessful { get; set; }

        public T Data { get; set; }
    }
}
