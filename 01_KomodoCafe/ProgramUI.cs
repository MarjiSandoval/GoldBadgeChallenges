using _01_KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe
{
    public class ProgramUI
    {
        private readonly Menu _menu = new Menu();

        public void Run()
        {
            RunMenu();
            SeedContent();

        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number for the option you would like:\n" +
                    "1. Add\n" +
                    "2. Delete\n" +
                    "3. See All Menu Items\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                
                {
                    case "1":
                        AddToMenu();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        GetMenu();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine( "Please make a valid selection between number 1 and 4\n" +
                            "Press any key to continue...");
                    Console.ReadKey();
                        break;
                }
            }
        }

        private void AddToMenu()
        {
            Console.Clear();
            Menu menuItem = new Menu();

            Console.WriteLine("Please add a Meal Name: ");
            Menu.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a Description: ");
            Menu.Description = Console.ReadLine();

            Console.WriteLine("Please enter ingredients: ");
            Menu.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter a Price: ");
            Menu.Price = Console.ReadLine();

            if (_menu.AddToMenu())
            {
                Console.WriteLine("Meal Added!!");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Meal was NOT added!!");
                AnyKey();
            }

        }

        private void GetMenu()
        {
            Console.Clear();
            List<Menu> listofMeals = _menu.GetMenu();

            foreach (Menu ID in _menu)
            {
                DisplayMeal(listofMeals);
            }
            AnyKey();
        }

        private void DeleteMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Which meal would you like to remove?\n");
            List<Menu> currentMenu = _menu.GetMenu();

            int count = 0;
            foreach (Menu ID in _menu)
            {
                count++;
                Console.WriteLine($"{ count}.{ ID}");

            }
            int targetMenuID = int.Parse(Console.ReadLine());
            int targetIndex = targetMenuID - 1;
            if (targetIndex >=0 && targetIndex < MealID.Count)
            {
                Menu MealName = MealID.Count[targetIndex];

                if (_menu.DeleteMenuItem(MealID))
                {
                    Console.WriteLine($"{MealID.MealName} was deleted.");
                    AnyKey();

                }
                else
                {
                    Console.WriteLine("Delete failed");
                    AnyKey();
                }
            }
            else
                Console.WriteLine("No Meals with that ID");
        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            Menu freshSalad = new Menu("Fresh Salad", "Start your meal with a tasty fresh salad", "lettuce, tomato, cucumber, and crutons", 6.00);
            Menu sandwich =new Menu("Hamburger", "Traditional hamburger", "half pound patty, lettuce, tomato, onion, mayo, add cheese for $1", 12.00);
            Menu lunch = new Menu("Poor Man's Pie with Irish Brown Bread", "Half a serving of Sheppards Pie with home made Brown Bread", "Mashed potatoe, peas, corn, ground beef, bread", 9.00);
            Menu dinner = new Menu("Steak & Guinness Pie", "Steak marinated in Guiness topped with a pastry shell", "Beef tips, Button Mushrooms, gravy, steak fries", 14.00);

            _menu.AddToMenu(freshSalad);
            _menu.AddToMenu(sandwich);
            _menu.AddToMeny(lunch);
            _menu.AddToMenu(dinner);
        }
    }
}
