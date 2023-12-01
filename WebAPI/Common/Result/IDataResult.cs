namespace WebAPI.Common.Result
{
    public interface IDataResult<T> : IResult where T : class
    {
        public T Data { get; set; }
    }
}
