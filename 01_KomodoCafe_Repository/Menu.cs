using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{
    public class Menu
    {
       
        public Menu() {}
        public Menu(int id, string mealName, double price)
        {
            ID = id;
            MealName = mealName;
            Price = price;
             
        }
        public Menu(string mealName, string description, string ingredients, double price)
        {
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public int  ID { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
    }
}
