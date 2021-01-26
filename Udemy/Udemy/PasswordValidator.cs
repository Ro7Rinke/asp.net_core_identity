using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy
{
    public class PasswordValidator<TUser>
        : IPasswordValidator<TUser> where TUser : class
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            var userName = await manager.GetUserNameAsync(user);

            if (userName == password)
                return IdentityResult.Failed(
                    new IdentityError { Description = ""});

            if (password.Contains("password"))
                return IdentityResult.Failed(
                    new IdentityError { Description = "" });

            return IdentityResult.Success;
        }
    }
}
