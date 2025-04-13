using Microsoft.AspNetCore.Mvc;
using MVC_Task1.Data;

namespace MVC_Task1.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult Index(string specialization, string search , int page=1)
        {
            IQueryable<Doctor> doctors = _context.Doctors;

            if(specialization is not null)
            {
                doctors = doctors.Where(d => d.Specialization == specialization);
                ViewBag.specialization = specialization;
            }

            if(search is not null)
            {
                doctors = doctors.Where(d => d.Name.Contains(search));
                ViewBag.search = search;
            }

            if (doctors.ToList().Count() == 0)
            {
                return RedirectToAction(nameof(NotFound));
            }

            var numOfDoctors = doctors.Count();
            var numOfPages = Math.Ceiling(numOfDoctors / 8.0);

            ViewBag.numOfPages = numOfPages;
            doctors = doctors.Skip((page - 1) * 8).Take(8);
            
            
           
            return View(doctors.ToList());
        }

        public IActionResult NotFound() 
        {
            return View();
        }


    }
}
