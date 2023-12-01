using WebAPI.Common.Repository;
using WebAPI.Dtos.Category;
using WebAPI.Entities;

namespace WebAPI.Repositories.Abstract
{
    public interface ICategoryRepository  : IGenericRepository<CategoryAddDto, CategoryUpdateDto, CategoryListDto, Category>
    {
    }
}
