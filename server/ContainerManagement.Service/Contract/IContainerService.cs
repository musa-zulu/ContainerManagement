using ContainerManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Contract
{
    public interface IContainerService
    {
        Task<List<Containers>> GetContainersAsync();
        Task<bool> CreateContainerAsync(Containers container);
        Task<Containers> GetContainerByIdAsync(Guid containerId);
        Task<bool> UpdateContainerAsync(Containers containerToUpdate);
        Task<bool> DeleteContainerAsync(Guid containerId);
    }
}
