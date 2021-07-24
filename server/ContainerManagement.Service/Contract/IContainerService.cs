using ContainerManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContainerManagement.Service.Contract
{
    public interface IContainerService
    {
        Task<List<Container>> GetContainersAsync();
        Task<bool> CreateContainerAsync(Container container);
        Task<Container> GetContainerByIdAsync(Guid containerId);
        Task<bool> UpdateContainerAsync(Container containerToUpdate);
        Task<bool> DeleteContainerAsync(Guid containerId);
    }
}
