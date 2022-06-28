using Dapper;
using Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Data;

namespace Employee.Repositories
{
public abstract class BaseRepository
{
    private readonly IConfiguration _configuration;
    protected readonly IHttpContextAccessor _httpContextAccessor;
    protected BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

        protected IDbConnection CreateConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected DataTable GetDataTable(string query, DynamicParameters param)
    {
        try
        {
            DataTable dt = new DataTable();
            using (var connection = CreateConnection())
            {
                var reader = connection.ExecuteReader(query, param, commandType: CommandType.StoredProcedure);
                while (!reader.IsClosed)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
    protected DataSet GetDataSet(string query, DynamicParameters param)
    {
        try
        {
            DataSet ds = new DataSet();
            using (var connection = CreateConnection())
            {
                int index = 1;
                var reader = connection.ExecuteReader(query, param, commandType: CommandType.StoredProcedure);
                while (!reader.IsClosed)
                {
                    DataTable dt = new DataTable();
                    dt.TableName = "Table" + index;
                    dt.Load(reader);
                    ds.Tables.Add(dt);
                    index++;
                }
            }
            int t = ds.Tables.Count;
            return ds;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public static X Get_dataTable_to_json<X>(DataTable dt)
    {

        string JSONString = string.Empty;
        JSONString = JsonConvert.SerializeObject(dt);
        X pm = JsonConvert.DeserializeObject<X>(JSONString);
        return pm;
    }

    public Response GetResponse(object data, int status = 1, string Message = "Success")
    {
        Response res = new Response();
        res.status = status;
        res.message = Message;
        res.data = data;
        return res;
    }

    public Response GetError(string ErrorMessage)
    {
        Response res = new Response();
        res.status = 0;
        res.message = ErrorMessage;
        res.data = null;
        return res;
    }

    }
}
