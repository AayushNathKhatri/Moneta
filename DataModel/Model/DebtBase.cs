using System.Text.Json;

namespace DataModel.Model
{
    public class DebtBase
    {
        protected static readonly string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Debt.json");
        protected List<DebtsModel> LoadDebt()
        {
            if (!File.Exists(filePath)) return new List<DebtsModel>();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<DebtsModel>>(json) ?? new List<DebtsModel>();
        }
        protected void SaveDebts(List<DebtsModel> debts)
        {
            var json = JsonSerializer.Serialize(debts);
            File.WriteAllText(filePath, json);
        }
    }
}
