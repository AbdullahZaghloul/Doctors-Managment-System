using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Task1.Data;
using MVC_Task1.Models;

namespace MVC_Task1.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult Index(string Name)
        {
            return View(model:Name);
        }

        public IActionResult SaveAppointment(Appointment appointment , string doctorName)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Name == doctorName);
            appointment.Doctor = doctor;
            appointment.DoctorId = doctor.Id;

            if(!_context.Appointments.Any(a=>a.Time == appointment.Time && a.Doctor.Name == appointment.Doctor.Name))
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                
            }
           
            return RedirectToAction("Index");
            

           
        }

        public IActionResult Appointment()
        {
            var appointments = _context.Appointments.Include(a=>a.Doctor);

            return View(appointments.ToList());
        }



    }
}
