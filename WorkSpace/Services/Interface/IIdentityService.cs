using System.Threading.Tasks;
using WorkSpace.ViewModels.Request;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Services.Interface
{
    public interface IIdentityService
    {
        Task<AuthenticationResponse> RegistrationAsync(UserRegistrationRequest user);
        Task<AuthenticationResponse> LoginAsync(UserLogInRequest user);
        Task<AuthenticationResponse> LoginGoogleAsync(ExternalAuthDto externalAuthDto);
    }
}