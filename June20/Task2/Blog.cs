public class Blog
{
    public int BlogId { get; set; }

    public string BlogName { get; set; }

    public string BlogType { get; set; }

    public string BlogHeader { get; set; }

    public string BlogDescription { get; set; }

    public ICollection<Post> Posts { get; set; } // Navigation property for Post collection
  
}
