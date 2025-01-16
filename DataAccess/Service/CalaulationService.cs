using DataAccess.Service.Interface;
using DataModel.Model;


namespace DataAccess.Service
{
    public class CalaulationService : ICalculationService
    {
        public async Task<CalculationResutl> Calculate(List<DebtsModel> debts, List<TransactionModel> transactions)
        {
            double totalIncome = transactions
           .Where(t => t.TransactionType == TransactionType.Income)
           .Sum(t => t.TransactionAmount);

            double totalExpense = transactions
                .Where(t => t.TransactionType == TransactionType.Expenditure)
                .Sum(t => t.TransactionAmount);

            double totalDebtPending = debts.Where(d => d.DebtStatus == DebtStatus.pending).Sum(d => d.DebtAmount);
            double totalDebtCleared = debts.Where(d => d.DebtStatus == DebtStatus.paid).Sum(d => d.DebtAmount);

            double totalCurrentBalance = totalIncome - totalExpense;
            double totalCurrentBalanceWithDebt = totalCurrentBalance + totalDebtPending;
            double totalBalance = totalCurrentBalanceWithDebt - totalDebtCleared;

            return new CalculationResutl
            {
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                TotalDebtPending = totalDebtPending,
                TotalDebtCleared = totalDebtCleared,
                TotalCurrentBalance = totalCurrentBalance,
                TotalCurrentBalanceWithDebt = totalCurrentBalanceWithDebt,
                TotalBalance = totalBalance
            };
        }
    }
}
