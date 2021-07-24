using System;

namespace ContainerManagement.Domain.Dtos
{
    public class ContainerDto
    {
        public Guid ContainerId { get; set; }
        public string ContainerNo { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}
