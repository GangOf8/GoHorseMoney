using HorseMoney.Domain.Entities;
using HorseMoney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HorseMoney.Infrastructure.Repository.WalletRepository
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        private readonly ApplicationDbContext _context;

        public WalletRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Wallet>> GetAllAsync(int skip = 0, int take = 25)
        {
            return await _context.Set<Wallet>()
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
    }
}
