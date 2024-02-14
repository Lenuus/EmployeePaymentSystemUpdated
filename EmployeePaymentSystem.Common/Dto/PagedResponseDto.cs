using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Common.Dto
{
    public class PagedResponseDto<T> where T : class
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

        /// <summary>
        /// TotalCount
        /// </summary>
        public int TotalCount { get; internal set; }
    }
}
