using Jobify.Common.Enums;
using Jobify.Common.Extensions;

namespace Jobify.Api.Models.Jobicy;

public class JobModel
{
    public string? JobTitle { get; set; }
    public string? CompanyName { get; set; }
    public string? CompanyLogo { get; set; }
    public List<string>? JobIndustry { get; set; }
    public List<string>? JobType { get; set; }
    public string? JobGeo { get; set; }
    public string? JobLevel { get; set; }
    public string? JobExcerpt { get; set; }
    public string? JobDescription { get; set; }
    public DateTime? PubDate { get; set; }
    public decimal? AnnualSalaryMin { get; set; }
    public decimal? AnnualSalaryMax { get; set; }
    public string? SalaryCurrency { get; set; }
    public string? Url { get; set; }
    public string? JobSlug { get; set; }

    public JobTypes Type
        => JobType.FirstOrDefault().GetValueFromDescription<JobTypes>();

    public CompanyModel Company => new(CompanyName, CompanyLogo);

    public IndustryModel Industry => new(JobIndustry?.FirstOrDefault());
}