using Microsoft.AspNetCore.Mvc;
using HealtCheck.Models;
using HealthCheck.Models;
using Microsoft.AspNetCore.Identity;
using HealthCheck.Data;

namespace HealtCheck.Controllers
{
    public class ClientsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account", new { returnUrl = "/Clients/Index" });

            var userId = _userManager.GetUserId(User);
            var client = _context.Clients.FirstOrDefault(c => c.ApplicationUserId == userId);
            if (client == null)
            {
                return View(new List<Appointment>());
            }
            var appointments = _context.Appointments
                .Where(a => a.ClientId == client.Id)
                .OrderByDescending(a => a.StartTime)
                .ToList();
            return View(appointments);
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Client client)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
