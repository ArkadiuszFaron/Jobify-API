using System.ComponentModel.DataAnnotations;

namespace Jobify.Domain.Entities;

public sealed class Company : EntityBase
{
    [StringLength(200)]
    public required string Name { get; set; }
    
    [StringLength(100)]
    public required string Logo { get; set; }
}