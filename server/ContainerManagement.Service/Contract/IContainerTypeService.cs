using ContainerManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Contract
{
    public interface IContainerTypeService
    {
        Task<List<ContainerType>> GetContainerTypesAsync();
        Task<bool> CreateContainerTypeAsync(ContainerType containerType);
        Task<ContainerType> GetContainerTypeByIdAsync(Guid containerTypeId);
        Task<bool> UpdateContainerTypeAsync(ContainerType containerTypeToUpdate);
        Task<bool> DeleteContainerTypeAsync(Guid containerTypeId);
    }
}
