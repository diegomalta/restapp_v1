using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using restapp.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Api.Controllers.Security
{
    [ApiController]
    [Route("[api/security/controller]")]
    public class AuthController
    {
        private readonly SignInManager<RestAppUser> _signInManager;
        private readonly UserManager<RestAppUser> _userManager;
        private readonly IConfiguration _config;

        public AuthController(SignInManager<RestAppUser> signInManager, UserManager<RestAppUser> userManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

    }
}
