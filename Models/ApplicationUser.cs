using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebProgramlamaProje.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime MembershipDate { get; set; } = DateTime.Now;
    }
}
