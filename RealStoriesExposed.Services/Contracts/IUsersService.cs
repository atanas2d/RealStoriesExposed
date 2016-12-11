using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealStoriesExposed.Models;

namespace RealStoriesExposed.Services.Contracts
{
    public interface IUsersService : IService<ApplicationUser>
    {
        IQueryable<ApplicationUser> GetAccessibleUsers(object userId);
    }
}
