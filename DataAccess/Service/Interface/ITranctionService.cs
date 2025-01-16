using DataModel.Model;
namespace DataAccess.Service.Interface
{
    public interface ITranctionService
    {
        Task<bool> CreateTranction(TransactionModel transaction);
        Task<bool> UpdateTranction(Guid TranctionId, TransactionModel transaction);
        Task<bool> DeleteTranction(Guid TranctionID);
        Task<List<TransactionModel>> GetTranction();
        Task<TransactionModel> GetTranctionById(Guid TranctionID);
       
    }
}
