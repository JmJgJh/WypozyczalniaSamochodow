using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WypozyczalniaSamochdow.Models
{
    public class Uzytkownik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Imie { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Haslo { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Pesel { get; set; }

        [Required]
        [StringLength(10)]
        public string Plec { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataUrodzenia { get; set; }

        
        [StringLength(20)]
        [DefaultValue("Uzytkownik")]
        public string Rola { get; set; }
    }
}

