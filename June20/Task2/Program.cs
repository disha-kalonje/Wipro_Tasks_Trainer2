using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


class Program
{
    static void Main(string[] args)
    {
        // Replace with your actual connection string information
        const string ConnectionString = "your_connection_string";
      
        // Sample usage (assuming database already exists with tables)
        using (var context = new BloggingContext())
        {
            class BloggingContext : DbContext
            {
                public BloggingContext() : base(ConnectionString)
                {
                }
            
                public DbSet<Blog> Blogs { get; set; }
                public DbSet<Post> Posts { get; set; }
            
                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Blog>()
                        .HasMany(b => b.Posts) // Define many-to-one relationship with Post
                        .WithOne(p => p.Blog) // Define foreign key on Post
                        .HasForeignKey(p => p.BlogId);
                }
            }
        }
    }
}
