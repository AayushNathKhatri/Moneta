using System.Text.Json;


namespace DataModel.Model
{
    public class UserBase
    {
        protected static readonly string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "User.json");
        
        protected List<UserModel> LoadUsers() { 
            if(!File.Exists(filePath)) return new List<UserModel>();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<UserModel>>(json) ?? new List<UserModel>();
        }

        protected void SaveUsers(List<UserModel> users)
        {
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath, json);
        }
    }
}   
