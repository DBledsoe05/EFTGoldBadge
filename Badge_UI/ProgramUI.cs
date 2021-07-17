using Badge_Poco;
using Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_UI
{
    class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                //User Choices
                Console.WriteLine("Hello Admin, what would you like to accomplish today?\n" +
                    "1. Add Badge\n" +
                    "2. Edit Badges\n" +
                    "3. View All Badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        DisplayAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Exiting Badge Program....");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid number");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Add Badge
        private void AddBadge()
        {
            Console.Clear();
            bool hasEnteredDoors = false;
            Badge newBadge = new Badge();
            List<string> doors = new List<string>();

            Console.WriteLine("What's the number for the badge?:");
            string badgeId = Console.ReadLine();
            newBadge.ID = int.Parse(badgeId);

            Console.Clear();
            while (hasEnteredDoors == false)
            {
                hasEnteredDoors = ActivateDoorAccess(doors);
            }
            newBadge.Doors = doors;
            var success = _badgeRepo.AddBadgesToList(newBadge);
            if (success)
            {
                Console.WriteLine("Badge was created.");
            }
            else
            {
                Console.WriteLine("Badge creation failed.");
            }
        }

        private bool ActivateDoorAccess(List<string> doors)
        {
            Console.WriteLine("List a door that needs access:");
            var userInputDoor = Console.ReadLine();
            doors.Add(userInputDoor);

            Console.WriteLine("Do you want to enter another door? (y/n):");
            var userInputYorN = Console.ReadLine();
            if (userInputYorN == "Y".ToLower())
            {
                ActivateDoorAccess(doors);
            }
            else
            {
                return true;
            }
            return true;
        }
        //Edit Badge
        private void EditBadge()
        {
            Console.Clear();
            Badge newDoor = new Badge();
            List<string> doors = new List<string>();
            DisplayAllBadges();
            Console.WriteLine("What's the badge number do you want to update?:");
            string oldBadge = Console.ReadLine();
            newDoor.ID = int.Parse(oldBadge);

            Console.WriteLine("What would you like to do?\n" +
                "1. Delete a Door\n" +
                "2. Add a Door\n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Door was deleted.");
                    DeleteDoor();
                    break;
                case "2":
                    Console.WriteLine("Door was added.");
                    AddDoor();
                    break;
                default:
                    break;
            }
        }

        private void DeleteDoor()
        {
            Console.Clear();

            DisplayAllBadges();
            Console.WriteLine("Enter the name of the door you want removed:");
            string input = Console.ReadLine();
            bool doorNameDeleted = _badgeRepo.RemoveDoor(input);
        }

        private void AddDoor()
        {
            {
                Console.Clear();
                bool hasEnteredDoors = false;
                Badge newBadge = new Badge();
                List<string> doors = new List<string>();

                Console.WriteLine("What's the number for the badge?:");
                string badgeId = Console.ReadLine();
                newBadge.ID = int.Parse(badgeId);

                Console.Clear();
                while (hasEnteredDoors == false)
                {
                    hasEnteredDoors = ActivateDoorAccess(doors);
                }
                newBadge.Doors = doors;
                var success = _badgeRepo.AddBadgesToList(newBadge);
                if (success)
                {
                    Console.WriteLine("Badge was created.");
                }
                else
                {
                    Console.WriteLine("Badge creation failed.");
                }
            }
        }

        //View All Badges
        private void DisplayAllBadges()
        {
            Console.Clear();
            var badgeInDataBase = _badgeRepo.GetBadges();
            foreach (var badge in badgeInDataBase.Values)
            {
                DisplayBadgeInfo(badge);
            }

            Console.ReadKey();
        }

        private void DisplayBadgeInfo(Badge badge)
        {
            Console.WriteLine($"BADGEID: {badge.ID}\n");
            Console.WriteLine("Doors:");
            foreach (var door in badge.Doors)
            {
                Console.WriteLine(door);

            }
            Console.WriteLine("------------------------------------------------------------\n");
        }
    }
}
