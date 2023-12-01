namespace WebAPI.Common.Result
{
    public class DataResult<T> : IDataResult<T> where T : class
    {

        public ResponseType ResponseType { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public DataResult(ResponseType responseType, string message, T data)
        {
            ResponseType = responseType;
            Message = message;
            Data = data;
        }

        public DataResult(ResponseType responseType, T data)
        {
            ResponseType = responseType;
            Data = data;
        }
    }
}
