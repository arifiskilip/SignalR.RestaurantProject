using WebAPI.Common.Entity;

namespace WebAPI.Entities
{
    public class Contact : BaseEntity
    {
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
