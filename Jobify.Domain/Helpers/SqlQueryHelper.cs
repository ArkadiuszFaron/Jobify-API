namespace Jobify.Domain.Helpers;

public static class SqlQueryHelper
{
    public static string GetCompanies
        => @"SELECT
                Id,
                Name,
                Logo
            FROM
                Companies
            ORDER BY
                CreatedAt DESC";
    
    public static string GetCompanyById
        => @"SELECT
                Id,
                Name,
                Logo
            FROM
                Companies
            WHERE
                Id = @id";
}