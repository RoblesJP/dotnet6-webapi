namespace Domain.RepositoryInterfaces
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetAllAsync();
    }
}