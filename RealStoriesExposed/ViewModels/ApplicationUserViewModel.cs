using RealStoriesExposed.Common.Mapping;
using RealStoriesExposed.Models;
using System;

namespace RealStoriesExposed.ViewModels
{
    public class ApplicationUserViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}