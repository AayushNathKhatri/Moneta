using DataModel.Model;


namespace Moneta.Components.Pages
{
    public partial class CashInflow
    {
        private string? failedMessege;
        protected override async Task OnInitializedAsync()
        {
            Tranction = await GetAllTanction();
        }
        private List<TransactionModel> Tranction = new();
        private bool buttonClickedAdd = false;
        private Guid TranID;
        private bool showUpdateForm = false;
        private bool buttonClickedUpdate = false;
        private void ShowAddForm() {
            buttonClickedAdd = true;
        }

        private async void HideAddForm() { 
            buttonClickedAdd = false;
            Tranction = await GetAllTanction();
        }
        private async void HideUpdateForm() {
            buttonClickedUpdate = false;
            showUpdateForm = false;
            Tranction = await GetAllTanction();
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
                Tranction = await GetAllTanction();
            }
            else
            {
                failedMessege = "Deletetion Failed";
            }
        }
    }
}