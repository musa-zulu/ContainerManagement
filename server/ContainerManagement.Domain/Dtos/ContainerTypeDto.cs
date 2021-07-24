using System;
using System.ComponentModel.DataAnnotations;

namespace ContainerManagement.Domain.Dtos
{
    public class ContainerTypeDto
    {
        public Guid ContainerTypeId { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
