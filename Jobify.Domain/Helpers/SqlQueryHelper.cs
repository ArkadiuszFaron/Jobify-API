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
    
    public static string UpdateCompany =>
        @"UPDATE Companies
          SET Name = @name,
              Logo = @logo,
              ModifiedAt = @modifiedAt
          WHERE Id = @id";
    
    public static string DeleteCompany =>
        @"DELETE FROM Companies
          WHERE Id = @id";
    
    public static string GetIndustries
        => @"SELECT
                Id,
                Name,
                Code
            FROM
                Industries
            ORDER BY
                Id";
    
    public static string GetIndustryByName
        => @"SELECT
                Id,
                Name,
                Code
            FROM
                Industries
            WHERE
                Name = @name";
}