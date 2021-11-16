using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02a_Claims_Repository
{
    public class ClaimsRepository
    {
        protected readonly Queue<Claims> _claims = new Queue<Claims>();
        int Count = 0;

        //Create
        public bool NewClaim(Claims claims)
        {
            if (claims is null)
            {
                return false;
            }
            else
            {
                
                _claims.Enqueue(claims);

                return true;
            }
        }
        //Read All
        public Queue<Claims> GetClaims()
        {
            return _claims;
        }

        // Read One
        public Claims SeeWhosNextInLine()
        {
            if (_claims.Count > 0 )
            {
           
            Claims claim = _claims.Peek();
            return claim;

            }
            return null;
        }
        
        //Delete Dequeue

        public bool DeleteExistingClaims()
        {
            if (_claims.Count > 0)
            {
                _claims.Dequeue();
                return true;
            }
            else
                return false;
        }
        // We need two DateTimes for this to work 

        public bool IsValid(DateTime accidentDate, DateTime claimDate)
        {
            //We need to do some math
            TimeSpan timeSpan = claimDate - accidentDate;
            Console.WriteLine("Time span "+ timeSpan.Days);
            if (timeSpan.Days <= 30)
            {
                return true;
            }
            else
                return false;
            
        }

    }
}
