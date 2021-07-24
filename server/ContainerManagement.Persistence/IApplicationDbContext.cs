using ContainerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ContainerManagement.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Container> Containers { get; set; }
        DbSet<ContainerType> ContainerTypes { get; set; }
        Task<int> SaveChangesAsync();
    }
}
