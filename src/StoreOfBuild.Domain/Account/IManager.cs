using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Account
{
    public interface IManager
    {
         Task<bool> CreateAsync(string email, string password, string role);
         List<IUser> ListAll();
    }
}