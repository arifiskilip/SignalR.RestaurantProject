﻿using WebAPI.Common.Entity;

namespace WebAPI.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
