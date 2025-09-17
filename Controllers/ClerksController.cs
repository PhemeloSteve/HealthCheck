using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HealthCheck.Models;
using HealtCheck.Data;
using HealthCheck.Data;

namespace HealtCheck.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class ClerksController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _db;

        public ClerksController(UserManager<ApplicationUser> userManager, AppDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Manage()
        {
            var clerks = _db.Clerks.ToList();
            return View(clerks);
        }

        [HttpPost]
        public async Task<IActionResult> AddClerk(string email, string firstName, string lastName, string password)
        {
            var user = new ApplicationUser { UserName = email, Email = email, FirstName = firstName, LastName = lastName };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Clerk");
                // Add to Clerks table if needed
            }
            // Handle errors and redirect
            return RedirectToAction("Manage");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveClerk(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
                // Remove from Clerks table if needed
            }
            return RedirectToAction("Manage");
        }
    }
}
