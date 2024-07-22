using System.ComponentModel;

namespace Jobify.Common.Enums;

public enum JobTypes
{
    [Description("full-time")]
    FullTime = 1,
    
    [Description("contract")]
    Contract = 2,
    
    [Description("part-time")]
    PartTime = 3,
    
    [Description("internship")]
    Internship = 4
}