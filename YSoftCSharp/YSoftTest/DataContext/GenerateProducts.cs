using System;
using System.Collections.Generic;
using YSoftTest.Models;

namespace YSoftTest.DataContext
{
    public static class GenerateProducts
    {
        private static string[] names = new string[] { "Globus", "Backpack", "Cat", "Ball", "Pen", "Mail", "Car", "Paper", "Beer", "Burger", "Snack" };
        private static string[] descriptions = new string[] { "Awesome", "Good", "Bad", "Great", "Cheap" };
        private static string[] categoryies = new string[] { "Food", "Tech", "Furniture", "Kitchen", "Transport" };
        private static Random rnd = new Random();

        public static List<Product> Generate(int count)
        {
            var products = new List<Product>();
            for (int i = 1; i < count; i++)
            {
                var item = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = names[rnd.Next(0, names.Length - 1)],
                    Description = descriptions[rnd.Next(0, descriptions.Length - 1)],
                    Category = categoryies[rnd.Next(0, categoryies.Length - 1)],
                    Price = rnd.Next(10, 5000)
                };

                products.Add(item);
            }

            return products;
        }
    }
}