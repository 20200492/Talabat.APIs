namespace Talabat.APIs.Errors
{
    public class ApiResponse
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int code, string? message = null)
        {
            Code = code;
            Message = message ?? GetDefaultMessageForStatus(code);
        }

        private string? GetDefaultMessageForStatus(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Resource was not found",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate . Hate leads to carrer change",
                _ => null
            };

        }
    }
}
