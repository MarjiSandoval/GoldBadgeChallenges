using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02a_Claims_Repository;
using static _02a_Claims_Repository.Claims;

namespace _02a_Claims
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _claims = new ClaimsRepository();

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
                Console.WriteLine("What would you like to do?\n" +
                    "1. See all claims\n" +
                    "2. Take next claim\n" +
                    "3. Enter new claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        continueToRun = Exit();
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection 1 through 4\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private bool Exit()
        {
            Console.WriteLine("Thanks for using");
            return false;
        }

        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> claims = _claims.GetClaims();

            foreach (var claim in claims)
            {
                Console.WriteLine($"{claim.ClaimID}  {claim.TypeOfClaim}  {claim.ClaimDescription}  {claim.ClaimAmount}  {claim.DateOfIncident}  {claim.DateOfClaim}  {claim.IsValid}");

            }
            Console.ReadKey();
            
            AnyKey();
        }
        private void TakeNextClaim()
        {
            Console.Clear();
            
            

            Console.WriteLine("Here is the information for the next Claim in Queue");
            var claim = _claims.SeeWhosNextInLine();
            if (claim == null)
            {
                Console.WriteLine("Claim doesn't exist");
                Console.ReadKey();
                RunMenu();
            }
            DisplayClaim(claim);

            Console.WriteLine("Would you like to handle this Claim?  y/n");
            string userInputYorN = Console.ReadLine();
            if (userInputYorN == "Y".ToLower())
            {
               bool success = _claims.DeleteExistingClaims();
                if (success)
                {
                    Console.WriteLine("Claim has been handled.");
                }
                else
                    Console.WriteLine("Claim has NOT been handled.");

                Console.ReadKey();
            }
            else
                 RunMenu();
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("Enter the claim id: \n");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine( "Enter claim type: \n" +
                "1. Car \n" +
                "2. House \n" +
                "3. Theft \n");
            string claimInput = Console.ReadLine();
            int claimConversion = int.Parse(claimInput);
            newClaim.TypeOfClaim = (ClaimType)claimConversion;

            Console.WriteLine("Enter a claim description: \n");
            newClaim.ClaimDescription = Console.ReadLine();

            Console.WriteLine("Enter Amount of damage: \n");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine( "Enter Date of Accident: \n");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date of claim: \n");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is this claim valid: y/n  \n");
            newClaim.IsValid = _claims.IsValid(newClaim.DateOfIncident, newClaim.DateOfClaim);

            bool success = _claims.NewClaim(newClaim);

            if (success)
            {
                Console.WriteLine("Claim was successfully added to Queue");
            }
            else
                Console.WriteLine("Something went wrong.");

            AnyKey();

           

        }
        
        
        private void Seed()
        {
            Claims claim1 = new Claims(1, Claims.ClaimType.Car, "Car accident on 465", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            Claims claim2 = new Claims(2, Claims.ClaimType.Home, "House fire in Kitchen", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            Claims claim3 = new Claims(3, Claims.ClaimType.Theft, "stolen pancakes", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            //need to add the claims to repository after creation
            _claims.NewClaim(claim1);
            _claims.NewClaim(claim3);
            _claims.NewClaim(claim2);
        }
        private void DisplayClaim(Claims claims)
        {
            Console.Clear();
            Console.WriteLine($"{claims.ClaimID}\n" +
                $"{claims.TypeOfClaim}\n" +
                $"{claims.ClaimDescription}\n" +
                $"{claims.ClaimAmount}\n" +
                $"{claims.DateOfIncident}\n" +
                $"{claims.DateOfClaim}\n" +
                $"{claims.IsValid}\n");
        }
    }

}
