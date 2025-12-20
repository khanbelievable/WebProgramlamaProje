using Microsoft.AspNetCore.Identity;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Look for any gyms.
            if (context.Gyms.Any())
            {
                return;   // DB has been seeded
            }

            // Create Roles
            string[] roleNames = { "Admin", "Member" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create Admin User
            var adminUser = new ApplicationUser
            {
                UserName = "g221210000@sakarya.edu.tr",
                Email = "g221210000@sakarya.edu.tr",
                FullName = "Admin User",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(adminUser, "sau");
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Seed Gyms
            var gyms = new Gym[]
            {
                new Gym { Name = "Sakarya Fitness Center", Address = "Serdivan, Sakarya", PhoneNumber = "0264 211 0000" },
                new Gym { Name = "Elite Yoga Studio", Address = "Mavi Durak, Sakarya", PhoneNumber = "0264 211 0001" }
            };
            foreach (Gym g in gyms)
            {
                context.Gyms.Add(g);
            }
            context.SaveChanges();

            // Seed Services
            var services = new Service[]
            {
                new Service { Name = "Fitness", Description = "Ağırlık ve Kardiyo antrenmanları", DurationMinutes = 60, Price = 100 },
                new Service { Name = "Yoga", Description = "Zihin ve beden uyumu", DurationMinutes = 45, Price = 150 },
                new Service { Name = "Pilates", Description = "Esneklik ve güç geliştirme", DurationMinutes = 50, Price = 120 }
            };
            foreach (Service s in services)
            {
                context.Services.Add(s);
            }
            context.SaveChanges();

            // Seed Trainers
            var trainers = new Trainer[]
            {
                new Trainer { Name = "Ahmet Yılmaz", Specialty = "Vücut Geliştirme", Description = "10 yıl deneyimli eğitmen", GymId = gyms[0].Id },
                new Trainer { Name = "Ayşe Kaya", Specialty = "Yoga", Description = "Sertifikalı yoga eğitmeni", GymId = gyms[1].Id }
            };
            foreach (Trainer t in trainers)
            {
                context.Trainers.Add(t);
            }
            context.SaveChanges();
        }
    }
}
