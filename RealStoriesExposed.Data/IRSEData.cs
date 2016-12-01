namespace RealStoriesExposed.Data
{
    using RealStoriesExposed.Data.Repositories;
    using RealStoriesExposed.Models;

    public interface IRSEData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Story> Stories
        {
            get;
        }

    }
}
