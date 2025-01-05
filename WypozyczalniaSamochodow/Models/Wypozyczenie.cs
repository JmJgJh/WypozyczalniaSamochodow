using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WypozyczalniaSamochdow.Models
{
    public class Wypozyczenie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUzytkownika { get; set; }

        [ForeignKey("IdUzytkownika")]
        public Uzytkownik Uzytkownik { get; set; }

        [Required]
        public int IdSamochodu { get; set; }

        [ForeignKey("IdSamochodu")]
        public Samochod Samochod { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataWypozyczenia { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataZwrotu { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Koszt musi być większy od 0.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Koszt { get; set; }
    }
}
   
