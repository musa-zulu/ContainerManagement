using System;
using System.ComponentModel.DataAnnotations;

namespace ContainerManagement.Domain.Entities
{
    public class Container
    {
        [Key]
        public Guid ContainerId { get; set; }
        [Required]
        public string ContainerNo { get; set; }        
        public string Color { get; set; }
        public Guid ContainerTypeId { get; set; }
        public virtual ContainerType ContainerType { get; set; }
    }
}
