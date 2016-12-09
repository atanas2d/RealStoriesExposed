using RealStoriesExposed.Common.Mapping;
using RealStoriesExposed.Models;
using RealStoriesExposed.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RealStoriesExposed.Areas.Administration.ViewModels
{
    public class StoryViewModel : IMapFrom<Story>, IMapTo<Story>
    {
        public int Id { get; set; }
        [Display(Name = "Story Title")]
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Display(Name = "Story Content")]
        [Required]
        [MinLength(10)]       
        public string Content { get; set; }
        public ApplicationUserViewModel Author { get; set; }
        public DateTime? CreatedOn { get; set; }
        public SelectList Users { get; set; }
        [Required]
        public string AuthorId { get; set; }
    }
}