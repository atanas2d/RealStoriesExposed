using RealStoriesExposed.Common.Mapping;
using RealStoriesExposed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealStoriesExposed.ViewModels
{
    public class StoryViewModel : IMapFrom<Story>, IMapTo<Story>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUserViewModel Author { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}