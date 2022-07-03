using System.Threading.Tasks;
using WorkSpace.ViewModels.Request;
using WorkSpace.ViewModels.Response;

namespace WorkSpace.Services.Interface
{
    public interface IAccountService
    {
        Task<string> GetUserName(string userId);
    }
}