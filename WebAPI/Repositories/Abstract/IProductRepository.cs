using WebAPI.Common.Repository;
using WebAPI.Common.Result;
using WebAPI.Dtos.Product;
using WebAPI.Entities;

namespace WebAPI.Repositories.Abstract
{
    public interface IProductRepository : IGenericRepository<ProductAddDto,ProductUpdateDto,ProductListDto,Product>
    {
        IDataResult<List<ProductWithCategoryListDto>> ProductWithCategories();
    }
}
