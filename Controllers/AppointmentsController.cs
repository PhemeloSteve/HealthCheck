using Microsoft.AspNetCore.Mvc;
using HealtCheck.Models;
using HealthCheck.Models;

namespace HealtCheck.Controllers
{
    public class AppointmentsController : Controller
    {
        // Add your DbContext via DI if needed
        public IActionResult Index()
        {
            // Return a list of appointments
            return View();
        }

        public IActionResult Details(int id)
        {
            // Return details for a specific appointment
            return View();
        }

        public IActionResult Create()
        {
            // Return a view to create a new appointment
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                // Save appointment
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        public IActionResult Edit(int id)
        {
            // Return a view to edit an appointment
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                // Update appointment
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        public IActionResult Delete(int id)
        {
            // Return a view to confirm deletion
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete appointment
            return RedirectToAction(nameof(Index));
        }
    }
}