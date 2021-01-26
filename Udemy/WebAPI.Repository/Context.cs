using Microsoft.AspNet.Identity.EntityFramework;
using System;
using WebAPI.Domain;

namespace WebAPI.Repository
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

    }
}
