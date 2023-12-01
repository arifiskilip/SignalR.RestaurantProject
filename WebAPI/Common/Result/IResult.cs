namespace WebAPI.Common.Result
{
    public interface IResult
    {
        public ResponseType ResponseType { get; set; }
        public string Message { get; set; }
    }
}
