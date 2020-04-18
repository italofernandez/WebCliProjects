using CoreAPI.Domain.Entities;
using CoreAPI.Domain.ValueObjects.Return;

namespace CoreAPI.Domain.Interfaces.Repositories
{
    public interface IServiceRepository : IRepository<Machine>
    {
        Machine Subscribe(Machine serviceInfo);
        Machine Unsubscribe(Machine serviceInfo);
    }
}
