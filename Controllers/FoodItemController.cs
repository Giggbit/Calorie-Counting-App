using CalorieCountingApp.Data;
using CalorieCountingApp.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalorieCountingApp.Models.Pages;

namespace CalorieCountingApp.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly AppDbContext _context;

        public FoodItemController(AppDbContext context) { 
            _context = context;
        }

        public async Task<IActionResult> Index(string typeFilter, QueryOptions options, string searchString) {
            ViewBag.TypeFilter = typeFilter;
            ViewBag.SearchString = searchString;
            var foodItems = from f in _context.FoodItems select f;

            if (!string.IsNullOrEmpty(typeFilter)) {
                foodItems = foodItems.Where(f => f.Type == typeFilter);
            }

            if (!string.IsNullOrEmpty(searchString)) {
                foodItems = foodItems.Where(f => f.Name.Contains(searchString));
            }

            var pagedList = new PagedList<FoodItem>(foodItems, new QueryOptions {
                CurrentPage = options.CurrentPage,
                PageSize = options.PageSize,
            });

            return View(pagedList);
        }


        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var foodItem = await _context.FoodItems.FirstOrDefaultAsync(m => m.Id == id);
            if (foodItem == null) {
                return NotFound();
            }
            return View(foodItem);
        }

        private bool FoodItemExists(int id) {
            return _context.FoodItems.Any(e => e.Id == id);
        }
        
    }
}
