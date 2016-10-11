using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond.Domain.DTO.Result
{
    public class Result<T>
    {
        public Result()
        {
            Success = true;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public Exception Exception { get; set; }

        public Result<T> SetFailure(string message)
        {
            Success = false;
            Message = message;

            return this;
        }

        public Result<T> SetError(Exception ex)
        {
            Success = false;
            Exception = ex;

            return this;
        }

        public Result<T> SetData(T data)
        {
            Success = true;
            Data = data;

            return this;
        }
    }
}
