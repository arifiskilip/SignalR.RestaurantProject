using System.Linq.Expressions;
using WebAPI.Common.Result;
using IResult = WebAPI.Common.Result.IResult;

namespace WebAPI.Common.Repository
{
    public interface IGenericRepository<TAdd, TUpdate, TList,TEntity> where TAdd: class
        where TUpdate : class
        where TList : class
        where TEntity : class
    {
        Task<IDataResult<List<TList>>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<IDataResult<TEntity>> AddAsync(TAdd entity);
        Task<IDataResult<TUpdate>> UpdateAsync(TUpdate entity);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<TList>> GetByIdAsync(int id);
    }
}
