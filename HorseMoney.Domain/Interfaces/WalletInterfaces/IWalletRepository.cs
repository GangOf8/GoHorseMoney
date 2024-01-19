using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces;

namespace HorseMoney.Infrastructure.Repository.WalletRepository
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Task<IList<Wallet>> GetAllAsync(int skip, int take);
    }
}
