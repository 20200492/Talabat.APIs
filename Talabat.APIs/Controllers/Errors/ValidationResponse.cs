namespace Talabat.APIs.Controllers.Errors
{
    public class ValidationResponse : ApiResponse
    {
        public List<string> Errors { get; set; }
        public ValidationResponse() : base(400)
        {
            Errors = new List<string>();
        }
    }
}
