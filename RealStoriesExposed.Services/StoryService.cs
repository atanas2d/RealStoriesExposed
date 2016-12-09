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
    public class StoryService : BaseService<Story>, IStoryService
    {
        public StoryService(IRSEData data) : base(data)
        {

        }

        public void Add(Story story)
        {
            Data.Stories.Add(story);
        }

        public void SaveChanges()
        {
            Data.Stories.SaveChanges();
        }

        public void Update(Story story)
        {
            Data.Stories.Update(story);
        }

        public void Delete(Story story)
        {
            Data.Stories.Delete(story);
        }
    }
}
