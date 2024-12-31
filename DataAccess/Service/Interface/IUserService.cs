using DataModel.Model;
namespace DataAccess.Service.Interface
{
    public interface IUserService
    {
        Task<bool> login(UserModel user);
    }
}
