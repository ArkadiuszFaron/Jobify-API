namespace Jobify.Api.Models.Jobicy;

public class CompanyModel(string? name, string? logo)
{
    public string? Name { get; set; } = name;
    public string? Logo { get; set; } = logo;
}