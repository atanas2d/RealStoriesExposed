using Microsoft.AspNet.Identity.EntityFramework;
using RealStoriesExposed.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStoriesExposed.Data
{
    public class RSEDbContext : IdentityDbContext<ApplicationUser>
    {
        public RSEDbContext()
            : base("RealStoriesExposedConnection")
        {
        }

        public IDbSet<Story> Stories { get; set; }

        public static RSEDbContext Create()
        {
            return new RSEDbContext();
        }
    }
}
