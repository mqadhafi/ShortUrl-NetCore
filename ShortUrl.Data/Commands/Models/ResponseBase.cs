namespace ShortUrl.Data.Commands.Models
{
    public abstract class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}