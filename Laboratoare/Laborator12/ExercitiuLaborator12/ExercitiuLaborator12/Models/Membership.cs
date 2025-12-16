using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExercitiuLaborator12.Models
{
    [Table("Membership")]
    public class Membership
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Titlul abonamentului este obligatoriu")]
        [Display(Name = "Titlu")]
        public string Titlu { get; set; }

        [Required(ErrorMessage = "Valoarea abonamentului este obligatorie")]
        [Range(1, int.MaxValue, ErrorMessage = "Valoarea trebuie să fie un număr întreg pozitiv")]
        [Display(Name = "Valoare")]
        public int Valoare { get; set; }

        [Required(ErrorMessage = "Data emiterii este obligatorie")]
        [Display(Name = "Data Emitere")]
        [DataType(DataType.DateTime)]
        public DateTime DataEmitere { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Sala de sport este obligatorie")]
        [Display(Name = "Sala de sport")]
        public int GymId { get; set; }

        [ForeignKey("GymId")]
        public Gym? Gym { get; set; }
    }
}
