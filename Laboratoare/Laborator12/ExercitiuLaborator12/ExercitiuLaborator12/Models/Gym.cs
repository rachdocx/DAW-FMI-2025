using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExercitiuLaborator12.Models
{
    [Table("Gym")]
    public class Gym
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nume")]
        public string Nume { get; set; }
        public ICollection<Membership> Memberships { get; set; }
    }
}
