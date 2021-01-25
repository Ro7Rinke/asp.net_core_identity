using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Models;

namespace Udemy.Context
{
    public class UserDbContext : IdentityDbContext<UserModel>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Organization>(organization =>
            {
                organization.ToTable("organizations");

                organization.HasKey(x => x.Id);

                organization.HasMany<UserModel>()
                    .WithOne()
                    .HasForeignKey(x => x.OrganizationId)
                    .IsRequired(false);

            });


        }
    }
}
