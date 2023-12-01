namespace WebAPI.Common.Result
{
    public class Result : IResult
    {
        public ResponseType ResponseType { get; set; }
        public string Message { get; set; }

        public Result(ResponseType responseType, string message)
        {
            ResponseType = responseType;
            Message = message;
        }

        public Result(ResponseType responseType)
        {
            ResponseType = responseType;
        }
    }
}
