using System;
using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Data.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ModifiedAt { get; set; }

        public EntityBase()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = CreatedAt;
        }
    }
}