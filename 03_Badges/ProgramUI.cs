using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_BadgesRepository;


namespace _03_Badges
{
    class ProgramUI
    {
        private readonly BadgeRepository _badge = new BadgeRepository();

        public void Run()
        {
            Seed();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin. What would you like to do?\n" +
                    "1. Add a badge. \n" +
                    "2. Edit a badge. \n" +
                    "3. List all badges. \n" +
                    "4. Exit \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        ShowAll();
                        break;
                    case "4":
                        continueToRun = Exit();
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection 1 through 4\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private bool Exit()
        {
            Console.WriteLine("Thanks for using this application");
            return false;
        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddBadge()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeRepo = new Dictionary<int, Badge>();

            Badge newBadge = new Badge();
            Console.WriteLine("What is the number on the Badge? \n ");
            newBadge.BadgeNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door that it needs access to: \n");
            badgeRepo.Add(BadgeNumber, userInput);

            Console.WriteLine("Any other doors? y/n \n");

            //if yes
            Console.WriteLine("List a door it needs access to:  \n");

            //if no
            //Return to main menu;

        }
        private void UpdateBadge()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeRepo = new Dictionary<int, Badge>();

            Badge newBadge = new Badge();
            Console.WriteLine("What is the badge number to update? \n");
            newBadge.BadgeNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"{newBadge} has access to {doors}");
            Console.WriteLine("What would you like to do? \n" +
                "1. Remove a door \n" +
                "2. Add a door \n");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    RemoveBadge();
                    break;
                case "2":
                    AddBadge();
                    break;
                default:
                    Exit();
                    break;
            }
        }
        private void ShowAll()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeRepo = new Dictionary<int, Badge>();

            foreach (var item in badgeRepo)
            {
                Console.WriteLine($"{badgeNumber}{Doors}");

            }
            Console.ReadKey();
        }

        private void RemoveBadge()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeRepo = new Dictionary<int, Badge>();

        }
    }
}
