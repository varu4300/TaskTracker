

using System.Net;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Api.Models.Responses;

namespace TaskTracker.Api.Utilities.Helpers
{
    public static class ApiBehaviourValidationExtensions
    {
        public static void Configure(ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {

              
                    var errorMessages = actionContext.ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    var response = new BaseApiResponse<object>
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = string.Join("; ", errorMessages),
                        Result = null
                    };

                    return new JsonResult(response)
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                
            };
        }

    }
    
}