using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContainerManagement.Domain.Entities
{
    public class ContainerType
    {
        [Key]
        public Guid ContainerTypeId { get; set; }
        [Required]
        public string Type { get; set; }
        [JsonIgnore]
        public virtual List<Container> Containers { get; set; }
    }
}
