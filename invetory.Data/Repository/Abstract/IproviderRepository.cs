namespace inventory.Data.Repository.Abstract
{
    public interface IproviderRepository
    {
        Task<bool> CreateAsync(string name);
        Task<IEnumerable<dynamic>> GetAllAsync(string? select, string? order, int page, int pageSize);
        Task<dynamic> GetByIdAsync(int providerId, string? select);
        Task<bool> CheckIfExistsAsync(int providerId);

    }
}
