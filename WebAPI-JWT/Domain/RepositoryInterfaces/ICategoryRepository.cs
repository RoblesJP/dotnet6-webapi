namespace Domain.RepositoryInterfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync();
    }
}