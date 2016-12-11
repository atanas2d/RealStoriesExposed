using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealStoriesExposed.Data;
using RealStoriesExposed.Models;
using RealStoriesExposed.Services.Contracts;

namespace RealStoriesExposed.Services
{
    public class StoriesService : BaseService<Story>, IStoriesService
    {
        public StoriesService(IRSEData data) : base(data)
        {

        }

        public override void Add(Story story)
        {
            story.CreatedOn = DateTime.Now;
            base.Add(story);
        }

        public IQueryable<Story> GetAccessibleStories(object userId)
        {
            if (!Common.Constants.AdminsIDs.Contains(userId))
            {
                return GetAll().Where(s => s.AuthorId == userId.ToString());
            }

            return GetAll();
        }
    }
}
