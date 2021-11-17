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

            Badge newBadge = new Badge();
            Console.WriteLine("What is the number on the Badge? \n ");
            newBadge.BadgeNumber = int.Parse(Console.ReadLine());

            

            bool hasAssignedAllDoors = false;
            while (! hasAssignedAllDoors)
            {
                Console.WriteLine("List a door that it needs access to: \n");
                string userInput = Console.ReadLine();
                newBadge.Doors.Add(userInput);

                Console.WriteLine("Do you want to add another door? y/n");
                userInput = Console.ReadLine();

                if (userInput == "y".ToLower())
                {
                    continue;
                }
                else
                {
                    hasAssignedAllDoors = true;
                }
            }

            if (_badge.AddBadge(newBadge))
            {
                Console.WriteLine("Badge was added.");
            }
            else
                Console.WriteLine("Badge was not created");



            AnyKey();

        }
        private void UpdateBadge()
        {
            Console.Clear();



            Console.WriteLine("What is the badge number to update? \n");
            var userInputBadgeNumber = int.Parse(Console.ReadLine());

            var badge = _badge.GiveMeOneBadge(userInputBadgeNumber);
            DisplayBadgeInfo(badge);
            Console.WriteLine("What would you like to do? \n" +
                "1. Remove a door \n" +
                "2. Add a door \n");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("What door would you like to remove? ");
                    userInput = Console.ReadLine();
                    _badge.RemoveDoor(badge.BadgeNumber, userInput);
                    break;
                case "2":
                    Console.WriteLine("What door would you like to add? ");
                    userInput = Console.ReadLine();
                    _badge.AddDoor(badge.BadgeNumber, userInput);
                    break;
                default:
                    Exit();
                    break;
            }
        }

        private void ShowAll()
        {
            Console.Clear();
            Dictionary<int, Badge> badgeRepo = _badge.GetAllBadges();

            foreach (var item in badgeRepo)
            {
                DisplayBadgeInfo(item.Value);

            }
            Console.ReadKey();
        }
        private void DisplayBadgeInfo(Badge badge)
        {
            Console.WriteLine($"Id: {badge.BadgeNumber}");
            foreach (var door in badge.Doors)
            {
                Console.WriteLine(door);
            }
            Console.WriteLine();
        }

        private void Seed()
        {
            Dictionary<int, Badge> badgeRepo = new Dictionary<int, Badge>();

            Badge badge1 = new Badge(12345, new List<string> { "A7" });
            Badge badge2 = new Badge(22345, new List<string> { "A1, A4, B1, B2" });
            Badge badge3 = new Badge(32345, new List<string> { "A4, A5" });

            _badge.AddBadge(badge1);
            _badge.AddBadge(badge2);
            _badge.AddBadge(badge3);


        }
    }
}
