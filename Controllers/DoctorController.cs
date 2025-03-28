using Microsoft.AspNetCore.Mvc;
using MVC_Task1.Data;

namespace MVC_Task1.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult BookAppointment()
        {
            var doctors = _context.Doctors;
            return View(doctors.ToList());
        }
    }
}
