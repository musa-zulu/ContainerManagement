using System;
using System.ComponentModel.DataAnnotations;

namespace ContainerManagement.Domain.Dtos
{
    public class ContainerDto
    {
        public Guid ContainerId { get; set; }
        [Required]
        public string ContainerNo { get; set; }        
        public string Color { get; set; }
        public Guid ContainerTypeId { get; set; }
    }
}
