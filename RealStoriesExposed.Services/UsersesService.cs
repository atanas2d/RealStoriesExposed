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

    public class UsersesService : BaseService<ApplicationUser>, IUsersService
    {
        public UsersesService(IRSEData data) : base(data)
        {

        }

    }


}
