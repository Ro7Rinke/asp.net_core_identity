using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Udemy.Models;

namespace Udemy.Claims
{
    public class UserClaims : UserClaimsPrincipalFactory<UserModel>
    {
        public UserClaims( UserManager<UserModel> userManager, 
            IOptions<IdentityOptions> optionsAccessor) :base(userManager, optionsAccessor)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserModel user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Member", user.Member));
            return identity;
        }
    }
}
