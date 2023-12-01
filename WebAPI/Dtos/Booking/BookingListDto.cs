namespace WebAPI.Dtos.Booking
{
    public class BookingListDto
    {
        public int Id { get; set; } 
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }
        public DateTime BookingDate { get; set; }
        public bool Status { get; set; }
    }
}
