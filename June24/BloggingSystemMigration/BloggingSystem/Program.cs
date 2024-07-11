using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (BloggingContext context = new BloggingContext())
            {
                context.Blogs.Add(new Blog
                {
                    BlogName = "Tech Blog",
                    BlogType = "Technology",
                    BlogHeader = "Latest Tech News",
                    BlogDescription = "All about the latest in technology." ,
                    BlogCategory = "Tech"
                }); 

                context.Blogs.Add(new Blog
                {
                    BlogName = "Travel Blog",
                    BlogType = "Travel",
                    BlogHeader = "Adventures Around the World",
                    BlogDescription = "Travel stories and tips from around the world." ,
                    BlogCategory = "Travel"
                });

                context.SaveChanges();

                var Blogs = context.Blogs.ToList();
                foreach (var Blog in Blogs) 
                    {
                        Console.WriteLine($"{ Blog.BlogName} , {Blog.BlogType} , {Blog.BlogDescription}");
                    }
            }
        }
    }
}
