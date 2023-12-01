namespace WebAPI.Dtos.Contact
{
    public class ContactUpdateDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
