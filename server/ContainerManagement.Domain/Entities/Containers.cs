using System;
using System.ComponentModel.DataAnnotations;

namespace ContainerManagement.Domain.Entities
{
    public class Containers
    {
        [Key]
        public Guid ContainerId { get; set; }
        public string ContainerNo { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}
