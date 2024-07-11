using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingSystem
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Column("BlogName", TypeName = "nvarchar", Order = 2)]
        [MaxLength(255)]
        public string BlogName { get; set; }

        [Column("BlogType", TypeName = "nvarchar", Order = 3)]
        [MaxLength(100)]
        public string BlogType { get; set; }

        [Column("BlogHeader", TypeName = "nvarchar", Order = 4)]
        [MaxLength(255)]
        public string BlogHeader { get; set; }

        [Column("BlogDiscription", TypeName = "nvarchar", Order = 5)]
        [MaxLength(255)]
        public string BlogDescription { get; set; }

        [Column("BlogCategory", TypeName = "nvarchar", Order = 6)]
        [MaxLength(255)]
        public string BlogCategory { get; set; }

        public virtual ICollection<Post> Posts
        {
            get; set;
        }
    }

   
        [Table("Post")]
        public class Post
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
            [Column(Order = 1)] 
            public int PostId { get; set; }

            [Column("PostDiscription" , TypeName = "nvarchar" , Order = 2)]
            [MaxLength(255)]    
            public string PostDiscription { get; set; }

            [Column("CreationDate", TypeName = "datetime" , Order = 3)]
            public DateTime CreationDate { get; set; }

            [ForeignKey("Blog")]
            [Column(Order = 4)]
            public int BlogId { get; set; }

            public virtual Blog Blog { get; set; }


        }
}
