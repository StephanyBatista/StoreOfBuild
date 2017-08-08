using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain.Account;

namespace StoreOfBuild.Data.Identity
{
    public class Authentication : IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Authentication(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}