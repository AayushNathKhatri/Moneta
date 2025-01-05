using DataModel.Model;
using System.Transactions;

namespace Moneta.Components.Pages
{
    public partial class Debts
    {
        private bool isFormVisible = false;   
        private bool isUpdateMode = false;
        private bool _sucess;
        private string? sucessMessages = "Transaction Stored";
        private string? errorMessage = "Please Fill all the field";
        private DebtsModel Debt { get; set; } = new();
        private List<DebtsModel> DebtStore = new();

        protected override async Task OnInitializedAsync()
        {
            DebtStore = await GetDebt();

        }
        private async void ShowAddForm()
        {
            isFormVisible = true;
            isUpdateMode = false;
            DebtStore = await GetDebt();
        }
        private void HideForm()
        {
            isFormVisible = false;
        }
        private async Task<List<DebtsModel>>GetDebt() {
            var debts = await DebtService.GetDebt();
            return debts ?? new List<DebtsModel>();
        }
        private async void SaveDebt() {
            Debt.DebtTaken = DateTime.Now;
            if (await DebtService.CreateDebt(Debt))
            {
                _sucess = true;

            }
            else
            {
                _sucess = false;
            }
        }
        private async void ClearDebt() { 
            
        }
    }
}