using System.Linq;
using RealStoriesExposed.Data;
using RealStoriesExposed.Models;
using RealStoriesExposed.Services.Contracts;

namespace RealStoriesExposed.Services
{

    public class UsersService : BaseService<ApplicationUser>, IUsersService
    {
        public UsersService(IRSEData data) : base(data)
        {

        }

        public IQueryable<ApplicationUser> GetAccessibleUsers(object userId)
        {
            if (Common.Constants.AdminsIDs.Contains(userId))
            {
                return GetAll();
            }
            return GetAll().Where(u => u.Id == userId.ToString());
        }
    }
}
