using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Eğitmen Adı")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Uzmanlık")]
        public string Specialty { get; set; } // e.g., Muscle Building, Yoga, Pilates

        [Display(Name = "Hakkında")]
        public string Description { get; set; }

        [Display(Name = "Eğitmen Görseli")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Çalıştığı Salon")]
        public int GymId { get; set; }
        public Gym? Gym { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
