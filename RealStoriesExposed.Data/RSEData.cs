namespace RealStoriesExposed.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Repositories;
    using Models;

    public class RSEData : IRSEData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public RSEData()
            : this(new RSEDbContext())
        {
        }

        public RSEData(DbContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Story> Stories
        {
            get
            {
                return this.GetRepository<Story>();
            }
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>) repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
