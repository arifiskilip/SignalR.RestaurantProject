using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Common.Repository;
using WebAPI.Common.Result;
using WebAPI.Dtos.Product;
using WebAPI.Entities;
using WebAPI.Repositories.Abstract;
using WebAPI.Repositories.Contexts;

namespace WebAPI.Repositories.Concrete
{
    public class ProductRepository : GenericRepository<ProductAddDto, ProductUpdateDto, ProductListDto, Product>, IProductRepository
    {
        public ProductRepository(IMapper mapper) : base(mapper)
        {
        }

		public IDataResult<List<ProductWithCategoryListDto>> ProductWithCategories()
		{
			using (RestaurantContext context = new())
			{
				try
				{
					var dtos = context.Products.Include(x => x.Category).ToList().Select(x => new ProductWithCategoryListDto
					{
						Id = x.Id,
						CategoryId = x.CategoryId,
						Price = x.Price,
						CategoryName = x.Category.CategoryName,
						Description = x.Description,
						ImageUrl = x.ImageUrl,
						ProductName = x.ProductName,
						ProductStatus = x.Status
					}).ToList();
					return new DataResult<List<ProductWithCategoryListDto>>(ResponseType.Success,"İşlem başarılı!" ,dtos);
				}
				catch (Exception ex)
				{

					return new DataResult<List<ProductWithCategoryListDto>>(ResponseType.Error, "İşlem başarılı!", new());
				}
				
			}

		}
	}
}
