using CalorieCountingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CalorieCountingApp.Data
{
    public static class FillDataInDb 
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>())) {
                if (context.FoodItems.Any()) {
                    return;
                }

                context.FoodItems.AddRange(
                    new FoodItem
                    {
                        Name = "Apple",
                        Calories = 52,
                        Type = "Product",
                        Fats = 0,
                        Proteins = 0
                    },
                    new FoodItem
                    {
                        Name = "Banana",
                        Calories = 89,
                        Type = "Product",
                        Fats = 0.3,
                        Proteins = 1.1
                    },
                    new FoodItem
                    {
                        Name = "Chicken Breast",
                        Calories = 165,
                        Type = "Product",
                        Fats = 3.6,
                        Proteins = 31
                    },
                    new FoodItem
                    {
                        Name = "Salmon Fillet",
                        Calories = 208,
                        Type = "Product",
                        Fats = 13.4,
                        Proteins = 20.4
                    },
                    new FoodItem
                    {
                        Name = "Egg (Large)",
                        Calories = 70,
                        Type = "Product",
                        Fats = 4.8,
                        Proteins = 6.3
                    },
                    new FoodItem
                    {
                        Name = "Avocado",
                        Calories = 160,
                        Type = "Product",
                        Fats = 15,
                        Proteins = 2
                    },
                    new FoodItem
                    {
                        Name = "Greek Yogurt (Plain, Non-Fat)",
                        Calories = 59,
                        Type = "Product",
                        Fats = 0,
                        Proteins = 10
                    },
                    new FoodItem
                    {
                        Name = "Brown Rice (Cooked)",
                        Calories = 111,
                        Type = "Product",
                        Fats = 0.9,
                        Proteins = 2.6
                    },
                    new FoodItem
                    {
                        Name = "Broccoli",
                        Calories = 55,
                        Type = "Product",
                        Fats = 0.6,
                        Proteins = 4.2
                    },
                    new FoodItem
                    {
                        Name = "Spinach",
                        Calories = 23,
                        Type = "Product",
                        Fats = 0.4,
                        Proteins = 2.9
                    },
                    new FoodItem
                    {
                        Name = "Almonds",
                        Calories = 579,
                        Type = "Product",
                        Fats = 49.9,
                        Proteins = 21.2
                    },
                    new FoodItem
                    {
                        Name = "Olive Oil",
                        Calories = 119,
                        Type = "Product",
                        Fats = 13.5,
                        Proteins = 0
                    },
                    new FoodItem
                    {
                        Name = "Potato (Medium, Baked)",
                        Calories = 161,
                        Type = "Product",
                        Fats = 0.2,
                        Proteins = 4.3
                    },
                    new FoodItem
                    {
                        Name = "Tomato",
                        Calories = 18,
                        Type = "Product",
                        Fats = 0.2,
                        Proteins = 0.9
                    },
                    new FoodItem
                    {
                        Name = "Cucumber",
                        Calories = 16,
                        Type = "Product",
                        Fats = 0.1,
                        Proteins = 0.7
                    },
                    new FoodItem
                    {
                        Name = "Carrot",
                        Calories = 41,
                        Type = "Product",
                        Fats = 0.2,
                        Proteins = 0.9
                    },
                    new FoodItem
                    {
                        Name = "Green Beans",
                        Calories = 31,
                        Type = "Product",
                        Fats = 0.2,
                        Proteins = 1.8
                    },
                    new FoodItem
                    {
                        Name = "Lentils (Cooked)",
                        Calories = 165,
                        Type = "Product",
                        Fats = 0.8,
                        Proteins = 9
                    },
                    new FoodItem
                    {
                        Name = "Quinoa (Cooked)",
                        Calories = 120,
                        Type = "Product",
                        Fats = 1.9,
                        Proteins = 4.4
                    },
                    new FoodItem
                    {
                        Name = "Chickpeas (Cooked)",
                        Calories = 164,
                        Type = "Product",
                        Fats = 2.6,
                        Proteins = 8.9
                    },
                    new FoodItem
                    {
                        Name = "Beef (Sirloin, Grilled)",
                        Calories = 207,
                        Type = "Product",
                        Fats = 12.1,
                        Proteins = 24.6
                    },
                    new FoodItem
                    {
                        Name = "Pork Chop (Grilled)",
                        Calories = 172,
                        Type = "Product",
                        Fats = 8.1,
                        Proteins = 22.6
                    },
                    new FoodItem
                    {
                        Name = "Chocolate (Dark, 70-85% Cocoa)",
                        Calories = 604,
                        Type = "Product",
                        Fats = 42.6,
                        Proteins = 7.9
                    },
                    new FoodItem
                    {
                        Name = "Brownie",
                        Calories = 466,
                        Type = "Dish",
                        Fats = 21.9,
                        Proteins = 5.4
                    },
                    new FoodItem
                    {
                        Name = "Cheesecake",
                        Calories = 321,
                        Type = "Dish",
                        Fats = 19.8,
                        Proteins = 4.9
                    },
                    new FoodItem
                    {
                        Name = "Chicken Curry",
                        Calories = 358,
                        Type = "Dish",
                        Fats = 17.9,
                        Proteins = 23.7
                    },
                    new FoodItem
                    {
                        Name = "Lasagna",
                        Calories = 338,
                        Type = "Dish",
                        Fats = 18.9,
                        Proteins = 18.7
                    },
                    new FoodItem
                    {
                        Name = "Spaghetti Carbonara",
                        Calories = 456,
                        Type = "Dish",
                        Fats = 22.3,
                        Proteins = 19.8
                    },
                    new FoodItem
                    {
                        Name = "Caesar Salad",
                        Calories = 184,
                        Type = "Dish",
                        Fats = 12.1,
                        Proteins = 8.2
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
