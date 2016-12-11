using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealStoriesExposed.Models;

namespace RealStoriesExposed.Services.Contracts
{
    public interface IStoriesService : IService<Story>
    {
        IQueryable<Story> GetAccessibleStories(object userId);
    }
}
