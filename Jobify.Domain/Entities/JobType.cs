using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jobify.Domain.Entities;

public class JobType : EntityBase
{
    [StringLength(50)]
    public required string Name { get; set; }

    [DefaultValue(true)]
    public required bool IsActive { get; set; }
}