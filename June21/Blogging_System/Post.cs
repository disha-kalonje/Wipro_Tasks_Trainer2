public class Post
{
    [Key]
    public int PostId { get; set; }

    [Required]
    public string PostDescription { get; set; }

    public DateTime CreationDate { get; set; }

    [ForeignKey("Blog")] // Foreign key annotation
    public int BlogId { get; set; }

    public Blog Blog { get; set; } // Navigation property for Blog entity
}
