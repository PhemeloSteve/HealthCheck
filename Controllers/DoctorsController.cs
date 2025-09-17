using Microsoft.AspNetCore.Mvc;
using HealtCheck.Models;
using HealthCheck.Models;

namespace HealtCheck.Controllers
{
    public class DoctorsController : Controller
    {
        // ...existing code...

        // Admin-only doctor management
        [HttpGet]
        public IActionResult Manage()
        {
            // List all doctors
            return View();
        }

        [HttpPost]
        public IActionResult AddDoctor(string email, string firstName, string lastName, string password)
        {
            // Add doctor logic (create ApplicationUser, assign Doctor role, add to Doctors table)
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public IActionResult RemoveDoctor(string userId)
        {
            // Remove doctor logic (delete ApplicationUser, remove from Doctors table)
            return RedirectToAction("Manage");
        }
    }
}