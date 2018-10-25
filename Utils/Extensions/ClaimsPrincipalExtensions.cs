using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Utils
{
    public static class ClaimsPrincipalExtensions
    {
        public static Claim GetClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal?.FindFirst(claimType);
        }

        public static string GetClaimValueOfNameIdentifier(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.GetClaim(ClaimTypes.NameIdentifier)?.Value;
        }

        public static bool RemoveClaim(this ClaimsPrincipal claimsPrincipal)
        {
            var identity = claimsPrincipal.Identity;

            claimsPrincipal.RemoveClaim();
            return true;
        }
    }
}
