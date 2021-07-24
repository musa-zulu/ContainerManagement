using ContainerManagement.Domain.Entities;
using ContainerManagement.Persistence;
using ContainerManagement.Service.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Implementation
{
    public class ContainerService : IContainerService
    {
        private readonly IApplicationDbContext _dataContext;
        public ContainerService(IApplicationDbContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<bool> CreateContainerAsync(Containers container)
        {
            _dataContext.Containers.Add(container);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteContainerAsync(Guid containerId)
        {
            var container = await GetContainerByIdAsync(containerId);

            if (container == null)
                return false;

            _dataContext.Containers.Remove(container);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<Containers> GetContainerByIdAsync(Guid containerId)
        {
            return await _dataContext.Containers
               .AsNoTracking()
               .SingleOrDefaultAsync(x => x.ContainerId == containerId);
        }

        public async Task<List<Containers>> GetContainersAsync()
        {
            return await _dataContext.Containers
                  .AsNoTracking()
                  .ToListAsync() ?? new List<Containers>();
        }

        public async Task<bool> UpdateContainerAsync(Containers containerToUpdate)
        {
            _dataContext.Containers.Update(containerToUpdate);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
