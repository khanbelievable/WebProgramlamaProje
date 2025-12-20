using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Üye")]
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Eğitmen")]
        public int TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

        [Required]
        [Display(Name = "Hizmet")]
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

        [Required]
        [Display(Name = "Randevu Tarihi")]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Onaylandı mı?")]
        public bool IsConfirmed { get; set; } = false;

        [Display(Name = "Notlar")]
        public string? Notes { get; set; }
    }
}
