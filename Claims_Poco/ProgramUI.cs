using Claim_Poco;
using Claim_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Poco
{
    class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Choose Menu Item:\n" +
                    "1. See All Claims\n" +
                    "2. Take care of next Claim\n" +
                    "3. Enter New Claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Have a nice day.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Press a valid key number.");
                        break;
                }

                Console.WriteLine("Please enter any valid key");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //View All CLaims
        private void ViewAllClaims()
        {
            List<Claims> listOfClaims = _claimRepo.GetClaimsList();

            foreach (Claims claims in listOfClaims)
            {
                Console.WriteLine($"Claim ID: {claims.ClaimID}\n" +
                    $"Claim Type: {claims.ClaimType}\n" +
                    $"Claim Type: {claims.Description}\n" +
                    $"Claim Type: {claims.ClaimAmount}\n" +
                    $"Claim Type: {claims.DateOfIncident}\n" +
                    $"Claim Type: {claims.DateOfClaim}\n" +
                    $"Claim Type: {claims.IsValid}\n");
            }
        }

        //Take Care Of Claim
        private void TakeCareOfClaim()
        {
            Console.Clear();
            ViewAllClaims();
            Console.WriteLine("Enter the name of the claim to work on it:");
            string oldClaim = Console.ReadLine();

            Claims newClaim = new Claims();

            Console.WriteLine("Enter the claim ID:");
            string claimsIDString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimsIDString);

            Console.WriteLine("Enter claim type:");
            newClaim.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the claim amount:");
            string claimsStringID = Console.ReadLine();
            newClaim.ClaimAmount = int.Parse(claimsStringID);

            DateTime claimDate;
            Console.WriteLine("Enter date of incident in format (MM/DD/YYYY:");
            claimDate = DateTime.Parse(Console.ReadLine());

            DateTime claimDates;
            Console.WriteLine("Enter date of claim in format (MM/DD/YYYY:");
            claimDates = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is the claim within 30 days of filing? (y/n):");
            string isClaimVaild = Console.ReadLine().ToLower();

            if (isClaimVaild == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            bool wasUpdated = _claimRepo.UpdateExistingClaims(oldClaim, newClaim);

            if (wasUpdated)
            {
                Console.WriteLine("Current Claim is finished back to menu.");
            }
            else
            {
                Console.WriteLine("Nothing Change back to menu to do the next claim.");
            }
        }

        //New Claim
        private void NewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("Enter the claim ID:");
            string claimsIDString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(claimsIDString);

            Console.WriteLine("Enter claim type:");
            newClaim.ClaimType = Console.ReadLine();

            Console.WriteLine("Enter claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the claim amount:");
            string claimsStringID = Console.ReadLine();
            newClaim.ClaimAmount = int.Parse(claimsStringID);

            DateTime claimDate;
            Console.WriteLine("Enter date of incident in format (MM/DD/YYYY:");
            claimDate = DateTime.Parse(Console.ReadLine());

            DateTime claimDates;
            Console.WriteLine("Enter date of claim in format (MM/DD/YYYY:");
            claimDates = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is the claim within 30 days of filing? (y/n):");
            string isClaimVaild = Console.ReadLine().ToLower();

            if (isClaimVaild == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimRepo.AddClaimsToList(newClaim);
        }
    }
}
