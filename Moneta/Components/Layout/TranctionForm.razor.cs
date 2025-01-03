using DataModel.Model;

namespace Moneta.Components.Layout
{
    public partial class TranctionForm
    {
        private bool? _sucess = null;
        private string? sucessMessages = "Transaction Stored";
        private string? errorMessage = "Please Fill all the field";
        private TransactionType TransactionType { get; set; }
        private TransctionTag TransactionTag { get; set; }
        public TransactionModel Transaction { get; set; } = new();

        private async void HandelForm()
        {
            Transaction.TransactionDate = DateTime.Now;
            if (await TranctionService.CreateTranction(Transaction))
            {
                _sucess = true;
                
            }
            else
            {
                _sucess = false;
            }
        }
    }
}