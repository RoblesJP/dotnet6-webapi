using Domain;
using Domain.RepositoryInterfaces;
using Infrastructure.DbMapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region DbContext

        private readonly ShopDbContext _shopDbContext = null!;

        #endregion DbContext

        #region Constructor

        public CategoryRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        #endregion Constructor

        public async Task<List<Category>> GetAllAsync()
        {
            return await _shopDbContext.Categories.ToListAsync();
        }
    }
}