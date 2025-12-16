
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArticlesAppLab9Upload.Models;

namespace ArticlesApp.Models
{

    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titlul este obligatoriu")]
        [MinLength(5, ErrorMessage = "Titlul nu poate avea mai putin de 5 caractere")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Continutul articolului este obligatoriu")]
        public string Content { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Categoria este obligatorie")]
        public int? CategoryId { get; set; }
        
        public string? UserId { get; set; }
        
        public virtual ApplicationUser? User { get; set; }
        
        // Adaugam un string unde vom salva calea imaginii pentru articol
        [Required(ErrorMessage = "Imaginea este obligatorie")]
        public string Image { get; set; }


        public virtual Category? Category { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? Categ { get; set; }
        
    }
}
