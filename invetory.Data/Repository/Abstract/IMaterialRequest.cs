
namespace inventory.Data.Repository.Abstract
{
    public interface IMaterialRequest
    {
        Task<bool> CreateAsync(int ProductId, int qty, int providerId);
        Task<bool> UpdateAsync(int ProductId, int qty, int providerId);
        Task<dynamic> GetByIdAsync(int ProductId, string? select);
        Task<bool> DeleteAsync(int ProductId);
        Task<bool> CheckIfExistsAsync(int ProductId);
    }
}
