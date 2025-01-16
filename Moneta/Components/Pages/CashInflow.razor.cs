using DataModel.Model;
using Microsoft.AspNetCore.Components;


namespace Moneta.Components.Pages
{
    public partial class CashInflow
    {
        private string? deleteMessege;
        protected override async Task OnInitializedAsync()
        {
            Tranction = await GetAllTanction();
            filteredTransactions = Tranction;
        }
        private List<TransactionModel> Tranction = new();
        private bool buttonClickedAdd = false;
        private Guid TranID;
        private bool showUpdateForm = false;
        private bool buttonClickedUpdate = false;
        private string searchInput = string.Empty;
        private List<TransactionModel> filteredTransactions;
        private SortingState sortingState = SortingState.Default;
        private void ShowAddForm() {
            buttonClickedAdd = true;
        }

        private async void HideAddForm() { 
            buttonClickedAdd = false;
            filteredTransactions = await GetAllTanction();
        }
        private async void HideUpdateForm() {
            buttonClickedUpdate = false;
            showUpdateForm = false;
            filteredTransactions = await GetAllTanction();
        }
        public void ShowUpdateForm(Guid TranctionId)
        {
            TranID = TranctionId;
            showUpdateForm = true;
            buttonClickedUpdate = true;
        }
        private async Task<List<TransactionModel>> GetAllTanction() 
        {
            try
            {
                var transactions = await TranctionService.GetTranction();
                return transactions.Where(t => t.TransactionType == TransactionType.Income).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the transactions.", ex);
            }
        }
        private async Task DeleteTranction(Guid TranctionId)
        {
            var result = await TranctionService.DeleteTranction(TranctionId);

            if (result)
            {
                deleteMessege = "Transaction Deleted Successfully";
                Tranction = await GetAllTanction();
                filteredTransactions = ApplySearchFilter();// Reapply search filter
                SortByDate(sortingState);
            }
            else
            {
                deleteMessege = "Deletetion Failed";
            }
            StateHasChanged();

        }
        private List<TransactionModel> ApplySearchFilter()
        {
            return Tranction
                .Where(t =>
                    string.IsNullOrEmpty(searchInput) ||
                    (t.TransactionName?.Contains(searchInput, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();
        }
        private void OnSearchInputChange(ChangeEventArgs e)
        {
            searchInput = e.Value?.ToString() ?? string.Empty;

            filteredTransactions = Tranction
                .Where(t =>
                    string.IsNullOrEmpty(searchInput) ||
                    (t.TransactionName?.Contains(searchInput, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();
            SortByDate(sortingState);
        }
        private void SortByDate(SortingState state)
        {
            sortingState = state;
            filteredTransactions = sortingState switch
            {
                SortingState.Ascending => filteredTransactions.OrderBy(t => t.TransactionDate).ToList(),
                SortingState.Descending => filteredTransactions.OrderByDescending(t => t.TransactionDate).ToList(),
                _ => Tranction
            };
        }
    }
}