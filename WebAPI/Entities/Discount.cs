using WebAPI.Common.Entity;

namespace WebAPI.Entities
{
    public class Discount : BaseEntity
    {
        public int ProductId { get; set; }
        public int DiscountRate { get; set; }

        public Product Product { get; set; }
    }
}
