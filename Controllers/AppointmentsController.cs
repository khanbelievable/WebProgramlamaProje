using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Data;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppointmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            IQueryable<Appointment> appointments;

            if (User.IsInRole("Admin"))
            {
                appointments = _context.Appointments.Include(a => a.ApplicationUser).Include(a => a.Service).Include(a => a.Trainer);
            }
            else
            {
                appointments = _context.Appointments
                    .Where(a => a.ApplicationUserId == user.Id)
                    .Include(a => a.Service)
                    .Include(a => a.Trainer);
            }

            return View(await appointments.ToListAsync());
        }

        // GET: Appointments/Create
        public IActionResult Create(int? trainerId)
        {
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Name", trainerId);
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainerId,ServiceId,AppointmentDate,Notes")] Appointment appointment)
        {
            var user = await _userManager.GetUserAsync(User);
            appointment.ApplicationUserId = user.Id;

            // Simple availability check: Check if trainer has another appointment at the exact same time
            var isBusy = await _context.Appointments
                .AnyAsync(a => a.TrainerId == appointment.TrainerId && a.AppointmentDate == appointment.AppointmentDate);

            if (isBusy)
            {
                ModelState.AddModelError("AppointmentDate", "Bu eğitmen bu saatte müsait değil.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", appointment.ServiceId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Name", appointment.TrainerId);
            return View(appointment);
        }

        // POST: Appointments/Confirm/5 (Admin Only)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Confirm(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                appointment.IsConfirmed = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments
                .Include(a => a.ApplicationUser)
                .Include(a => a.Service)
                .Include(a => a.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (appointment == null) return NotFound();

            // Check if user owns the appointment or is admin
            var user = await _userManager.GetUserAsync(User);
            if (!User.IsInRole("Admin") && appointment.ApplicationUserId != user.Id)
            {
                return Forbid();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
