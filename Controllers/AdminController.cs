using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalorieCountingApp.Data;
using CalorieCountingApp.Models;
using System.Text;
using System.Security.Cryptography;

namespace CalorieCountingApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Admin admin) {
            if (ModelState.IsValid) {
                var adminUser = await _context.AdminData.FirstOrDefaultAsync(a => a.Username == admin.Username);

                if (adminUser != null && VerifyPassword(admin.Password, adminUser.PasswordHash)) {
                    HttpContext.Session.SetString("IsAdmin", "true");
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(admin);
        }

        public IActionResult Logout() {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Login");
        }

        public IActionResult Index() {
            if (!IsAdminLoggedIn()) {
                return RedirectToAction("Login");
            }
            return View();
        }

        public async Task<IActionResult> ListOfProducts() {
            if (!IsAdminLoggedIn()) {
                return RedirectToAction("Login");
            }
            return View(await _context.FoodItems.ToListAsync());
        }

        public IActionResult Create() {
            if (!IsAdminLoggedIn()) {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Calories,Type,Fats,Proteins")] FoodItem foodItem) {
            if (!IsAdminLoggedIn()) {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid) {
                _context.Add(foodItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodItem);
        }

        public async Task<IActionResult> Edit(int? id) {
            if (!IsAdminLoggedIn()) {
                return RedirectToAction("Login");
            }

            if (id == null) {
                return NotFound();
            }

            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null) {
                return NotFound();
            }
            return View(foodItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Calories,Type,Fats,Proteins")] FoodItem foodItem) {
            if (!IsAdminLoggedIn()) {
                return RedirectToAction("Login");
            }

            if (id != foodItem.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(foodItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!FoodItemExists(foodItem.Id)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(foodItem);
        }

        public async Task<IActionResult> Delete(int? id) {
            if (!IsAdminLoggedIn()) {
                return RedirectToAction("Login");
            }

            if (id == null) {
                return NotFound();
            }

            var foodItem = await _context.FoodItems.FirstOrDefaultAsync(m => m.Id == id);
            if (foodItem == null) {
                return NotFound();
            }
            return View(foodItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (!IsAdminLoggedIn()) {
                return RedirectToAction("Login");
            }

            var foodItem = await _context.FoodItems.FindAsync(id);
            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IsAdminLoggedIn() {
            return HttpContext.Session.GetString("IsAdmin") == "true";
        }

        private bool FoodItemExists(int id) {
            return _context.FoodItems.Any(e => e.Id == id);
        }

        private bool VerifyPassword(string password, string storedHash) {
            using (var sha256 = SHA256.Create()) {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash == storedHash;
            }
        }
    }
}
