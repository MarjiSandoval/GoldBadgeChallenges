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
        private readonly MenuRepository _menu = new MenuRepository();

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
            menuItem.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a Description: ");
            menuItem.Description = Console.ReadLine();

            Console.WriteLine("Please enter ingredients: ");
            menuItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter a Price: ");
            menuItem.Price = double.Parse(Console.ReadLine());

            if (_menu.AddToMenu(menuItem))
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
           

            foreach (Menu menu in _menu.GetMenu())
            {
                DisplayMeal(menu);
            }
            AnyKey();
        }

        private void DisplayMeal(Menu menu)
        {
            Console.Clear();

            List<Menu> MealName = _menu.GetMenu();
        }

        private void DeleteMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Which meal would you like to remove?\n");
            List<Menu> currentMenu = _menu.GetMenu();

            int count = 0;
            foreach (Menu ID in currentMenu)
            {
                count++;
                Console.WriteLine($"{ count}.{ ID}");

            }
            int targetMenuID = int.Parse(Console.ReadLine());
            bool success = _menu.DeleteExistingMenuItem(targetMenuID);
            if (success)
            {
                Console.WriteLine("Your item has been deleted");
            }
            else
                Console.WriteLine("Delete did not work");

            AnyKey();
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
            _menu.AddToMenu(lunch);
            _menu.AddToMenu(dinner);
        }
    }
}
