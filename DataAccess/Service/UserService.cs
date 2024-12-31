using DataAccess.Service.Interface;
using DataModel.Model;

namespace DataAccess.Service
{
    public class UserService : UserBase, IUserService
    {
        private List<UserModel> _users;

        public UserService() { 
            _users = LoadUsers();

            if (!_users.Any()) {
                _users.Add(new UserModel { Username = Seeding.SeedUsername, Password = Seeding.SeedPassword });
                SaveUsers(_users);
            }
        }
        public async Task<bool> login(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password)) {
                return false;
            }
            return _users.Any(u => u.Username == user.Username && u.Password == user.Password);
                
        }
    }
}
