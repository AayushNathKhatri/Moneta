using DataModel.Model;
using Microsoft.AspNetCore.Components;
using Moneta.Components.Pages;

namespace Moneta.Components.Layout
{
    public partial class UpdateTranction
    {
        [Parameter]
        public Guid TranctionId { get; set;}
        private bool? _sucess = null;
        private string? sucessMessages = "Transaction Updated";
        private string? errorMessage = "Please Fill all the field";
        private TransactionType TransactionType { get; set; }
        private TransctionTag TransactionTag { get; set; }
        public TransactionModel Transaction { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            // Fetch the transaction data using the TranctionId
            var transaction = await TranctionService.GetTranctionById(TranctionId);
            if (transaction != null)
            {
                Transaction = transaction;
                TransactionType = transaction.TransactionType;
                TransactionTag = transaction.TransactionTag;
            }
            else
            {
                _sucess = false;
                errorMessage = "Transaction not found.";
            }
        }
        private async void HandelSubmit()
        {
            if (await TranctionService.UpdateTranction(TranctionId, Transaction))
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