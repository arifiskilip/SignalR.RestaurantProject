using AutoMapper;
using WebAPI.Common.Repository;
using WebAPI.Dtos.Category;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;

namespace WebAPI.Repositories.Concrete
{
	public class CategoryRepository : GenericRepository<CategoryAddDto,CategoryUpdateDto,CategoryListDto,Category>, ICategoryRepository
	{
		public CategoryRepository(IMapper mapper) : base(mapper)
		{
		}
	}
}
