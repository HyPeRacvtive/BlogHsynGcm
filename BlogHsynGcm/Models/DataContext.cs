using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogHsynGcm.Models
{
    public class DataContext:DbContext
    {        public DataContext() : base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Writers> Writers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<SocialFeed> SocialFeed { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Settings> Settings { get; set; }


    }
}