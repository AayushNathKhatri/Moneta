using DataModel.Model;

namespace Moneta.Components.Pages
{
    public partial class Cashoutflow
    {
        private string? sucessMessege;
        private string? failedMessege;
        protected override async Task OnInitializedAsync()
        {
            Tranction = await GetAllTanction();
        }
        private List<TransactionModel> Tranction = new();
        private bool buttonClicked = false;
        private void ShowForm()
        {
            buttonClicked = true;
        }
        private async void HideForm()
        {
            buttonClicked = false;
            Tranction = await GetAllTanction();
        }
        private async Task<List<TransactionModel>> GetAllTanction()
        {
            try
            {
                var transactions = await TranctionService.GetTranction();
                return transactions.Where(t => t.TransactionType == TransactionType.Expenditure).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the transactions.", ex);
            }
        }
        private async Task DeleteTranction(Guid TranctionId) { 
            var result = await TranctionService.DeleteTranction(TranctionId);

            if (result) {
                Tranction = await GetAllTanction();
            }
            else {
                failedMessege = "Deletetion Failed";
            }
        }
    }
}
