using DataAccess.Service.Interface;
using DataModel.Model;

namespace DataAccess.Service
{
    public class DebtService : DebtBase, IDebtService
    {
        private List<DebtsModel> _debts;

        public DebtService() {
            _debts = LoadDebt();
        }
        public async Task<bool> ClearDebt(Guid DebtId, DebtStatus newStatus)
        {
            var debts = _debts.FirstOrDefault(t => t.DebtId == DebtId);
            if (debts != null) 
            {
                debts.DebtStatus = newStatus;

                SaveDebts(_debts);
                return true;    
            }
            return false;
        }

        public async Task<bool> CreateDebt(DebtsModel debts)
        {
            _debts.Add(new DebtsModel
            {
                DebtId = Guid.NewGuid(),
                DebtSource = debts.DebtSource,
                DebtDeuDate= debts.DebtDeuDate,
                DebtRemark = debts.DebtRemark,
                DebtTaken = debts.DebtTaken,
                DebtAmount = debts.DebtAmount,
                DebtStatus = debts.DebtStatus,
            });
            SaveDebts(_debts);
            return true;
        }

        public async Task<List<DebtsModel>> GetDebt()
        {
            return _debts;
        }

        public async Task<bool> UpdateDebt(Guid DebtId, DebtsModel debts)
        {
            var debtUpdate = _debts.FirstOrDefault(t => t.DebtId == DebtId);
            if (debtUpdate != null)
            {
                debtUpdate.DebtSource = debts.DebtSource;
                debtUpdate.DebtDeuDate = debts.DebtDeuDate;
                debtUpdate.DebtRemark = debts.DebtRemark;
                debtUpdate.DebtAmount = debts.DebtAmount;


                SaveDebts(_debts);
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteDebt(Guid DebtId) {
            var debtDelete = _debts.FirstOrDefault(t => t.DebtId == DebtId);
            if (debtDelete != null)
            {
                _debts.Remove(debtDelete);
                SaveDebts(_debts);
                return true;
            }
            else { 
                return false;
            }
        }
    }
    
}
