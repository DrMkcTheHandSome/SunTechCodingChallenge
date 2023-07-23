using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EventSenderFuncApp.Shared.ObjectResults
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;

        public InternalServerErrorObjectResult(object value)
            : base(value)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
