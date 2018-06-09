using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StoreOfBuild.Domain.Account;

namespace StoreOfBuild.Data.Identity
{
    public class ApplicationUser : IdentityUser, IUser
    {
        
    }
}