using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Domain.Entities;

public abstract class EntityBase : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
        
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    public DateTime? ModifiedAt { get; set; }
}

public interface IEntity
{
    int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}