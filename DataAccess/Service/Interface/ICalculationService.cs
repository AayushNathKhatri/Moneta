using DataModel.Model;

namespace DataAccess.Service.Interface
{
    public interface ICalculationService
    {
        Task<CalculationResutl> Calculate(List<DebtsModel> debts, List<TransactionModel> transactions);
    }
}
