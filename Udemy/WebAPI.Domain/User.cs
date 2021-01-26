using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }

        public string OrganizationId { get; set; }

        public string Member { get; set; } = "Member";

        public List<UserRole> UserRoles { get; set; }
    }
}
