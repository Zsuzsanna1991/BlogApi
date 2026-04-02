using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Title { get; set; }

        public string Content { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Category { get; set; }
        public DateTime PostTime { get; set; } = DateTime.Now;

        //Kapcsolat kialakítása
        public int BloggerId { get; set; } //Foreign Key
        public Blogger Blogger { get; set; } //hivatkozás a Blogger osztályra
    }
}
