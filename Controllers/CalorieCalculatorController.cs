using Microsoft.AspNetCore.Mvc;

namespace CalorieCountingApp.Controllers
{
    public class CalorieCalculatorController : Controller
    {
        public IActionResult Index() {
            return View();
        }

        public IActionResult WeightLoss() {
            return View();
        }

        public IActionResult WeightGain() {
            return View();
        }

        public IActionResult WeightMaintenance() {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateCalories(string goal, double weight, double height, int age, string gender) {
            double bmr = 0;

            if (gender == "Male") {
                bmr = 10 * weight + 6.25 * height - 5 * age + 5;
            }
            else if (gender == "Female") {
                bmr = 10 * weight + 6.25 * height - 5 * age - 161;
            }

            double dailyCalories = bmr;

            switch (goal) {
                case "WeightLoss":
                    dailyCalories *= 0.8;
                    break;

                case "WeightGain":
                    dailyCalories *= 1.2;
                    break;

                case "WeightMaintenance":
                    break;
            }

            ViewBag.DailyCalories = dailyCalories;
            return View("Result");
        }
    }
}
