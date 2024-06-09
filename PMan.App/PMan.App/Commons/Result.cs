using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManager.App.Commons
{
    public class Result<T>
    {
        public Result(T value, string errorMessage, bool isSuccess)
        {
            Value = value;
            ErrorMessage = errorMessage;
            IsSuccess = isSuccess;
        }

        public T Value { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool IsSuccess { get; private set; }

        public static Result<T> Success(T value)
            => new Result<T>(value, "", true);

        public static Result<T> Fail(string errorMessage)
            => new Result<T>(default, errorMessage, false);

    }
}
