using WebAPI.Common.Entity;

namespace WebAPI.Entities
{
    public class Booking : BaseEntity
    {
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
