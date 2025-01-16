using DataModel.Model;
using Microsoft.AspNetCore.Components;

namespace Moneta.Components.Pages
{
    public partial class Debts
    {
        protected override async Task OnInitializedAsync()
        {
            await LoadDebts();
            DebtStore = await DebtService.GetDebt();
            Tranction = await TranctionService.GetTranction();
            var result = await Calculate.Calculate(DebtStore, Tranction);
            totalCurrentBalance = result.TotalCurrentBalance;
            totalCurrentBalancewithDebt =result.TotalCurrentBalanceWithDebt;
            filteredDebts = DebtStore;
        }
        private bool isFormVisible;
        private bool isUpdateMode;
        private bool _isSuccess;
        private bool _debtClear = false;
        private string? Message;
        private double totalCurrentBalance;
        private double totalCurrentBalancewithDebt;
        private string searchInput;
        private List<DebtsModel> filteredDebts;
        private Guid? clearingDebtId;
        private string AlertClass = string.Empty;
        private DebtsModel Debt { get; set; } = new();
        private List<DebtsModel> DebtStore = new();
        private List<TransactionModel> Tranction = new ();
        private bool result;



        private async Task LoadDebts()
        {
            DebtStore = await DebtService.GetDebt() ?? new List<DebtsModel>();
        }

        private void ShowAddForm()
        {
            isFormVisible = true;
            isUpdateMode = false;
            Debt = new DebtsModel(); // Reset the model for a new entry
        }

        private void ShowEditForm(DebtsModel debt)
        {
            isFormVisible = true;
            isUpdateMode = true;
            Debt = debt; // Bind the existing debt for editing
        }

        private void HideForm()
        {
            isFormVisible = false;
            isUpdateMode = false;
            Message = null;
        }

        private async Task SaveOrUpdateDebt()
        {

            if (isUpdateMode)
            {
                result = await DebtService.UpdateDebt(Debt.DebtId, Debt);
            }
            else
            {
                if (Debt.DebtDeuDate >= DateTime.Now) {
                    Debt.DebtTaken = DateTime.Now;
                    result = await DebtService.CreateDebt(Debt);
                }

            }

            _isSuccess = result;
            Message = result ? "Operation successful!" : "Operation failed. Please try again.";

            if (result)
            {
                await LoadDebts();
                HideForm();
            }
        }

        private async Task ClearDebt(Guid debtId)
        {
            var debt = filteredDebts.FirstOrDefault(d => d.DebtId == debtId);
            if (debt != null)
            {
                if (debt.DebtStatus == DebtStatus.paid)
                {
                    // Debt is already cleared
                    Message = "This debt has already been cleared.";
                    AlertClass = "alert-warning";  // Yellow for already cleared
                }
                else
                {
                    // Simulate clearing the debt
                    debt.DebtStatus = DebtStatus.paid;  // Set debt status to 'Cleared'
                    Message = "Debt has been successfully cleared.";
                    AlertClass = "alert-success";  // Green for successful clear
                }
            }
            else
            {
                Message = "Error clearing the debt.";
                AlertClass = "alert-danger";  // Red for unsuccessful
            }

            StateHasChanged();  // Refresh the UI
        }

        private async Task DeleteDebt(Guid debtId)
        {
            bool result = await DebtService.DeleteDebt(debtId);
            _isSuccess = result;
            Message = result ? "Debt deleted successfully!" : "Failed to delete the debt.";
            await LoadDebts();
        }
        private List<DebtsModel> GetFilteredDebts()
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                return DebtStore;
            }

            return DebtStore
                .Where(t =>
                    (!string.IsNullOrEmpty(t.DebtSource) && t.DebtSource.Contains(searchInput, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }
        private void OnSearchInputChange(ChangeEventArgs e)
        {
            searchInput = e.Value.ToString();
            filteredDebts = GetFilteredDebts();
        }

    }
}
