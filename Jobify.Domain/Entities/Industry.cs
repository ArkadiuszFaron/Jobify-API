using System.ComponentModel.DataAnnotations;

namespace Jobify.Domain.Entities;

public sealed class Industry : EntityBase
{
    [StringLength(100)]
    public required string Name { get; set; }
    
    [StringLength(50)]
    public required string Code { get; set; }
}