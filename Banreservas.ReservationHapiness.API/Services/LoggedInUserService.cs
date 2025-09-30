using IdentityModel;
using Banreservas.ReservationHapiness.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Banreservas.ReservationHapiness.API.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
           // UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId
        {
            get
            {
                return _contextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);
            }
        }

        public string UserIdentify
        {
            get
            {
                return _contextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Issuer);
            }
        }
    }
}
