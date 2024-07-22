using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Jobify.Domain.Repositories;

public class DapperRepository(string? connectionString) : IDapperRepository
{
    public async Task<IEnumerable<T>> Query<T>(string query, object? parameters = null)
    {
        using var connection = Connection;
        return await connection.QueryAsync<T>(query, parameters);
    }

    public async Task<T?> QueryFirstOrDefault<T>(string query, object? parameters = null)
    {
        using var connection = Connection;
        return await connection.QueryFirstOrDefaultAsync<T>(query, parameters);
    }

    public async Task<Guid> QuerySingle(string query, object? parameters = null)
    {
        using var connection = Connection;
        return await connection.QuerySingleAsync<Guid>(query, parameters);
    }

    public async Task<T?> ExecuteScalar<T>(string query, object? parameters = null)
    {
        using var connection = Connection;
        return await connection.ExecuteScalarAsync<T>(query, parameters);
    }

    public async Task<int> Execute(string query, object? parameters = null)
    {
        using var connection = Connection;
        return await connection.ExecuteAsync(query, parameters);
    }

    public async Task Insert<T>(T model) where T : class
    {
        using var connection = Connection;
        await connection.InsertAsync(model);
    }

    public async Task Update<T>(T model) where T : class
    {
        using var connection = Connection;
        await connection.UpdateAsync(model);
    }

    public async Task DeleteAll<T>() where T : class
    {
        using var connection = Connection;
        await connection.DeleteAllAsync<T>();
    }

    private IDbConnection Connection => new SqlConnection(connectionString);
}

public interface IDapperRepository
{
    Task<IEnumerable<T>> Query<T>(string query, object? parameters = null);
    Task<T?> QueryFirstOrDefault<T>(string query, object? parameters = null);
    Task<Guid> QuerySingle(string query, object? parameters = null);
    Task<T?> ExecuteScalar<T>(string query, object? parameters = null);
    Task<int> Execute(string query, object? parameters = null);
    Task Insert<T>(T model) where T : class;
    Task Update<T>(T model) where T : class;
    Task DeleteAll<T>() where T : class;
}