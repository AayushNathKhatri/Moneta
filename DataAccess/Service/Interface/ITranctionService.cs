using DataModel.Model;
namespace DataAccess.Service.Interface
{
    public interface ITranctionService
    {
        Task<bool> CreateTranction(TransactionModel transaction);
        Task<bool> UpdateTranction(TransactionModel transaction);
        Task<bool> DeleteTranction(Guid TranctionID);
        Task<List<TransactionModel>> GetTranction();
    }
}
