using ContainerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ContainerManagement.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Containers> Containers { get; set; }
        Task<int> SaveChangesAsync();
    }
}
