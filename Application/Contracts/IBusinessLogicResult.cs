using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IBusinessLogicResult
    {
        public int Status { get; set; }
        bool Success { get; set; }
        string Error { get; set; }
        public string Message { get; set; }
    }
    public interface IBusinessLogicResult<T> : IBusinessLogicResult
    {
        T Result { get; set; }
    }
}

   
