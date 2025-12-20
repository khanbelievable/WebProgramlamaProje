using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class Gym
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Salon Adı")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Salon Görseli")]
        public string? ImageUrl { get; set; }

        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
