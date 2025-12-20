using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgramlamaProje.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hizmet Adı")]
        public string Name { get; set; } // e.g., Fitness, Yoga, Pilates

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Süre (Dakika)")]
        public int DurationMinutes { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
    }
}
