using inventory.Data.Repository.Abstract;

namespace inventory.Data.Repository
{
    internal class MaterialRequest : IMaterialRequest
    {
        public Task<bool> CheckIfExistsAsync(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(int ProductId, int qty, int providerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetByIdAsync(int ProductId, string? select)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int ProductId, int qty, int providerId)
        {
            throw new NotImplementedException();
        }
    }
}
