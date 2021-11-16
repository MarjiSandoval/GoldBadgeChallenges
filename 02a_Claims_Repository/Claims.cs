using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02a_Claims_Repository
{
    public class Claims
    {

        public enum ClaimType
        {
            Car = 1, 
            Home, 
            Theft
        }
        public Claims(){}

        public Claims(int claimID, ClaimType claimType, string claimDescription, double claimAmount,DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

        

        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim {get; set; }
        public string ClaimDescription { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public DateTime DateOfIncident { get; set; }
    }
}
