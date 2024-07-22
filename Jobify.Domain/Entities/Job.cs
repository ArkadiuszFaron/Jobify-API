using Jobify.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobify.Domain.Entities;

public sealed class Job : EntityBase
{
    [StringLength(200)]
    public required string Title { get; set; }
    
    public required JobTypes Type { get; set; }
    
    [StringLength(50)]
    public required string Geo { get; set; }
    
    [StringLength(20)]
    public required string Level { get; set; }
    
    [StringLength(500)]
    public required string Excerpt { get; set; }
    
    [Column(TypeName = "nvarchar(max)")]
    public required string Description { get; set; }
    
    [Column(TypeName = "datetime")]
    public DateTime PubDate { get; set; }
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal? AnnualSalaryMin { get; set; }
    
    [Column(TypeName = "decimal(10, 2)")]
    public decimal? AnnualSalaryMax { get; set; }
    
    [StringLength(10)]
    public string? SalaryCurrency { get; set; }
}