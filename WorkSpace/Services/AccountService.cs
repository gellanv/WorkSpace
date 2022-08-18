using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using WorkSpace.Behaviors.Interface;
using WorkSpace.DTO;
using WorkSpace.Models;
using WorkSpace.Repositories.Interface;
using WorkSpace.ViewModels.Request;

namespace WorkSpace.Services.Interface
{
    public class AccountService : IAccountService
    {
        readonly UserManager<User> userManager;
        readonly IValidation validation;
        readonly IMapper mapper;
        readonly IUnitOfWork unitOfWork;

        public AccountService(UserManager<User> _userManager, IValidation _validation, IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            userManager = _userManager;
            validation = _validation;
            mapper = _mapper;
            unitOfWork = _unitOfWork;
        }

        public async Task<string> GetUserName(string userId)
        {
            User user = await userManager.FindByIdAsync(userId);

            return user.UserName;
        }

        public async Task<AccountDTO> GetAccount(string userId)
        {
            User user = await userManager.FindByIdAsync(userId);
            validation.CheckObjectForNull(user);
            AccountDTO account = mapper.Map<AccountDTO>(user);

            return account;
        }

        public async Task<AccountDTO> ChangeAccount(AccountDTO account)
        {
            User user = await userManager.FindByIdAsync(account.Id);
            validation.CheckObjectForNull(user);
            mapper.Map(account, user);

            user.NormalizedEmail = account.Email.ToUpper().Trim();
            user.NormalizedUserName = account.UserName.ToUpper().Trim();

            await unitOfWork.SaveAsync();

            return account;
        }

        public async Task<string> ChangePassword(string userId, ChangePasswordRequest passwords)
        {
            var user = await userManager.FindByIdAsync(userId);
            validation.CheckObjectForNull(user);
            try
            {
                await userManager.ChangePasswordAsync(user, passwords.OldPassword, passwords.NewPassword);
            }

            catch (Exception ex)
            {
                return (ex.Message);
            }

            return "Password was updated";
        }

        public async Task DeleteAccount(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            validation.CheckObjectForNull(user);
            await userManager.DeleteAsync(user);
        }

    }
}
