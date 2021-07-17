using Claim_Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Repository
{
    public class ClaimRepo
    {
        private readonly List<Claims> _listClaims = new List<Claims>();

        //Create
        public void AddClaimsToList(Claims claims)
        {
            _listClaims.Add(claims);
        }
        //Read
        public List<Claims> GetClaimsList()
        {
            return _listClaims;
        }

        //Update
        public bool UpdateExistingClaims(string claimType, Claims newClaims)
        {
            Claims oldClaims = GetClaimsByClaimType(claimType);
            if (oldClaims != null)
            {
                oldClaims.ClaimID = newClaims.ClaimID;
                oldClaims.ClaimType = newClaims.ClaimType;
                oldClaims.Description = newClaims.Description;
                oldClaims.ClaimAmount = newClaims.ClaimAmount;
                oldClaims.DateOfIncident = newClaims.DateOfIncident;
                oldClaims.DateOfClaim = newClaims.DateOfClaim;
                oldClaims.IsValid = newClaims.IsValid;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveClaimsFromList(string claimType)
        {
            Claims claims = GetClaimsByClaimType(claimType);

            if (claims == null)
            {
                return false;
            }

            int initialCount = _listClaims.Count;
            _listClaims.Remove(claims);

            if (initialCount > _listClaims.Count)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public Claims GetClaimsByClaimType(string claimType)
        {
            foreach (Claims claims in _listClaims)
            {
                if (claims.ClaimType.ToLower() == claimType.ToLower())
                {
                    return claims;
                }
            }
            return null;
        }
    }
}
