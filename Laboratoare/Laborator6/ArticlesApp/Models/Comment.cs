using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Continutul este obligatoriu")]
        public string Content { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        
        //cheie externa, id-ul caruia ii corespunde comentariu
        public int ArticleId { get; set; }
        
        //proprietatea de navigare
        // un comentariu ii apartine unui singur articol
        public virtual Article Article { get; set; } = null!;
    }

}
