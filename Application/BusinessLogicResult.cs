using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BusinessLogicResult : IBusinessLogicResult
    {
        public int Status { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
    }

    public class BusinessLogicResult<T> : BusinessLogicResult, IBusinessLogicResult<T>
    {

        public T Result { get; set; }
    }
}
