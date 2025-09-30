using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Banreservas.ReservationHapiness.Application.Interfaces.Identity;
using Banreservas.ReservationHapiness.Application.Models.Authentication;
using static System.Net.Mime.MediaTypeNames;
using NuGet.Common;
using System.Text.Json;
using NuGet.Protocol.Plugins;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using Banreservas.ReservationHapiness.API.Services;
using Banreservas.ReservationHapiness.Identity.Models;

namespace Banreservas.ReservationHapiness.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        private string TOKEN = string.Empty;
        public AccountController(
            IAuthenticationService authenticationService,
            IConfiguration configuration)
        {
             _authenticationService = authenticationService;

            _configuration = configuration;
        }

        [HttpGet("AuthContext")]
        [Authorize()]
        public IActionResult GetAuthContext()

        {
            var userId = this.User.FindFirstValue(JwtClaimTypes.Subject);
            var profile = new UserProfile
            {
                Email = this.User.FindFirstValue(JwtClaimTypes.Email),
                FirstName = this.User.FindFirstValue(JwtClaimTypes.Name),
                Id = userId,
                LastName = this.User.FindFirstValue(JwtClaimTypes.FamilyName),
                HasLoggedIn = true
            };
            if (profile == null) return NotFound();
            var context = new AuthContext
            {
                UserProfile = profile,
                Claims = User.Claims.Select(c => new SimpleClaim { Type = c.Type, Value = c.Value }).ToList()
            };
            return Ok(context);
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

    }
}
