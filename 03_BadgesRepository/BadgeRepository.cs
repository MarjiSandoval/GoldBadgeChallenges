using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesRepository
{
    public class BadgeRepository
    {
        //Create
        protected readonly Dictionary<int, Badge> badgeRepo = new Dictionary<int, Badge>();

        bool AddBadge(Badge badge)
        {
            if (badge is null)
            {
                return false;
            }
            badgeRepo.Add(badge.BadgeNumber, badge);
            return true;

        }
        // Read One
        Badge GiveMeOneBadge(int badgeNumber)
        {
            foreach (var BadgeNumber in badgeRepo)
            {
                if (BadgeNumber.Key == badgeNumber)
                {
                    return BadgeNumber.Value;
                }
            }
            return null;
        }
        // Update
        public bool AddDoor(int key, string value)
        {
            Badge badge = GiveMeOneBadge(key);
            if (badge != null)
            {

                badge.Doors.Add(value);
                return true;

            }
            return false;
        }
        public bool RemoveDoor(int key, string value)
        {
            Badge badge = GiveMeOneBadge(key);
            if (badge != null)
            {
                badge.Doors.Remove(value);
                return true;
            }
            return false;
        }

        // Delete
        public bool RemoveBadge(Badge badge)
        {
            if (badge is null)
            {
                return false;
            }
            badgeRepo.Remove();
            return true;

        }

    }
}
