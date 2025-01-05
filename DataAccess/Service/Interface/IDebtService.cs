using DataModel.Model;

namespace DataAccess.Service.Interface
{
    public interface IDebtService
    {
        Task<bool> CreateDebt(DebtsModel debts);
        Task<bool> UpdateDebt(Guid DebtId, DebtsModel debts);
        Task<bool> ClearDebt(Guid DebtdId, DebtStatus currentStatus);
        Task<List<DebtsModel>> GetDebt();
    }
}
