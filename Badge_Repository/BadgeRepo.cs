using Badge_Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, Badge> _listBadges = new Dictionary<int, Badge>();
        private int _count = 0;

        //Create
        public bool AddBadgesToList(Badge badge)
        {
            if (badge is null)
            {
                return false;
            }

            _count++;
            badge.ID = _count;
            _listBadges.Add(badge.ID, badge);
            return true;
        }

        //Read
        public Dictionary<int, Badge> GetBadges()
        {
            return _listBadges;
        }

        //Specific Badge By Its Key
        public Badge GetBadgeByKey(int userInputKey)
        {
            foreach (var badge in _listBadges)
            {
                if(badge.Key == userInputKey)
                {
                    return badge.Value;
                }
            }
            return null;
        }


        //Update
        public bool UpdateExistingBadges(int originalID, Badge badge)
        {
            var originalData = GetBadgeByKey(originalID);
            if (originalData != null)
            {
                originalData.ID = badge.ID;
                originalData.Doors = badge.Doors;
                return true;
            }
            return false;
        }

        //Add Doors
        public bool EditDoors(int userInputKey, string doorName)
        {
            Badge badge = GetBadgeByKey(userInputKey);

            if (badge == null)
            {
                return true;
            }
            foreach (var door in badge.Doors)
            {
                if (door == doorName)
                {
                    badge.Doors.Add(door); return true;
                }
            }
            return true;
        }

        //Delete
        public bool RemoveDoor(int userInputKey, string doorName)
        {
            Badge badge = GetBadgeByKey(userInputKey);

            if (badge == null)
            {
                return false;
            }
            foreach (var door in badge.Doors)
            {
                if (door == doorName)
                {
                    badge.Doors.Remove(door); return true;
                }

            }
            return false;
        }
    }
}
