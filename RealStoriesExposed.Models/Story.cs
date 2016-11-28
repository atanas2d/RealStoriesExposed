﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStoriesExposed.Models
{
    public class Story
    {
        public Guid StoryId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set;}

        public DateTime DateCreated { get; set;}
    }
}
