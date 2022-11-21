namespace inventory.Data.Repository.Abstract
{
    public interface IUnitOfWork
    {
        IproviderRepository Provider { get; }
    }
}
