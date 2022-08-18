using System.Threading.Tasks;
using WorkSpace.DTO;
using WorkSpace.ViewModels.Request;

namespace WorkSpace.Services.Interface
{
    public interface IAccountService
    {
        Task<string> GetUserName(string userId);
        Task<AccountDTO> GetAccount(string userId);
        Task<AccountDTO> ChangeAccount(AccountDTO account);
        Task<string> ChangePassword(string userId, ChangePasswordRequest passwords);
        Task DeleteAccount(string userId);
    }
}