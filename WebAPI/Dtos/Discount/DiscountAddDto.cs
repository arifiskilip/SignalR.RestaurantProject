namespace WebAPI.Dtos.Discount
{
    public class DiscountAddDto
    {
        public int ProductId { get; set; }
        public int DiscountRate { get; set; }
        public bool Status { get; set; }
    }
}
