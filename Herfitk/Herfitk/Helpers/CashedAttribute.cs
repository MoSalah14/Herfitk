using Azure;
using Herfitk.Core.Service_Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace Herfitk.API.Helpers
{
    public class CashedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int TimeLiveInSecond;

        public CashedAttribute(int timeToLiveInSecond)
        {
            TimeLiveInSecond = timeToLiveInSecond;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ResponseCachService = context.HttpContext.RequestServices.GetRequiredService<IResponseCashService>();

            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

            var Response = await ResponseCachService.GetCashedResponseAsync(cacheKey);

            if (!string.IsNullOrEmpty(Response))
            {
                var result = new ContentResult()
                {
                    Content = Response,
                    ContentType = "application/json",
                    StatusCode = 200,
                };
                context.Result = result;
                return;
            }
            var executedActionContext = await next.Invoke();

            if (executedActionContext.Result is OkObjectResult okObjectResult && okObjectResult.Value is not null)
                await ResponseCachService.SetCashResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(TimeLiveInSecond));


        }
        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var KeyBuilder = new StringBuilder();
            KeyBuilder.Append(request.Path); // api/ControllerName/


            // Get QueryStringFromUrlTo Make it Uniqe and add it on the string
            foreach (var (key,value) in request.Query)
            {
                KeyBuilder.Append($"|{key}-{value}");
            }
            return KeyBuilder.ToString();

        }
    }
}
