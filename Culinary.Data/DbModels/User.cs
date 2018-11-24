using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Culinary.Data.DbModels
{
    public class User : IdentityUser
    {
        public override string Id { get; set; }
        public override string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string PasswordHash { get; set; }

    }
}
