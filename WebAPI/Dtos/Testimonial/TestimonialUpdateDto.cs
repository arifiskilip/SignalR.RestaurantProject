﻿namespace WebAPI.Dtos.Testimonial
{
    public class TestimonialUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
