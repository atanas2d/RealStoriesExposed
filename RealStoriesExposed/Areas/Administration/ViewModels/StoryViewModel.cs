﻿using RealStoriesExposed.Common.Mapping;
using RealStoriesExposed.Models;
using RealStoriesExposed.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealStoriesExposed.Areas.Administration.ViewModels
{
    public class StoryViewModel : IMapFrom<Story>, IMapTo<Story>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } 

        public string Content { get; set; }

        //public ApplicationUserViewModel Author { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}