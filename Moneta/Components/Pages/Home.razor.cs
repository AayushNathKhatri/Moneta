using DataModel.Model;

namespace Moneta.Components.Pages
{
    public partial class Home
    {
        public List<DebtsModel> Debt = new();
        public List<TransactionModel> Tranction = new();
        public double totalBalance;
        public double totalIncome;
        public double totalExpense;
        public double totalDebtPending;
        public double totalDebtCleared;
        public double totalCurrentBalance;
        public double totalCurnetBalanceWithDebt;
        private double[] chartDataIncome;
        private string[] chartLabelIncome;

        private double[] chartDataExp;
        private string[] chartLabelExp;

        protected override async Task OnInitializedAsync() {
            Debt = await DebtService.GetDebt();
            Tranction = await TranctionService.GetTranction();

            var result = await Calculate.Calculate(Debt, Tranction);
            totalIncome = result.TotalIncome;
            totalExpense = result.TotalExpense;
            totalDebtPending = result.TotalDebtPending;
            totalDebtCleared = result.TotalDebtCleared;
            totalCurrentBalance = result.TotalCurrentBalance;
            totalCurnetBalanceWithDebt = result.TotalCurrentBalanceWithDebt;
            totalBalance = result.TotalBalance;
            chart();
        }
        
        private void chart() {

            chartLabelIncome = Tranction.Where(t=>t.TransactionType == TransactionType.Income).OrderByDescending(t =>t.TransactionName).Take(5).Select(t => t.TransactionName).ToArray();
            chartDataIncome = Tranction.Where(t => t.TransactionType == TransactionType.Income).OrderByDescending(t=>t.TransactionAmount).Take(5).Select(t => t.TransactionAmount).ToArray();
            
            chartDataExp = Tranction.Where(t => t.TransactionType == TransactionType.Expenditure).OrderByDescending(t => t.TransactionAmount).Take(5).Select(t => t.TransactionAmount).ToArray();
            chartLabelExp = Tranction.Where(t => t.TransactionType == TransactionType.Expenditure).OrderByDescending(t => t.TransactionName).Take(5).Select(t => t.TransactionName).ToArray();
        }
    }
}