using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Common.Result;
using WebAPI.Repositories.Contexts;


namespace WebAPI.Common.Repository
{
    public class GenericRepository<TAdd, TUpdate, TList, TEntity> : IGenericRepository<TAdd, TUpdate, TList, TEntity> where TAdd : class
        where TUpdate : class
        where TList : class
        where TEntity : class
    {
        private readonly IMapper _mapper;

        public GenericRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IDataResult<TEntity>> AddAsync(TAdd entity)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                try
                {
                    var addedEntity = await context.Set<TEntity>().AddAsync(_mapper.Map<TEntity>(entity));
                    // await context.SaveChangesAsync();
                    return new DataResult<TEntity>(ResponseType.Success, "Ekleme işlemi başarılı!", addedEntity.Entity);
                }
                catch (Exception ex)
                {
                    return new DataResult<TEntity>(ResponseType.Error, ex.Message, null);
                }

            }
        }

        public async Task<Common.Result.IResult> DeleteAsync(int id)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                try
                {
                    var checkProduct = await context.Set<TEntity>().FindAsync(id);
                    if (checkProduct != null)
                    {
                        context.Set<TEntity>().Remove(checkProduct);
                        await context.SaveChangesAsync();
                        return new Result.Result(ResponseType.Success, "Silme işlemi başarılı!");
                    }
                    return new Result.Result(ResponseType.Error, "İlgili ürün bulunamadı!");
                }
                catch (Exception ex)
                {
                    return new Result.Result(ResponseType.Error, ex.Message);
                }

            }
        }

        public async Task<IDataResult<List<TList>>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                try
                {
                    var result = filter == null ? await context.Set<TEntity>().ToListAsync()
                        : await context.Set<TEntity>().Where(filter).ToListAsync();

                    var mapData = _mapper.Map<List<TList>>(result);
                    return new DataResult<List<TList>>(ResponseType.Success, "Listeleme işlemi başarılı!", mapData);
                }
                catch (Exception ex)
                {
                    return new DataResult<List<TList>>(ResponseType.Error, ex.Message, new());
                }

            }
        }

        public async Task<IDataResult<TList>> GetByIdAsync(int id)
        {
            using (RestaurantContext context = new())
            {
                try
                {
                    var checkProduct = await context.Set<TEntity>().FindAsync(id);
                    if (checkProduct != null)
                    { 
                        var mappedEntity = _mapper.Map<TList>(checkProduct);
                        return new DataResult<TList>(ResponseType.Success, "Listeleme işlemi başarılı!", mappedEntity);
                    }
                    return new DataResult<TList>(ResponseType.Error, id + " sahip data bulunamadı!", null);
                }
                catch (Exception ex)
                {

                    return new DataResult<TList>(ResponseType.Error, ex.Message, null);
                }
            }
        }

        public async Task<IDataResult<TUpdate>> UpdateAsync(TUpdate entity)
        {
            using (RestaurantContext context = new())
            {
                try
                {
                    var mappedData = _mapper.Map<TEntity>(entity);
                    context.Set<TEntity>().Update(mappedData);
                    await context.SaveChangesAsync();
                    return new DataResult<TUpdate>(ResponseType.Success, "Güncelleme işlemi başarılı!", entity);
                }
                catch (Exception ex)
                {
                    return new DataResult<TUpdate>(ResponseType.Error, ex.Message, null);
                }
            }
        }
    }
}
