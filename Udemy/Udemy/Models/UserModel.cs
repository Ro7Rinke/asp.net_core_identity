using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udemy.Models
{
    public class UserModel : IdentityUser
    {
        public string FullName { get; set; }

        public string OrganizationId { get; set; }

        public string Member { get; set; } = "Member";
    }

    public class Organization
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
