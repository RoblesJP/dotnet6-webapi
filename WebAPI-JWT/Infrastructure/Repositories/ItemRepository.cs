using Domain;
using Domain.RepositoryInterfaces;
using Infrastructure.DbMapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        #region DbContext

        private readonly ShopDbContext _shopDbContext = null!;

        #endregion DbContext

        #region Constructor

        public ItemRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        #endregion Constructor

        public async Task<List<Item>> GetAllAsync()
        {
            return await _shopDbContext.Items.Include(item => item.Category).ToListAsync();
        }
    }
}