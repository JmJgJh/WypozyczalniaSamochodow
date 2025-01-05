using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WypozyczalniaSamochdow.Models {
    public class Samochod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Marka { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [Range(1900, int.MaxValue, ErrorMessage = "Rok produkcji musi być między 1900 a bieżącym rokiem.")]
        public int RokProdukcji { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cena za dzień musi być większa od 0.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal CenaZaDzien { get; set; }

        [Required]
        public bool Dostepnosc { get; set; } = true;
    }

}

