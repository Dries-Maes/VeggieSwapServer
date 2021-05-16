using System;
using System.ComponentModel.DataAnnotations;

namespace VeggieSwapServer.Data.Entities
{
    public abstract class EntityBase
    {
        [Required]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public EntityBase()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = CreatedAt;
        }
    }
}