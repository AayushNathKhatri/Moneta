namespace DataModel.Model
{
    public class DebtsModel
    {
        public Guid DebtId { get; set; }
        public string DebtSource { get; set; } = string.Empty;
        public DebtStatus DebtStatus { get; set; }
        public DateTime DebtDeuDate { get; set; } = DateTime.Now;
        public DateTime DebtTaken { get; set; }
        public string DebtRemark { get; set; } = string.Empty;
        public double DebtAmount { get; set; }
    }
}   
