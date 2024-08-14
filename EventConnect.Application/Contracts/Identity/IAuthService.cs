using EventConnect.Domain.Models.Identity;

namespace EventConnect.Application.Contracts;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
    Task<RegistrationResponse> RegisterPayingUser(RegistrationRequest request);
}