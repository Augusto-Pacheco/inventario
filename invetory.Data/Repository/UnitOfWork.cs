using inventory.Data.Repository.Abstract;

namespace inventory.Data.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        public IproviderRepository Provider { get; }
        public UnitOfWork(IproviderRepository provider)
        {
            Provider = provider;
        }
    }
}
