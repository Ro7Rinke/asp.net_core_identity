using Microsoft.AspNet.Identity.EntityFramework;
using System;
using WebAPI.Domain;

namespace WebAPI.Repo
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
    }
}
