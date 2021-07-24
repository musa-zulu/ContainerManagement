using ContainerManagement.Domain.Entities;
using ContainerManagement.Persistence;
using ContainerManagement.Service.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Implementation
{
    public class ContainerTypeService : IContainerTypeService
    {
        private readonly IApplicationDbContext _dataContext;
        public ContainerTypeService(IApplicationDbContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<bool> CreateContainerTypeAsync(ContainerType containerType)
        {
            _dataContext.ContainerTypes.Add(containerType);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteContainerTypeAsync(Guid containerTypeId)
        {
            var containerType = await GetContainerTypeByIdAsync(containerTypeId);

            if (containerType == null)
                return false;

            _dataContext.ContainerTypes.Remove(containerType);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<ContainerType> GetContainerTypeByIdAsync(Guid containerTypeId)
        {
            return await _dataContext.ContainerTypes
              .AsNoTracking()
              .SingleOrDefaultAsync(x => x.ContainerTypeId == containerTypeId);
        }

        public async Task<List<ContainerType>> GetContainerTypesAsync()
        {
            return await _dataContext.ContainerTypes
                  .AsNoTracking()
                  .ToListAsync() ?? new List<ContainerType>();
        }

        public async Task<bool> UpdateContainerTypeAsync(ContainerType containerTypeToUpdate)
        {
            _dataContext.ContainerTypes.Update(containerTypeToUpdate);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
