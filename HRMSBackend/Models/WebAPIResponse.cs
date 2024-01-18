namespace HRMSBackend.Models
{
    public class WebAPIResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
        public string Error { get; set; }

        public WebAPIResponse()
        {
            Success = false;
            Data = "";
            Error = "";
            Message = "";
        }
    }
}
