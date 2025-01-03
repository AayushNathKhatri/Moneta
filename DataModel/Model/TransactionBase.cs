using System.Text.Json;

namespace DataModel.Model
{
    public class TransactionBase
    {
        protected static readonly string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Transction.json");

        protected List<TransactionModel> LoadTranction()
        {
            if (!File.Exists(filePath)) return new List<TransactionModel>();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TransactionModel>>(json) ?? new List<TransactionModel>();
        }
        protected void SaveTranction(List<TransactionModel> transactions) { 
            var json = JsonSerializer.Serialize(transactions);
            File.WriteAllText(filePath, json);
        }
    }
}
