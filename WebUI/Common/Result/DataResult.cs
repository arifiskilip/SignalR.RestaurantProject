using System.Text.Json.Serialization;

namespace WebAPI.Common.Result
{
    public class DataResult<T> : IDataResult<T> where T : class
    {

        public ResponseType ResponseType { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}
