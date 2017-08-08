namespace StoreOfBuild.Domain.Account
{
    public interface IUser
    {
         string Id { get; set; }
         string UserName { get; set; }
         string Email { get; set; }
    }
}