namespace Talabat.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "BadRequest ",
                401 => "Unauthorized ُShoof Token Ya Rys",
                404 => "Resource was Not found",
                500 => "Error are the path to the dark side",
               _ => null,
            };
        }
    }
}
