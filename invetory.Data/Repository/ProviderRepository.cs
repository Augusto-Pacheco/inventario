using Dapper;
using inventory.Data.Config;
using inventory.Data.Repository.Abstract;
using MySql.Data.MySqlClient;
using Tipi.Tools.Sql;

namespace inventory.Data.Repository
{
    internal class ProviderRepository : IproviderRepository
    {
        private readonly string _connectionString;
        public ProviderRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString.Value;
        }
        public async Task<bool> CheckIfExistsAsync(int providerId)
        {
            const string query = "SELECT COUNT(ProviderId) FROM Provider WHERE ProviderId = @pProviderId;";
            try
            {

                using var conn = new MySqlConnection(_connectionString);
                var response = await conn.ExecuteScalarAsync<int>(query, new
                {
                    pProviderId = providerId
                });

                return response == 1;
            }
            catch (Exception e)
            {

                throw new Exception("Provider cannot be found", e);
            }
        }

        public async Task<bool> CreateAsync(string name)
        {
            try
            {
                const string query = "INSERT INTO Provider (Name)" +
                                     "VALUES (@pName);";

                using var conn = new MySqlConnection(_connectionString);
                var transactionResult = await conn.ExecuteAsync(query, new
                {
                    pName = name
                });

                return transactionResult == 1;
            }
            catch (Exception e)
            {
                throw new Exception("an unexpected error occurred during provider creation.", e);
            }
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync(string? select, string? order, int page, int pageSize)
        {
            try
            {
                var validFields = new Dictionary<string, string>()
                {
                    { "id", "ProviderId AS provider_id" },
                    { "name", "Name AS name" }
                };

                var constructor = new QueryBuilder(validFields, table: "Provider", id: "ProviderId");
                var query = constructor.BuildQuery(select, order, page: page, pagesize: pageSize);

                using var conn = new MySqlConnection(_connectionString);
                var transactionResult = await conn.QueryAsync<dynamic>(query);

                return transactionResult;
            }
            catch (Exception e)
            {
                throw new Exception("providers could not be found", e);
            }
        }
        public async Task<dynamic> GetByIdAsync(int providerId, string? select)
        {
            try
            {
                var validFields = new Dictionary<string, string>()
                {
                    { "id", "ProviderId AS provider_id" },
                    { "name", "Name AS name" }
                };
                var validFilters = new Dictionary<string, string>()
                {
                    { "provider", "ProviderId = " }
                };
                var constructor = new QueryBuilder(validFields, table: "Provider", id: "ProviderId", validFilters);
                var query = constructor.BuildQuery(select, filters: $"provider:{providerId}");

                using var conn = new MySqlConnection(_connectionString);
                var transactionResult = await conn.QueryFirstOrDefaultAsync<dynamic>(query);

                return transactionResult;
            }
            catch (Exception e)
            {
                throw new Exception("provider could not be found", e);
            };
        }
    }
}
