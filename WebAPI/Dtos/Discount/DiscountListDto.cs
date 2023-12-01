namespace WebAPI.Dtos.Discount
{
    public class DiscountListDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int DiscountRate { get; set; }
        public bool Status { get; set; }
    }
}
