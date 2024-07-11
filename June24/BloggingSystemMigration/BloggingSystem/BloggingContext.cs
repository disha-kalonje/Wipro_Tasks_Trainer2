using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem
{
    public class BloggingContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BloggingContext():base("name=devDB")
        {
            // Database.SetInitializer(new BloggingInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BloggingContext , BloggingSystem.Migrations.Configuration>());
        }   
    }
    
   
}
