using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.CategoryInterfaces.Repositories;
using HorseMoney.Infrastructure.Data;

namespace HorseMoney.Infrastructure.Repository;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}