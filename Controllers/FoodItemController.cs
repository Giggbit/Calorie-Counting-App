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

        /*public IActionResult Create() { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Calories,Type,Fats,Proteins")] FoodItem foodItem) { 
            if(ModelState.IsValid) { 
                _context.FoodItems.Add(foodItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodItem);
        }

        public async Task<IActionResult> Edit(int? id) {
            if(id == null) {
                return NotFound();
            }

            var foodItem = await _context.FoodItems.FindAsync(id);
            if(foodItem == null) {
                return NotFound();
            }
            return View(foodItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Calories,Type,Fats,Proteins")] FoodItem foodItem) {
            if(id != foodItem.Id) {
                return NotFound();
            }

            if(ModelState.IsValid) {
                try {
                    _context.Update(foodItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if(!FoodItemExists(foodItem.Id)) {
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
            var foodItem = await _context.FoodItems.FindAsync(id);
            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool FoodItemExists(int id) {
            return _context.FoodItems.Any(e => e.Id == id);
        }
        
    }
}
