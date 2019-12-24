namespace ShortUrl.Business.Models
{
    public class Response : ResponseBase
    {
    }

    public class Response<TData> : ResponseBase where TData : class
    {
        public TData Data { get; set; }
        public int Length { get; set; } = 0;
    }
}