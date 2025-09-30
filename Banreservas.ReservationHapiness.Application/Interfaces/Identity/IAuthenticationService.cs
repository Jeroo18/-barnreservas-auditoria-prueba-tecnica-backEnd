using Banreservas.ReservationHapiness.Application.Models.Authentication;

namespace Banreservas.ReservationHapiness.Application.Interfaces.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
