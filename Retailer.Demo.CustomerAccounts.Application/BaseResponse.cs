using System.Collections.Generic;

namespace Retailer.Demo.CustomerAccounts.Application
{
    public class BaseResponse<T> where T : class
    {
        public T Result { get; private set; }
        public List<Error> Errors { get; private set; }

        public void AddResult(T result)
        {
            Result = result;
        }

        public void AddError(Error error)
        {
            Errors ??= new List<Error>();

            Errors.Add(error);
        }

        public void AddErrors(IEnumerable<Error> errors)
        {
            Errors ??= new List<Error>();

            Errors.AddRange(errors);
        }
    }

    public class Error
    {
        public string Message { get; set; }
        public string Code { get; set; }
    }
}
