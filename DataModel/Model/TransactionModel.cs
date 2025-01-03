namespace DataModel.Model
{
    public class TransactionModel
    {
        public Guid TransactionId { get; set; }
        public string TransactionName { get; set; } = string.Empty;
        public TransactionType TransactionType { get; set; }
        public string TransactionDescription { get; set; } = string.Empty ;
        public DateTime TransactionDate { get; set; }
        public string TransactionRemark { get; set; } = string.Empty;
        public TransctionTag TransactionTag { get; set; }

        public double TransactionAmount { get; set; }
    }
}
