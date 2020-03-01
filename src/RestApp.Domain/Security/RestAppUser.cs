using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restapp.Domain.Security
{
    public class RestAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DataBaseName { get; set; }
        public string ClientName { get; set; }

    }
}
