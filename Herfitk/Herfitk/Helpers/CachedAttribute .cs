using Azure;
using Herfitk.Core.Service_Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace Herfitk.API.Helpers
{
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int TimeLiveInSecond;

        public CachedAttribute(int timeToLiveInSecond)
        {
            TimeLiveInSecond = timeToLiveInSecond;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Allow Exeplicty Injection
            var ResponseCachService = context.HttpContext.RequestServices.GetRequiredService<IResponseCachService>();

            var CacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

            var Response = await ResponseCachService.GetCachedResponseAsync(CacheKey);

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
                await ResponseCachService.SetCachResponseAsync(CacheKey, okObjectResult.Value, TimeSpan.FromSeconds(TimeLiveInSecond));


        }
        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var KeyBuilder = new StringBuilder();
            KeyBuilder.Append(request.Path); // api/ControllerName/


            // Get QueryString From Url To Make it Uniqe and add it on the string
            foreach (var (key,value) in request.Query)
            {
                KeyBuilder.Append($"|{key}-{value}");
            }
            return KeyBuilder.ToString();

        }
    }
}
