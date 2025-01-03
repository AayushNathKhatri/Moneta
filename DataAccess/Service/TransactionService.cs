using DataAccess.Service.Interface;
using DataModel.Model;

namespace DataAccess.Service
{

    public class TransactionService : TransactionBase, ITranctionService
    {
        private List<TransactionModel> _transaction;

        public TransactionService()
        {
            _transaction = LoadTranction();
        }
        public async Task<bool> CreateTranction(TransactionModel transaction)
        {
            _transaction.Add(new TransactionModel { TransactionId = Guid.NewGuid(), 
                TransactionName = transaction.TransactionName, 
                TransactionType = transaction.TransactionType,
                TransactionDescription = transaction.TransactionDescription,
                TransactionDate = transaction.TransactionDate,
                TransactionRemark = transaction.TransactionRemark,
                TransactionTag = transaction.TransactionTag,
                TransactionAmount = transaction.TransactionAmount,
            });
            SaveTranction(_transaction);
            return true;
        }

        public async Task<bool> DeleteTranction(Guid TranctionId)
        {
            var tranction = _transaction.FirstOrDefault(t => t.TransactionId == TranctionId);
            _transaction.Remove(tranction);
            SaveTranction(_transaction);
            return true;
        }

        public async Task<List<TransactionModel>> GetTranction()
        {
            return _transaction;
        }

        public async Task<bool> UpdateTranction(TransactionModel transaction)
        {
            throw new NotImplementedException();
        }
    }
}
