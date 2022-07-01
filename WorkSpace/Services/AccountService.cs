using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WorkSpace.Models;

namespace WorkSpace.Services.Interface
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;

        public AccountService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserName(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);

            return user.UserName;
        }
    }
}
