using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AM.Code.Secrets
{
    public class ARM
    {
        public ARM()
        {
            Console.WriteLine("ARM Testing Code!");


            //#region WebChat.Presistence.Ado;
            //public class AdoNetDatabase<T> : IDisposable where T : new()
            //{
            //    private readonly string? connectionString;
            //    private SqlConnection connection;

            //    public AdoNetDatabase(IAppSettings appSettings)
            //    {
            //        this.connectionString = appSettings.SqlConnectionString ?? throw new ArgumentNullException("Sql Server Database Connection is Null");
            //        this.connection = new SqlConnection(connectionString);
            //        this.connection.Open();
            //    }

            //    public void InsertData(string tableName, params SqlParameter[] parameters)
            //    {
            //        string parameterNames = string.Join(", ", parameters.Select(p => p.ParameterName));
            //        string parameterValues = string.Join(", ", parameters.Select(p => $"@{p.ParameterName}"));

            //        using SqlCommand command = new(
            //            @$"
            //            INSERT INTO {tableName} 
            //            ({parameterNames}) 
            //            VALUES ({parameterValues})", connection);
            //        command.Parameters.AddRange(parameters);
            //        command.ExecuteNonQuery();
            //    }

            //    public void UpdateData(string tableName, int entityId, params SqlParameter[] parameters)
            //    {
            //        string setClause = string.Join(", ", parameters.Select(p => $"{p.ParameterName}=@{p.ParameterName}"));
            //        using SqlCommand command = new($"UPDATE {tableName} SET {setClause} WHERE id=@EntityId", connection);
            //        command.Parameters.AddWithValue("@EntityId", entityId);
            //        command.Parameters.AddRange(parameters);
            //        command.ExecuteNonQuery();
            //    }

            //    public List<T> SelectData(string tableName, params SqlParameter[] parameters)
            //    {
            //        List<T> data = [];

            //        string query = @$"SELECT * FROM {tableName} ORDER BY id";
            //        if (parameters.Length > 0)
            //        {
            //            query += " WHERE " + string.Join(" AND ", parameters.Select(p => $"{p.ParameterName} = @{p.ParameterName}"));
            //        }

            //        using (SqlCommand command = new(query, connection))
            //        {
            //            using SqlDataReader reader = command.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                T instance = new();
            //                MapDataReaderToEntity(reader, instance);
            //                data.Add(instance);
            //            }
            //        }

            //        return data;
            //    }

            //    public List<T> SelectData(string tableName, string[] selectedColumns = null, params object[] filters)
            //    {
            //        List<T> data = [];

            //        string columnList = (selectedColumns != null && selectedColumns.Length > 0)
            //            ? string.Join(", ", selectedColumns)
            //            : "*";

            //        string query = @$"SELECT {columnList} FROM {tableName}";

            //        if (filters != null && filters.Length > 0)
            //        {
            //            query += " WHERE ";

            //            List<string> filterConditions = [];

            //            for (int i = 0; i < filters.Length; i++)
            //            {
            //                if (filters[i] is SqlParameter parameter)
            //                {
            //                    filterConditions.Add($"{parameter.ParameterName} = @{parameter.ParameterName}");
            //                }
            //                else if (filters[i] is List<int> ids)
            //                {
            //                    filterConditions.Add($"UserId IN ({string.Join(", ", ids)})");
            //                }
            //                else
            //                {
            //                    throw new ArgumentException($"Unsupported filter type: {filters[i]?.GetType().Name}");
            //                }
            //            }

            //            query += string.Join(" AND ", filterConditions);
            //        }

            //        query += " ORDER BY UserId";

            //        using (SqlCommand command = new(query, connection))
            //        {
            //            foreach (var filter in filters.OfType<SqlParameter>())
            //            {
            //                command.Parameters.AddWithValue(filter.ParameterName, filter.Value);
            //            }

            //            using SqlDataReader reader = command.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                T instance = new();
            //                MapDataReaderToEntity(reader, instance);
            //                data.Add(instance);
            //            }
            //        }

            //        return data;
            //    }



            //    public List<T> SelectPageData(string tableName, int pageSize, int pageNumber)
            //    {
            //        int startRowIndex = (pageNumber - 1) * pageSize;
            //        List<T> data = [];

            //        using (SqlCommand command = new(@$"
            //            SELECT * FROM {tableName} 
            //            ORDER BY id 
            //            OFFSET {startRowIndex} 
            //            ROWS FETCH NEXT {pageSize} 
            //            ROWS ONLY", connection))
            //        {
            //            using SqlDataReader reader = command.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                T instance = new();
            //                MapDataReaderToEntity(reader, instance);
            //                data.Add(instance);
            //            }
            //        }

            //        return data;
            //    }

            //    internal static void MapDataReaderToEntity(SqlDataReader reader, T entity)
            //    {
            //        for (int i = 0; i < reader.FieldCount; i++)
            //        {
            //            var propertyName = reader.GetName(i);
            //            var property = typeof(T).GetProperty(propertyName);

            //            if (property != null && property.CanWrite)
            //            {
            //                var value = reader[i];
            //                if (value != DBNull.Value)
            //                {
            //                    property.SetValue(entity, value);
            //                }
            //            }
            //        }
            //    }

            //    public T GetSingleRow<T>(string tableName, string[] columnNames, string whereCondition = "1=1") where T : new()
            //    {
            //        // Build the SQL query
            //        string columns = string.Join(", ", columnNames);
            //        string query = $"SELECT {columns} FROM {tableName} WHERE {whereCondition}";

            //        // Initialize the result variable of type T
            //        T result = new();

            //        using (SqlCommand command = new(query, connection))
            //        {
            //            using SqlDataReader reader = command.ExecuteReader();
            //            // Check if there are rows
            //            if (reader.Read())
            //            {
            //                // Map each column to the corresponding property of T
            //                for (int i = 0; i < columnNames.Length; i++)
            //                {
            //                    string columnName = columnNames[i];
            //                    object columnValue = reader[columnName];

            //                    // Get PropertyInfo for the current property
            //                    PropertyInfo propertyInfo = typeof(T).GetProperty(columnName);

            //                    if (propertyInfo != null)
            //                    {
            //                        if (columnValue == DBNull.Value)
            //                        {
            //                            // Handle DBNull value, set default values or handle as needed
            //                            propertyInfo.SetValue(result, null);
            //                        }
            //                        else
            //                        {
            //                            // Handle value type conversion (e.g., int to string)
            //                            propertyInfo.SetValue(result, Convert.ChangeType(columnValue, propertyInfo.PropertyType));
            //                        }
            //                    }
            //                }
            //            }
            //        }

            //        return result;
            //    }

            //    public List<T> GetRows<T>(string tableName, string[] columnNames, string whereCondition = "1=1") where T : new()
            //    {
            //        // Build the SQL query
            //        string columns = string.Join(", ", columnNames);
            //        string query = $"SELECT {columns} FROM {tableName} WHERE {whereCondition}";

            //        // Initialize the result variable as a list of type T
            //        List<T> results = [];

            //        using (SqlCommand command = new SqlCommand(query, connection))
            //        {
            //            using SqlDataReader reader = command.ExecuteReader();
            //            // Check if there are rows
            //            while (reader.Read())
            //            {
            //                // Create a new instance of T for each row
            //                T result = new();

            //                // Map each column to the corresponding property of T
            //                for (int i = 0; i < columnNames.Length; i++)
            //                {
            //                    string columnName = columnNames[i];
            //                    object columnValue = reader[columnName];

            //                    // Get PropertyInfo for the current property
            //                    PropertyInfo propertyInfo = typeof(T).GetProperty(columnName);

            //                    if (propertyInfo != null)
            //                    {
            //                        if (columnValue == DBNull.Value)
            //                        {
            //                            // Handle DBNull value, set default values or handle as needed
            //                            propertyInfo.SetValue(result, null);
            //                        }
            //                        else
            //                        {
            //                            // Handle value type conversion (e.g., int to string)
            //                            propertyInfo.SetValue(result, Convert.ChangeType(columnValue, propertyInfo.PropertyType));
            //                        }
            //                    }
            //                }

            //                // Add the populated instance to the results list
            //                results.Add(result);
            //            }
            //        }

            //        return results;
            //    }



            //    public void CloseConnection()
            //    {
            //        if (connection.State == ConnectionState.Open)
            //        {
            //            connection.Close();
            //        }
            //    }

            //    public void Dispose()
            //    {
            //        Dispose(true);
            //        GC.SuppressFinalize(this);
            //    }

            //    protected virtual void Dispose(bool disposing)
            //    {
            //        if (disposing)
            //        {
            //            if (connection != null)
            //            {
            //                connection.Dispose();
            //                connection = null;
            //            }
            //        }
            //    }

            //    ~AdoNetDatabase()
            //    {
            //        Dispose(false);
            //    }
            //} 
            //#endregion

            //namespace WebChat.Presistence.DBContext;

            //public class WebchatDBContext(DbContextOptions<WebchatDBContext> options) : DbContext(options), IWebchatDBContext
            //{
            //    public DbSet<UserDetailsEntity> UserDetails { get; set; }
            //    public DbSet<GroupUsersEntity> GroupUsers { get; set; }
            //    public DbSet<GroupEntity> Group { get; set; }
            //    public DbSet<SubGroupEntity> SubGroup { get; set; }
            //    public DbSet<MessageEntity> Message { get; set; }
            //    public DbSet<LoginInUserEntity> LoginInUser { get; set; }

            //    protected override void OnModelCreating(ModelBuilder modelBuilder)
            //    {
            //        modelBuilder.ApplyConfiguration(new UserConfiguration());
            //        modelBuilder.ApplyConfiguration(new GroupConfiguration());
            //        modelBuilder.ApplyConfiguration(new MessageConfiguration());
            //        modelBuilder.ApplyConfiguration(new SubGroupConfiguration());
            //        base.OnModelCreating(modelBuilder);
            //    }

            //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //    {
            //        optionsBuilder.UseLazyLoadingProxies();
            //        base.OnConfiguring(optionsBuilder);
            //    }

            //}

            //#region NameSpace
            //using System.Drawing.Printing;
            //using System.Linq.Dynamic.Core;
            //using WebChat.Redis;
            //namespace WebChat.Presistence.Repositories.BaseRepository;

            //#endregion

            //#region BaseRepository
            //#region BaseRepository Summary Info
            ///// <summary>
            ///// Base repository for facilitating communication between entities and the database.
            ///// This base repository also aids in performing generic operations for all repositories associated with entities.
            ///// Developer: ALI RAZA MUSHTAQ
            ///// Date: 30-Jan-2024
            ///// alisaivi786@gmail.com
            ///// </summary>
            ///// <typeparam name="T"></typeparam>
            ///// <param name="context"></param>
            ///// <param name="configuration"></param>
            ///// <param name="httpContextAccessor"></param> 
            //#endregion
            //public class BaseRepository<T>(
            //    WebchatDBContext context,
            //    IConfiguration configuration,
            //    IHttpContextAccessor httpContextAccessor,
            //    IAppSettings appSettings) : IBaseRepository<T> where T : class
            //{
            //    #region Class Level Properties
            //    private readonly WebchatDBContext _context = context;// ?? throw new ArgumentNullException(nameof(context));
            //    private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            //    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            //    private readonly IAppSettings _appSettings = appSettings;// ?? throw new ArgumentNullException(nameof(appSettings));
            //    #endregion



            //    #region Entity Table
            //    public DbSet<T> Table { get; set; } = context.Set<T>();
            //    #endregion

            //    #region AddAsync
            //    #region AddAsync Summary
            //    /// <summary>
            //    /// Add Entity into Database Using AddAsync Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="entity"></param>
            //    /// <returns>Return Db Operation Response</returns> 
            //    #endregion
            //    public async Task<DbResponse<T>> AddAsync(T entity, CancellationToken cancellationToken = default)
            //    {
            //        try
            //        {
            //            // Check for cancellation before starting the operation
            //            if (cancellationToken.IsCancellationRequested)
            //            {
            //                var genericError = new ErrorModel { Id = "Cancellation", Message = "Operation canceled." };
            //                return new DbResponse<T>
            //                {
            //                    Code = DbCodeEnums.Canceled,
            //                    MsgCode = DbMessageEnums.CanceledOperation,
            //                    Error = [genericError]
            //                };
            //            }

            //            var e = Table.Add(entity);
            //            await _context.SaveChangesAsync(cancellationToken);

            //            var dbResponse = new DbResponse<T>()
            //            {
            //                Data = e.Entity,
            //                MsgCode = DbMessageEnums.Inserted,
            //                Code = DbCodeEnums.Success
            //            };

            //            return dbResponse;
            //        }
            //        catch (OperationCanceledException ex)
            //        {
            //            var genericError = new ErrorModel { Id = "Cancellation", Message = ex.Message };
            //            return new DbResponse<T>
            //            {
            //                Code = DbCodeEnums.Canceled,
            //                MsgCode = DbMessageEnums.CanceledOperation,
            //                Error = [genericError]
            //            };
            //        }
            //        catch (Exception ex)
            //        {
            //            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            //            return new DbResponse<T>
            //            {
            //                Code = DbCodeEnums.DbException,
            //                MsgCode = DbMessageEnums.FailedPresistence,
            //                Error = [genericError]
            //            };
            //        }
            //    }

            //    #endregion

            //    #region AddMultipleAsync
            //    #region AddMultipleAsync Summary
            //    /// <summary>
            //    /// Add Bulk Insertion into Database using AddMultipleAsync Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="entities"></param>
            //    /// <returns>Return Db Operation Response</returns> 
            //    #endregion
            //    public async Task<DbResponse<List<T>>> AddMultipleAsync(List<T> entities, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        try
            //        {
            //            Table.AddRange(entities);
            //            await _context.SaveChangesAsync();

            //            var response = new DbResponse<List<T>>
            //            {
            //                Data = entities.ToList(),
            //                MsgCode = DbMessageEnums.BulkInserted,
            //                Code = DbCodeEnums.Success
            //            };
            //            return response;
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle generic exception
            //            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            //            return new DbResponse<List<T>>
            //            {
            //                Code = DbCodeEnums.DbException,
            //                MsgCode = DbMessageEnums.FailedPresistence,
            //                Error = [genericError]
            //            };
            //        }
            //        #endregion
            //    }
            //    #endregion

            //    #region GetAll
            //    #region GetAll Summary
            //    /// <summary>
            //    /// Get All IQueryable Result Data of Entity using GetAll Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <returns>List of Entity Response</returns> 
            //    #endregion
            //    public IQueryable<T> GetAll()
            //    {
            //        return Table;
            //    }
            //    #endregion

            //    #region Predicate GetAll with where Predicate
            //    #region GetAll Summary
            //    /// <summary>
            //    /// Get All IQueryable Result Data of Entity with predicate using GetAll Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="predicate"></param>
            //    /// <returns>Return List of Entity Response</returns> 
            //    #endregion
            //    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            //    {
            //        return Table.Where(predicate);
            //    }
            //    #endregion

            //    #region GetAvailableAsync
            //    #region GetAvailableAsync Summary
            //    /// <summary>
            //    /// Get Entity by using Id using GetAvailableAsync Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="Id"></param>
            //    /// <returns>Entity Result</returns> 
            //    #endregion
            //    public async Task<T?> GetAvailableAsync(long Id, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        var response = await Table.FindAsync(Id);
            //        return response;
            //        #endregion
            //    }
            //    #endregion

            //    #region GetAvailablePredicateAsync
            //    #region GetAvailablePredicateAsync Summary
            //    /// <summary>
            //    /// Get Entity by using GetAvailablePredicateAsync
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 16-Feb-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="predicate"></param>
            //    /// <param name="cancellationToken"></param>
            //    /// <returns>entity object</returns>
            //    #endregion
            //    public async Task<T?> GetAvailablePredicateAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        IQueryable<T> query = Table;

            //        if (predicate != null)
            //        {
            //            query = query.Where(predicate);
            //        }
            //        var entity = await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);

            //        return entity;
            //        #endregion
            //    }
            //    #endregion

            //    #region GetByIdAsync
            //    #region GetByIdAsync Summary
            //    /// <summary>
            //    /// Get Entity by using Id using GetAvailableAsync Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="id"></param>
            //    /// <returns>Return Entity Result</returns>  
            //    #endregion
            //    public async Task<DbResponse<T>> GetByIdAsync(long id, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        try
            //        {
            //            var result = await GetAvailableAsync(id);

            //            if (result != null)
            //            {
            //                var response = new DbResponse<T>
            //                {
            //                    Data = result,
            //                    MsgCode = DbMessageEnums.Fetch,
            //                    Code = DbCodeEnums.Success
            //                };
            //                return response;
            //            }
            //            return new DbResponse<T>()
            //            {
            //                MsgCode = DbMessageEnums.EntityNotFound,
            //                Code = DbCodeEnums.Success
            //            };
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle generic exception
            //            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            //            return new DbResponse<T>
            //            {
            //                Code = DbCodeEnums.DbException,
            //                MsgCode = DbMessageEnums.FailedPresistence,
            //                Error = [genericError]
            //            };
            //        }
            //        #endregion
            //    }
            //    #endregion

            //    #region RemoveRangeAsync
            //    #region RemoveRangeAsync Summary
            //    /// <summary>
            //    /// Remove Range of Entities using RemoveRangeAsync Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="entities"></param>
            //    /// <returns></returns>
            //    /// <exception cref="NotImplementedException"></exception> 
            //    #endregion
            //    public Task<DbResponse<List<T>>> RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        throw new NotImplementedException();
            //        #endregion
            //    }
            //    #endregion

            //    #region UpdateAsync
            //    #region UpdateAsync Summary
            //    /// <summary>
            //    /// Update Single Entity using UpdateAsync Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="entity"></param>
            //    /// <param name="updatedBy"></param>
            //    /// <returns>Return Db Operation Response</returns> 
            //    #endregion
            //    public async Task<DbResponse<T>> UpdateAsync(T entity, long updatedBy, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        if (entity is BaseEntity baseEntity)
            //        {
            //            baseEntity.ModifiedBy = updatedBy;
            //            baseEntity.UtcDateModified = DateTime.UtcNow;
            //        }

            //        _ = Table.Attach(entity);
            //        _context.Entry(entity).State = EntityState.Modified;
            //        await _context.SaveChangesAsync();
            //        return new DbResponse<T> { Data = entity, MsgCode = DbMessageEnums.Updated, Code = DbCodeEnums.Success };
            //        #endregion
            //    }
            //    #endregion

            //    #region UpdateMultipleAsync
            //    #region UpdateMultipleAsync Summary
            //    /// <summary>
            //    /// Update Range of  Entities using UpdateMultipleAsync Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="entities"></param>
            //    /// <param name="updatedBy"></param>
            //    /// <returns></returns> 
            //    #endregion
            //    public async Task<DbResponse<List<T>>> UpdateMultipleAsync(IEnumerable<T> entities, long updatedBy, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        try
            //        {
            //            foreach (var entity in entities)
            //            {
            //                if (entity is BaseEntity baseEntity)
            //                {
            //                    baseEntity.ModifiedBy = updatedBy;
            //                    baseEntity.UtcDateModified = DateTime.UtcNow;
            //                }
            //            }

            //            _ = Table;
            //            Table.UpdateRange(entities);
            //            await _context.SaveChangesAsync();

            //            var response = new DbResponse<List<T>>
            //            {
            //                Data = entities.ToList(),
            //                MsgCode = DbMessageEnums.BulkUpdated,
            //                Code = DbCodeEnums.Success
            //            };

            //            return response;
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle the exception, log it, or perform any necessary actions
            //            var errorResponse = new DbResponse<List<T>>
            //            {
            //                MsgCode = DbMessageEnums.FailedPresistence,
            //                Code = DbCodeEnums.DbException,
            //                Error = [new ErrorModel { Id = "UpdateMultipleAsync", Message = ex.Message }]
            //            };

            //            return errorResponse;
            //        }
            //        #endregion
            //    }
            //    #endregion

            //    #region DeleteAsync
            //    #region DeleteAsync Summary
            //    /// <summary>
            //    /// Delete Entity by Id using DeleteAsync Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="id"></param>
            //    /// <param name="deletedBy"></param>
            //    /// <returns></returns> 
            //    #endregion
            //    public async Task<DbResponse<T>> DeleteAsync(long id, long deletedBy, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        var entity = await GetByIdAsync(id);
            //        var result = await UpdateAsync(entity.Data, deletedBy);
            //        if ((int)result.Code == (int)DbCodeEnums.Success)
            //        {
            //            return new DbResponse<T> { Data = entity.Data, MsgCode = DbMessageEnums.Deleted, Code = DbCodeEnums.Success };
            //        }
            //        return new DbResponse<T> { Data = entity.Data, MsgCode = DbMessageEnums.FailedPresistence, Code = DbCodeEnums.Failed };
            //        #endregion

            //    }
            //    #endregion

            //    #region DeletePermanently
            //    #region DeletePermanently Summary
            //    /// <summary>
            //    /// DeletePermanently by Providing Entity Record using DeletePermanently Func
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 30-Jan-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="entity"></param>
            //    /// <returns>Return Db Operation Response</returns> 
            //    #endregion
            //    public async Task<DbResponse<bool>> DeletePermanentlyAsync(T entity, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        try
            //        {
            //            Table.Remove(entity);
            //            await _context.SaveChangesAsync();

            //            return new DbResponse<bool> { Data = true, Code = DbCodeEnums.Success, MsgCode = DbMessageEnums.Deleted };
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle generic exception
            //            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            //            return new DbResponse<bool>
            //            {
            //                Data = false,
            //                Code = DbCodeEnums.DbException,
            //                MsgCode = DbMessageEnums.FailedPresistence,
            //                Error = [genericError]
            //            };
            //        }
            //        #endregion
            //    }


            //    #endregion

            //    #region DeleteByPredicateAsync
            //    #region DeleteByPredicateAsync Summary
            //    /// <summary>
            //    /// Delete Entity by using a predicate
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 16-Feb-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="predicate"></param>
            //    /// <param name="cancellationToken"></param>
            //    /// <returns>Boolean indicating whether the entity was deleted</returns>
            //    #endregion
            //    public async Task<DbResponse<bool>> DeleteByPredicateAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
            //    {
            //        #region ...
            //        try
            //        {
            //            IQueryable<T> query = Table;

            //            if (predicate != null)
            //            {
            //                query = query.Where(predicate);
            //            }

            //            var entity = await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);

            //            if (entity != null)
            //            {
            //                context.Remove(entity);
            //                await context.SaveChangesAsync(cancellationToken);
            //                return new DbResponse<bool> { Data = true, Code = DbCodeEnums.Success, MsgCode = DbMessageEnums.Deleted };
            //            }
            //            return new DbResponse<bool> { Data = false, Code = DbCodeEnums.Failed, MsgCode = DbMessageEnums.Failed };
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle generic exception
            //            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            //            return new DbResponse<bool>
            //            {
            //                Data = false,
            //                Code = DbCodeEnums.DbException,
            //                MsgCode = DbMessageEnums.FailedPresistence,
            //                Error = [genericError]
            //            };
            //        }

            //        #endregion
            //    }
            //    #endregion


            //    #region ExecuteSqlQueryAsync
            //    #region ExecuteSqlQueryAsync Summary
            //    /// <summary>
            //    /// ExecuteSqlQueryAsync for Executing Raw Queries
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 05-Feb-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="sqlQuery"></param>
            //    /// <param name="parameters"></param>
            //    /// <returns></returns> 
            //    #endregion
            //    public async Task<IEnumerable<T>> ExecuteSqlQueryAsync(string sqlQuery, CancellationToken cancellationToken = default, params object[] parameters)
            //    {
            //        var isolationLevel = IsolationLevel.ReadUncommitted; // Set the desired isolation level

            //        await using var transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
            //        try
            //        {
            //            var result = await _context.Set<T>().FromSqlRaw(sqlQuery, parameters).ToListAsync();
            //            await transaction.CommitAsync();
            //            return result;
            //        }
            //        catch (Exception)
            //        {
            //            await transaction.RollbackAsync();
            //            throw;
            //        }
            //    }
            //    #endregion

            //    #region ExecuteSqlNonQueryAsync
            //    #region ExecuteSqlNonQueryAsync Summary
            //    /// <summary>
            //    /// ExecuteSqlNonQueryAsync for Executing Non-Query Raw SQL Queries (INSERT, UPDATE, DELETE)
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 05-Feb-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="sqlQuery"></param>
            //    /// <param name="parameters"></param>
            //    /// <returns></returns> 
            //    #endregion
            //    public async Task<int> ExecuteSqlNonQueryAsync(string sqlQuery, CancellationToken cancellationToken = default, params object[] parameters)
            //    {
            //        var isolationLevel = IsolationLevel.ReadUncommitted; // Set the desired isolation level

            //        await using var transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
            //        try
            //        {
            //            var result = await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);
            //            await transaction.CommitAsync();
            //            return result;
            //        }
            //        catch (Exception)
            //        {
            //            await transaction.RollbackAsync();
            //            throw;
            //        }
            //    }
            //    #endregion

            //    #region InsertWithSqlAsync
            //    #region InsertWithSqlAsync Summary
            //    /// <summary>
            //    /// Insert records into the database using a raw SQL query.
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 05-Feb-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="sqlQuery"></param>
            //    /// <param name="parameters"></param>
            //    /// <returns></returns> 
            //    #endregion
            //    public async Task<DbResponse<List<T>>> InsertWithSqlAsync(string sqlQuery, CancellationToken cancellationToken = default, params object[] parameters)
            //    {
            //        try
            //        {
            //            var result = await ExecuteSqlNonQueryAsync(sqlQuery, cancellationToken, parameters);
            //            return new DbResponse<List<T>>
            //            {
            //                MsgCode = DbMessageEnums.Inserted,
            //                Code = result > 0 ? DbCodeEnums.Success : DbCodeEnums.Failed
            //            };
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle generic exception
            //            var genericError = new ErrorModel { Id = "GenericError", Message = ex.Message };
            //            return new DbResponse<List<T>>
            //            {
            //                Code = DbCodeEnums.DbException,
            //                MsgCode = DbMessageEnums.FailedPresistence,
            //                Error = [genericError]
            //            };
            //        }
            //    }
            //    #endregion

            //    #region SelectWithSqlAsync
            //    #region SelectWithSqlAsync Summary
            //    /// <summary>
            //    /// Select records from the database using a raw SQL query.
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 05-Feb-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="sqlQuery"></param>
            //    /// <param name="parameters"></param>
            //    /// <returns></returns> 
            //    #endregion
            //    public async Task<IEnumerable<T>> SelectWithSqlAsync(string sqlQuery, CancellationToken cancellationToken = default, params object[] parameters)
            //    {
            //        try
            //        {
            //            var result = await ExecuteSqlQueryAsync(sqlQuery, cancellationToken, parameters);
            //            return result;
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle exception or log it
            //            throw;
            //        }
            //    }
            //    #endregion

            //    #region FilterWithSqlAsync
            //    #region FilterWithSqlAsync Summary
            //    /// <summary>
            //    /// Filter records from the database using a raw SQL query with parameters.
            //    /// Developer: ALI RAZA MUSHTAQ
            //    /// Date: 05-Feb-2024
            //    /// alisaivi786@gmail.com
            //    /// </summary>
            //    /// <param name="sqlQuery"></param>
            //    /// <param name="parameters"></param>
            //    /// <returns></returns> 
            //    #endregion
            //    public async Task<IEnumerable<T>> FilterWithSqlAsync(string sqlQuery, CancellationToken cancellationToken = default, params object[] parameters)
            //    {
            //        try
            //        {
            //            var result = await ExecuteSqlQueryAsync(sqlQuery, cancellationToken, parameters);
            //            return result;
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle exception or log it
            //            throw ex;
            //        }
            //    }

            //    #endregion


            //    public async Task<PageBaseResponse<List<T>>> GetPagedAsync(int page, int pageSize, Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
            //    {
            //        IQueryable<T> query = Table;

            //        if (predicate != null)
            //        {
            //            query = query.Where(predicate);
            //        }


            //        // Order by Id in descending order if the entity has an 'Id' property
            //        var entityType = typeof(T);
            //        var idProperty = entityType.GetProperty("Id");

            //        if (idProperty != null)
            //        {
            //            query = query.AsQueryable().OrderBy($"{idProperty.Name} descending");
            //        }

            //        int totalCount = await query.CountAsync();

            //        var items = await query
            //            .Skip((page - 1) * pageSize)
            //            .Take(pageSize)
            //            .ToListAsync();

            //        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            //        return new PageBaseResponse<List<T>>
            //        {
            //            List = items,
            //            PageNo = page,
            //            TotalPage = totalPages,
            //            TotalCount = totalCount

            //        };
            //    }

            //}
            //#endregion




            //using JwtService.Interface;
            //using WebChat.Redis;

            //namespace WebChat.Presistence.UnitOfWork;

            ///// <summary>
            ///// UnitOfWork provide base to communicate with database with same context.
            ///// Developer: ALI RAZA MUSHTAQ
            ///// Date: 30-Jan-2024
            ///// alisaivi786@gmail.com
            ///// </summary>
            //public class UnitOfWork : IUnitOfWork, IDisposable
            //{
            //    private readonly WebchatDBContext Context;
            //    private readonly IConfiguration Configuration;
            //    private readonly IHttpContextAccessor HttpContextAccessor;
            //    private readonly IAppSettings AppSettings;
            //    private readonly IAuthService AuthService;
            //    // private readonly IRedisService RedisService;

            //    private readonly IRedisService2<object> RedisService2;

            //    public UnitOfWork(
            //        WebchatDBContext context,
            //        IConfiguration configuration,
            //        IHttpContextAccessor httpContextAccessor,
            //        IAppSettings applicationSettings,
            //        //  IRedisService redisService,
            //        IRedisService2<object> redisService2,
            //        IAuthService authService)
            //    {
            //        #region Dependencies Init()
            //        Context = context;
            //        HttpContextAccessor = httpContextAccessor;
            //        AppSettings = applicationSettings;
            //        Configuration = configuration;
            //        AuthService = authService;
            //        //  RedisService = redisService;
            //        RedisService2 = redisService2;
            //        #endregion



            //        #region MessageRepository
            //        MessageRepository = new MessageRepository(
            //         context: Context,
            //         configuration: Configuration,
            //         httpContextAccessor: HttpContextAccessor,
            //         appSettings: AppSettings);
            //        #endregion

            //        #region GroupRepository
            //        GroupRepository = new GroupRepository(
            //         context: Context,
            //         configuration: Configuration,
            //         httpContextAccessor: HttpContextAccessor,
            //         appSettings: AppSettings);
            //        #endregion

            //        #region SubGroupRepository
            //        SubGroupRepository = new SubGroupRepository(
            //         context: Context,
            //         configuration: Configuration,
            //         httpContextAccessor: HttpContextAccessor,
            //         appSettings: AppSettings);
            //        #endregion

            //        #region GroupUserRepository
            //        GroupUserRepository = new GroupUserRepository(
            //         context: Context,
            //         configuration: Configuration,
            //         httpContextAccessor: HttpContextAccessor,
            //         appSettings: AppSettings);
            //        #endregion

            //        #region UserRepository
            //        UserRepository = new UserRepository(
            //          context: Context,
            //         configuration: Configuration,
            //         httpContextAccessor: HttpContextAccessor,
            //         appSettings: AppSettings,
            //         authService: AuthService,
            //        // redisService: RedisService,
            //         redisService2: RedisService2);
            //        #endregion
            //    }
            //    public IUserRepository UserRepository { get; }

            //    public IMessageRepository MessageRepository { get; }
            //    public IGroupRepository GroupRepository { get; }
            //    public ISubGroupRepository SubGroupRepository { get; }

            //    public IGroupUserRepository GroupUserRepository { get; }

            //    public async Task SaveAsync()
            //    {
            //        await Context.SaveChangesAsync();
            //    }
            //    public async Task<int> SaveChangesAsync()
            //    {
            //        return await Context.SaveChangesAsync();
            //    }
            //    public void Dispose() => Context.Dispose();
            //}
        }
    }
    public enum TokenTypeEnum
    {
        [Description("Access_Token")]
        Access_Token = 1,

        [Description("Refresh_Token")]
        Refresh_Token = 2
    }
    //Common.JWT.Helpers
    public static class JwtHelpers
    {
        public static TValue? GetClaim<TValue>(string key, IPrincipalAccessor? principal)
        {
            if (key.IsEmpty())
            {
                return default;
            }
            var claims = principal?.Principal?.Claims;
            if (claims != null && claims.IsEmpty())
            {
                return default;
            }
            var stringValue = claims?.FirstOrDefault(n => n.Type == key)?.Value;
            if (stringValue == null)
            {
                return default;
            }
            return (TValue)Convert.ChangeType(stringValue, typeof(TValue));
        }

        public static T? GetClaimToObj<T>(string key, IPrincipalAccessor? principal) where T : class
        {
            if (key.IsEmpty())
            {
                return default(T);
            }
            var claims = principal?.Principal?.Claims;
            if (claims != null && claims.IsEmpty())
            {
                return default(T);
            }
            var stringValue = claims?.FirstOrDefault(n => n.Type == key)?.Value;
            if (stringValue == null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(stringValue);
        }

        public static string? GetClaim(string key, IPrincipalAccessor? principal)
        {
            return GetClaim<string>(key, principal);
        }
    }

    //Identity Folder: Common.JWT.Identity
    #region Common.JWT.Identity
    public class AuthClaimTypes
    {
        public const string UserId = nameof(UserId);
        public const string UserName = nameof(UserName);
        public const string NickName = nameof(NickName);
        public const string UserPhoto = nameof(UserPhoto);
        public const string PhoneType = nameof(PhoneType);
        public const string IsValidator = nameof(IsValidator);
        public const string UserType = nameof(UserType);
        public const string IdentityUserName = nameof(IdentityUserName);
        public const string LoginTime = nameof(LoginTime);
        public const string LoginIPAddress = nameof(LoginIPAddress);
        public const string TokenType = nameof(TokenType);
        public const string Isvalidator = nameof(Isvalidator);
        public const string Name = nameof(Name);
        public const string GivenName = nameof(GivenName);
        public const string FamilyName = nameof(FamilyName);
        public const string MiddleName = nameof(MiddleName);
        public const string Nickname = nameof(Nickname);
        public const string PreferredUsername = nameof(PreferredUsername);
        public const string Profile = nameof(Profile);
        public const string Picture = nameof(Picture);
        public const string Website = nameof(Website);
        public const string Email = nameof(Email);
        public const string EmailVerified = nameof(EmailVerified);
        public const string Gender = nameof(Gender);
        public const string Birthdate = nameof(Birthdate);
        public const string Zoneinfo = nameof(Zoneinfo);
        public const string Locale = nameof(Locale);
        public const string PhoneNumber = nameof(PhoneNumber);
        public const string PhoneNumberVerified = nameof(PhoneNumberVerified);
        public const string Address = nameof(Address);
        public const string UpdatedAt = nameof(UpdatedAt);
        public const string Role = nameof(Role);
        public const string Groups = nameof(Groups);
        public const string Permissions = nameof(Permissions);
        public const string Custom1 = nameof(Custom1);
        public const string Custom2 = nameof(Custom2);
        public const string Custom3 = nameof(Custom3);
        public const string Custom4 = nameof(Custom4);
        public const string Custom5 = nameof(Custom5);
        public const string Custom6 = nameof(Custom6);
        public const string Custom7 = nameof(Custom7);
        public const string Custom8 = nameof(Custom8);
    }


    public class ClaimsAccessor(IPrincipalAccessor principalAccessor) : IdentityUser(principalAccessor), IClaimsAccessor
    {
    }

    public class ClaimsAccessorProvider : IClaimsAccessorProvider
    {
        public IClaimsAccessor? Current { get; set; }
        public AsyncLocal<IClaimsAccessor>? AccessorCurrent { get; set; }
    }

    public class IdentityUser(IPrincipalAccessor principalAccessor) : IIdentityUser
    {
        protected IPrincipalAccessor PrincipalAccessor { get; set; } = principalAccessor;

        public string? UserId => JwtHelpers.GetClaim(AuthClaimTypes.UserId, principal: PrincipalAccessor);
        public string? UserName => JwtHelpers.GetClaim(AuthClaimTypes.UserName, principal: PrincipalAccessor);
        public string? NickName => JwtHelpers.GetClaim(AuthClaimTypes.NickName, principal: PrincipalAccessor);
        public string? UserPhoto => JwtHelpers.GetClaim(AuthClaimTypes.UserPhoto, principal: PrincipalAccessor);
        public DateTime? LoginTime => Convert.ToDateTime(JwtHelpers.GetClaim(AuthClaimTypes.LoginTime, principal: PrincipalAccessor));
        public string? LoginIPAddress => JwtHelpers.GetClaim(AuthClaimTypes.LoginIPAddress, principal: PrincipalAccessor);
        public TokenTypeEnum? TokenType => (TokenTypeEnum)JwtHelpers.GetClaim(AuthClaimTypes.TokenType, principal: PrincipalAccessor).GetIntValueByEnum<TokenTypeEnum>();
        public string? Isvalidator => JwtHelpers.GetClaim(AuthClaimTypes.Isvalidator, principal: PrincipalAccessor);
        public string? PhoneType => JwtHelpers.GetClaim(AuthClaimTypes.PhoneType, principal: PrincipalAccessor);
        public string? UserType => JwtHelpers.GetClaim(AuthClaimTypes.UserType, principal: PrincipalAccessor);

        public string? IdentityUserName => JwtHelpers.GetClaim(AuthClaimTypes.IdentityUserName, principal: PrincipalAccessor);
        public string? Name => JwtHelpers.GetClaim(AuthClaimTypes.Name, principal: PrincipalAccessor);
        public string? GivenName => JwtHelpers.GetClaim(AuthClaimTypes.GivenName, principal: PrincipalAccessor);
        public string? FamilyName => JwtHelpers.GetClaim(AuthClaimTypes.FamilyName, principal: PrincipalAccessor);
        public string? MiddleName => JwtHelpers.GetClaim(AuthClaimTypes.MiddleName, principal: PrincipalAccessor);
        public string? Nickname => JwtHelpers.GetClaim(AuthClaimTypes.Nickname, principal: PrincipalAccessor);
        public string? PreferredUsername => JwtHelpers.GetClaim(AuthClaimTypes.PreferredUsername, principal: PrincipalAccessor);
        public string? Profile => JwtHelpers.GetClaim(AuthClaimTypes.Profile, principal: PrincipalAccessor);
        public string? Picture => JwtHelpers.GetClaim(AuthClaimTypes.Picture, principal: PrincipalAccessor);
        public string? Website => JwtHelpers.GetClaim(AuthClaimTypes.Website, principal: PrincipalAccessor);
        public string? Email => JwtHelpers.GetClaim(AuthClaimTypes.Email, principal: PrincipalAccessor);
        public string? EmailVerified => JwtHelpers.GetClaim(AuthClaimTypes.EmailVerified, principal: PrincipalAccessor);
        public string? Gender => JwtHelpers.GetClaim(AuthClaimTypes.Gender, principal: PrincipalAccessor);
        public string? Birthdate => JwtHelpers.GetClaim(AuthClaimTypes.Birthdate, principal: PrincipalAccessor);
        public string? Zoneinfo => JwtHelpers.GetClaim(AuthClaimTypes.Zoneinfo, principal: PrincipalAccessor);
        public string? Locale => JwtHelpers.GetClaim(AuthClaimTypes.Locale, principal: PrincipalAccessor);
        public string? PhoneNumber => JwtHelpers.GetClaim(AuthClaimTypes.PhoneNumber, principal: PrincipalAccessor);
        public string? PhoneNumberVerified => JwtHelpers.GetClaim(AuthClaimTypes.PhoneNumberVerified, principal: PrincipalAccessor);
        public string? Address => JwtHelpers.GetClaim(AuthClaimTypes.Address, principal: PrincipalAccessor);
        public string? UpdatedAt => JwtHelpers.GetClaim(AuthClaimTypes.UpdatedAt, principal: PrincipalAccessor);
        public string? Role => JwtHelpers.GetClaim(AuthClaimTypes.Role, principal: PrincipalAccessor);
        public string? Groups => JwtHelpers.GetClaim(AuthClaimTypes.Groups, principal: PrincipalAccessor);
        public string? Permissions => JwtHelpers.GetClaim(AuthClaimTypes.Permissions, principal: PrincipalAccessor);
        public string? Custom1 => JwtHelpers.GetClaim(AuthClaimTypes.Custom1, principal: PrincipalAccessor);
        public string? Custom2 => JwtHelpers.GetClaim(AuthClaimTypes.Custom2, principal: PrincipalAccessor);
        public string? Custom3 => JwtHelpers.GetClaim(AuthClaimTypes.Custom3, principal: PrincipalAccessor);
        public string? Custom4 => JwtHelpers.GetClaim(AuthClaimTypes.Custom4, principal: PrincipalAccessor);
        public string? Custom5 => JwtHelpers.GetClaim(AuthClaimTypes.Custom5, principal: PrincipalAccessor);
        public string? Custom6 => JwtHelpers.GetClaim(AuthClaimTypes.Custom6, principal: PrincipalAccessor);
        public string? Custom7 => JwtHelpers.GetClaim(AuthClaimTypes.Custom7, principal: PrincipalAccessor);
        public string? Custom8 => JwtHelpers.GetClaim(AuthClaimTypes.Custom8, principal: PrincipalAccessor);
    }


    public class PrincipalAccessor(IHttpContextAccessor httpContextAccessor) : IPrincipalAccessor
    {
        public ClaimsPrincipal Principal => HttpContext?.User;

        public HttpContext HttpContext => _httpContextAccessor?.HttpContext;

        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    }


    public class StaticPrincipalAccessor : IPrincipalAccessor
    {
        private readonly ClaimsPrincipal _principal;
        private readonly HttpContext _httpContext;
        private StaticPrincipalAccessor(HttpContext httpContext)
        {
            _httpContext = httpContext;
            _principal = _httpContext?.User;
        }

        public ClaimsPrincipal Principal => _principal;
        public HttpContext HttpContext => _httpContext;

        public static IPrincipalAccessor CreateInstance(HttpContext httpContext)
        {
            return new StaticPrincipalAccessor(httpContext);
        }
    }
    #endregion


    #region Common.JWT.Interface;
    public interface IAuthClaim
    {
        string UserId { get; set; }
        string UserName { get; set; }
        string NickName { get; set; }
        string UserPhoto { get; set; }
        string PhoneType { get; set; }
        string Isvalidator { get; set; }
        string UserType { get; set; }
        string Issuer { get; set; }
        string Name { get; set; }
        string GivenName { get; set; }
        string FamilyName { get; set; }
        string MiddleName { get; set; }
        string Nickname { get; set; }
        string PreferredUsername { get; set; }
        string Profile { get; set; }
        string Picture { get; set; }
        string Website { get; set; }
        string Email { get; set; }
        string EmailVerified { get; set; }
        string Gender { get; set; }
        string Birthdate { get; set; }
        string Zoneinfo { get; set; }
        string Locale { get; set; }
        string PhoneNumber { get; set; }
        string PhoneNumberVerified { get; set; }
        string Address { get; set; }
        string UpdatedAt { get; set; }
        string Role { get; set; }
        string Groups { get; set; }
        string Permissions { get; set; }
        string LoginTime { get; set; }
        string LoginIPAddress { get; set; }
        string TokenType { get; set; }
        string Expiration { get; set; }
        string Custom1 { get; set; }
        string Custom2 { get; set; }
        string Custom3 { get; set; }
        string Custom4 { get; set; }
        string Custom5 { get; set; }
        string Custom6 { get; set; }
        string Custom7 { get; set; }
        string Custom8 { get; set; }
    }

    public interface IClaimsAccessor : IIdentityUser
    {
    }

    public interface IClaimsAccessorProvider
    {
        IClaimsAccessor? Current { get; set; }
    }

    public interface IIdentityUser
    {
        string? UserId { get; }
        string? UserName { get; }
        string? NickName { get; }
        string? UserPhoto { get; }
        string? PhoneType { get; }
        string? Isvalidator { get; }
        string? UserType { get; }
        string? IdentityUserName { get; }
        string? Name { get; }
        string? GivenName { get; }
        string? FamilyName { get; }
        string? MiddleName { get; }
        string? Nickname { get; }
        string? PreferredUsername { get; }
        string? Profile { get; }
        string? Picture { get; }
        string? Website { get; }
        string? Email { get; }
        string? EmailVerified { get; }
        string? Gender { get; }
        string? Birthdate { get; }
        string? Zoneinfo { get; }
        string? Locale { get; }
        string? PhoneNumber { get; }
        string? PhoneNumberVerified { get; }
        string? Address { get; }
        string? UpdatedAt { get; }
        string? Role { get; }
        string? Groups { get; }
        string? Permissions { get; }
        string? Custom1 { get; }
        string? Custom2 { get; }
        string? Custom3 { get; }
        string? Custom4 { get; }
        string? Custom5 { get; }
        string? Custom6 { get; }
        string? Custom7 { get; }
        string? Custom8 { get; }
    }

    public interface IJwtConfig
    {
        public string? SecretKey { get; }
        public string? Issuer { get; }
        public string? Audience { get; }
        public string? TokenTime { get; }
    }

    public interface IJwtTokenAuth
    {
        string GenerateJwtToken(IAuthClaim authClaim);
    }

    public interface IPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }
        HttpContext HttpContext { get; }
    }

    #endregion



    #region  Common.JWT;
    public class AuthClaim : IAuthClaim
    {
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string UserPhoto { get; set; } = string.Empty;
        public string PhoneType { get; set; } = string.Empty;
        public string Isvalidator { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string GivenName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string PreferredUsername { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EmailVerified { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Birthdate { get; set; } = string.Empty;
        public string Zoneinfo { get; set; } = string.Empty;
        public string Locale { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PhoneNumberVerified { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string UpdatedAt { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Groups { get; set; } = string.Empty;
        public string Permissions { get; set; } = string.Empty;
        public string LoginTime { get; set; } = string.Empty;
        public string LoginIPAddress { get; set; } = string.Empty;
        public string TokenType { get; set; } = string.Empty;
        public string Expiration { get; set; } = string.Empty;
        public string Custom1 { get; set; } = string.Empty;
        public string Custom2 { get; set; } = string.Empty;
        public string Custom3 { get; set; } = string.Empty;
        public string Custom4 { get; set; } = string.Empty;
        public string Custom5 { get; set; } = string.Empty;
        public string Custom6 { get; set; } = string.Empty;
        public string Custom7 { get; set; } = string.Empty;
        public string Custom8 { get; set; } = string.Empty;
    }


    public class JwtConfig : IJwtConfig
    {
        public new string? SecretKey { get; set; }
        public new string? Issuer { get; set; }
        public new string? Audience { get; set; }
        public new string? TokenTime { get; set; }
    }


    public class JwtTokenAuth(IJwtConfig jwtConfig) : IJwtTokenAuth
    {
        public string GenerateJwtToken(IAuthClaim authClaim)
        {
            var claims = new List<Claim>();

            #region Get Claims
            foreach (var property in typeof(AuthClaim).GetProperties())
            {
                var value = property.GetValue(authClaim)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    claims.Add(new Claim(property.Name, value));
                }
            }
            #endregion

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expValue = new DateTimeOffset(DateTime.Now.AddMinutes(Convert.ToInt32(jwtConfig.TokenTime))).ToUnixTimeSeconds();

            claims.Add(new(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"));
            claims.Add(new(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"));
            claims.Add(new(JwtRegisteredClaimNames.Exp, $"{expValue}"));
            claims.Add(new(new AuthClaim().Expiration, DateTime.Now.AddMinutes(Convert.ToInt32(jwtConfig.TokenTime)).ToString()));

            var jwt = new JwtSecurityToken(
                   issuer: jwtConfig.Issuer,
                   audience: jwtConfig.Audience,
                   claims: claims,
                   signingCredentials: credentials
               );

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwt);
            return token;
        }

    }


    #endregion


    #region Common.JWT.Extensions.DependencyInjection;
    public static class AuthRegistrarExtension
    {
        #region AuthService
        #region Summary
        /// <summary>
        /// AuthService
        /// Developer: ALI RAZA MUSHTAQ
        /// aliraza_mushtaq@outlook.com
        /// </summary>
        /// <param name="services"></param> 
        #endregion
        public static void AuthService(this IServiceCollection services)
        {
            #region ...
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IPrincipalAccessor, PrincipalAccessor>();
            services.AddSingleton<IIdentityUser, IdentityUser>();
            services.AddSingleton<IClaimsAccessor, ClaimsAccessor>();

            #endregion
        }
        #endregion
    }

    public static class JWTAuthenticationExtension
    {
        #region AddJWTInfrastructure
        #region AddJWTInfrastructure Summary
        /// <summary>
        /// AddJWTInfrastructure
        /// Developer: ALI RAZA MUSHTAQ
        /// aliraza_mushtaq@outlook.com
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        #endregion
        public static void AddJWTInfrastructure(this IServiceCollection services, IJwtConfig jwtConfig)
        {
            #region ....
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtConfig?.Issuer,
                        ValidAudience = jwtConfig?.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.SecretKey))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            // Custom validation logic can be added here if needed
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            // Handle authentication failure
                            return Task.CompletedTask;
                        }
                    };
                });
            #endregion
        }
        #endregion
    }
    #endregion


    #region  AM.Common.Extensions.Attributes;
    [AttributeUsage(AttributeTargets.All)]
    public class EnumTypeAttribute(int startNum) : Attribute
    {
        public int StartNum { get; } = startNum;
    }
    #endregion


   
    #region AM.Common.Extensions.Enum;
    public static partial class Extensions
    {
        public static Dictionary<int, string> EnumToDictionary(this Type enumType)
        {
            Dictionary<int, string> dictionary = new();
            Type typeDescription = typeof(DescriptionAttribute);
            FieldInfo[] fields = enumType.GetFields();
            int sValue = 0;
            string sText = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    sValue = (int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute da = (DescriptionAttribute)arr[0];
                        sText = da.Description;
                    }
                    else
                    {
                        sText = field.Name;
                    }
                    dictionary.Add(sValue, sText);
                }
            }
            return dictionary;
        }
        public static string EnumToDictionaryString(this Type enumType)
        {
            List<KeyValuePair<int, string>> dictionaryList = EnumToDictionary(enumType).ToList();
            var sJson = System.Text.Json.JsonSerializer.Serialize(dictionaryList);
            return sJson;
        }
        public static string GetDescription(this System.Enum enumType)
        {
            FieldInfo? EnumInfo = enumType.GetType().GetField(enumType.ToString());
            if (EnumInfo != null)
            {
                DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])EnumInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (EnumAttributes.Length > 0)
                {
                    return EnumAttributes[0].Description;
                }
            }
            return enumType.ToString();
        }

        public static string GetDefaultValue(this System.Enum enumType)
        {
            FieldInfo? EnumInfo = enumType.GetType().GetField(enumType.ToString());
            if (EnumInfo != null)
            {
                DefaultValueAttribute[] EnumAttributes = (DefaultValueAttribute[])EnumInfo.GetCustomAttributes(typeof(DefaultValueAttribute), false);
                if (EnumAttributes.Length > 0)
                {
                    if (EnumAttributes.Length != 0)
                    {
                        return EnumAttributes[0].Value.ToString();
                    }
                }
            }
            return enumType.ToString();
        }
        public static int? GetIntValueByEnum<T>(this object obj) where T : struct, System.Enum
        {
            if (obj == null || !System.Enum.TryParse(typeof(T), obj.ToString(), out var enumValue))
                return null;

            return Convert.ToInt32(enumValue);
        }
        //public static string GetDescriptionByEnum<T>(this object obj) where T : struct
        //{
        //    T tEnum;
        //    var isOk = System.Enum.TryParse<T>(Convert.ToString(obj), out tEnum);
        //    if (!isOk) return "unknown status";
        //    var description = (tEnum as System.Enum).GetDescription();
        //    return description;
        //}

        public static string GetDescriptionByEnum<T>(this object obj) where T : struct, System.Enum
        {
            if (obj == null || !System.Enum.TryParse(obj.ToString(), out T tEnum))
                return "unknown status";

            return GetEnumDescription(tEnum);
        }

        private static string GetEnumDescription<T>(T value) where T : struct, System.Enum
        {
            Type type = value.GetType();
            if (!type.IsEnum)
                throw new ArgumentException($"{nameof(value)} must be an enum type");

            MemberInfo[] memberInfo = type.GetMember(value.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var descriptionAttributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (descriptionAttributes != null && descriptionAttributes.Length > 0)
                    return ((DescriptionAttribute)descriptionAttributes[0]).Description;
            }

            return value.ToString();
        }

        public static int GetTypeValue(this System.Enum em)
        {
            if (em == null)
                throw new ArgumentNullException(nameof(em));

            FieldInfo? enumField = em.GetType().GetField(em.ToString());
            if (enumField != null)
            {
                EnumTypeAttribute attribute = enumField.GetCustomAttribute<EnumTypeAttribute>();
                if (attribute != null)
                    return attribute.StartNum;
            }
            return -1;
        }


    }
    #endregion

    #region AM.Common.Extensions.String;
    public static partial class StringExtension
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsEmpty(this object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsEmpty(this Guid? value)
        {
            if (value == null)
                return true;
            return IsEmpty(value.Value);
        }

        public static bool IsEmpty(this Guid value)
        {
            if (value == Guid.Empty)
                return true;
            return false;
        }
    }
    #endregion


    //#region WebChat.Infrastructure.Middleware.EnsureMigrationExtension;
    //public static class MigrationExtensions
    //{
    //    public static IApplicationBuilder EnsureMigration(this IApplicationBuilder app)
    //    {
    //        using (var scope = app.ApplicationServices.CreateScope())
    //        {
    //            var services = scope.ServiceProvider;
    //            try
    //            {
    //                var dbContext = services.GetRequiredService<WebchatDBContext>(); // Replace with your actual DbContext type
    //                dbContext.Database.Migrate();
    //            }
    //            catch (Exception ex)
    //            {
    //                var logger = services.GetRequiredService<ILogger<WebchatDBContext>>();
    //                logger.LogError(ex, "An error occurred while migrating the database.");
    //            }
    //        }
    //        return app;
    //    }
    //} 
    //#endregion

    ////using Newtonsoft.Json;
    ////using System.Net;
    ////using WebChat.Common.Enums.API;
    ////using WebChat.Common.IBaseResponse;

    ////namespace WebChat.Infrastructure.Middleware.ExceptionMiddleware;

    //#region WebChat.Infrastructure.Middleware.ExceptionMiddleware;
    //public class ExceptionMiddleware(RequestDelegate next)
    //{
    //    private readonly RequestDelegate _next = next;

    //    public async Task InvokeAsync(HttpContext context)
    //    {
    //        try
    //        {
    //            await _next(context);
    //        }
    //        catch (Exception ex)
    //        {
    //            await HandleExceptionAsync(context, ex);
    //        }
    //    }

    //    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    //    {
    //        context.Response.ContentType = "application/json";
    //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

    //        var errorResponse = new ApiResponseWithList<object>
    //        {
    //            Code = ApiCodeEnum.Failed,
    //            MsgCode = ApiMessageEnum.Exception,
    //            List = GetExceptionList(exception)
    //        };

    //        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
    //    }

    //    private static List<object> GetExceptionList(Exception exception)
    //    {
    //        var exceptionList = new List<object>();

    //        while (exception != null)
    //        {
    //            var exceptionInfo = new
    //            {
    //                Name = exception.GetType().FullName,
    //                Message = exception.Message
    //            };

    //            exceptionList.Add(exceptionInfo);
    //            exception = exception.InnerException;
    //        }

    //        return exceptionList;
    //    }
    //} 
    //#endregion


    ////using JwtService;
    ////using JwtService.Interface;
    ////using WebChat.Extension.Extensions;

    //#region WebChat.Infrastructure.Middleware.Jwt;
    //public class JwtTokenValidationMiddleware(RequestDelegate next, IAppSettings AppSettings, IAuthService authService)
    //{
    //    private readonly RequestDelegate _next = next;
    //    private readonly IAppSettings AppSettings = AppSettings;
    //    private readonly IAuthService AuthService = authService;

    //    public async Task InvokeAsync(HttpContext context)
    //    {

    //        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Replace("Bearer ", "");



    //        // Check if the request is for the login endpoint
    //        if (context.Request.Path.StartsWithSegments("/api/v1/Auth/AccessToken")
    //            || context.Request.Path.StartsWithSegments("/api/auth/get-token")
    //            || context.Request.Path.StartsWithSegments("/api/auth/token-auhtenticated")
    //            )
    //        {
    //            // Allow anonymous access to the login endpoint
    //            await _next(context);
    //            return;
    //        }

    //        var tokenValidate = AuthService.ValidateJwtToken(token);

    //        if (!tokenValidate)
    //        {
    //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //            return;
    //        }

    //        await _next(context);
    //    }
    //} 
    //#endregion

    ////using Microsoft.AspNetCore.Mvc.ModelBinding;
    ////using Newtonsoft.Json;
    ////using WebChat.Common.Enums.API;
    ////using WebChat.Common.IBaseResponse;


    //#region WebChat.Infrastructure.Middleware.ModelValidation;
    //public class ModelValidationMiddleware(RequestDelegate next)
    //{
    //    private readonly RequestDelegate _next = next;

    //    public async Task Invoke(HttpContext context)
    //    {
    //        if (context.Request.Path.StartsWithSegments("/api")) // Adjust the path as needed
    //        {
    //            if (!context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase)) // Exclude GET requests if needed
    //            {
    //                if (context.Items["ModelState"] is ModelStateDictionary modelState && !modelState.IsValid)
    //                {
    //                    var validationResponse = new ApiResponse<object>
    //                    {
    //                        Code = ApiCodeEnum.Failed,
    //                        MsgCode = ApiMessageEnum.ModelValidation,
    //                        //List = GetExceptionList(exception)
    //                    };

    //                    await context.Response.WriteAsync(JsonConvert.SerializeObject(validationResponse));

    //                    return;
    //                }
    //            }
    //        }

    //        await _next(context);
    //    }
    //}
    //#endregion

    //#region WebChat.Infrastructure.Middleware.SwaggerUI;
    //#region SwaggerUIMiddleware
    //#region SwaggerUIMiddleware Summary
    ///// <summary>
    ///// SwaggerUIMiddleware
    ///// Developer: ALI RAZA MUSHTAQ
    ///// Date: 07-Feb-2024
    ///// alisaivi786@gmail.com
    ///// </summary> 
    //#endregion
    //public static class SwaggerUIMiddleware
    //{
    //    #region UseSwaggerWithUI
    //    #region UseSwaggerWithUI Summary
    //    /// <summary>
    //    /// UseSwaggerWithUI
    //    /// Developer: ALI RAZA MUSHTAQ
    //    /// Date: 07-Feb-2024
    //    /// alisaivi786@gmail.com
    //    /// </summary>
    //    /// <param name="app"></param> 
    //    #endregion
    //    public static void UseSwaggerWithUI(this IApplicationBuilder app)
    //    {
    //        #region UseSwaggerWithUI
    //        app.UseSwagger();

    //        app.UseSwaggerUI(options =>
    //        {
    //            foreach (var version in VersionHelper.GetApiVersions())
    //            {
    //                options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"Chat.API {version}");
    //            }

    //            // Specify the Swagger UI endpoint and UI path
    //            options.RoutePrefix = "api-doc";
    //            options.DocumentTitle = "Chat Documentation";
    //        });
    //        #endregion
    //    }
    //    #endregion
    //}
    //#endregion 
    //#endregion

    //#region WebChat.Infrastructure.Middleware.WebChatMiddleware;
    //public static class WebChatMiddlewareExtension
    //{
    //    public static IApplicationBuilder UseWebChatMiddleware(this IApplicationBuilder app)
    //    {
    //        app.UseSwaggerWithUI();
    //        //app.UseSerilogRequestLogging();
    //        // Migrate the database
    //        app.EnsureMigration();
    //        app.UseGlobalModelValidation();
    //        app.UseMiddleware<ExceptionMiddleware.ExceptionMiddleware>();
    //        //app.UseMiddleware<JwtTokenValidationMiddleware>();
    //        app.UseStaticFiles();
    //        // Add CookiePolicy
    //        // ...............
    //        app.UseRouting();
    //        #region App Use Cors
    //        app.UseCors(builder => builder
    //                .WithOrigins(
    //                "null",
    //                "http://localhost:8080",
    //                "https://localhost:5173",
    //                "http://localhost:5173",
    //                "https://localhost:5177",
    //                "http://localhost:8001",
    //                "https://localhost:5174",
    //                "https://webchat.22889.club",
    //                "http://localhost:90"
    //                )
    //                .AllowAnyHeader()
    //                .AllowAnyMethod().AllowCredentials());
    //        #endregion
    //        app.UseHttpsRedirection();
    //        app.UseAuthentication();
    //        app.UseAuthorization();
    //        app.UseHealthChecks("/health", new HealthCheckOptions()
    //        {
    //            Predicate = _ => true,
    //            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    //        });


    //        return app;

    //    }


    //}
    //#endregion

    //#region  WebChat.Infrastructure.Services.ApiVersionExtension;



    //#region ApiVersioningExtension
    //#region ApiVersioningExtension Summary
    ///// <summary>
    ///// ApiVersioningExtension
    ///// Developer: ALI RAZA MUSHTAQ
    ///// Date: 07-Feb-2024
    ///// alisaivi786@gmail.com
    ///// </summary> 
    //#endregion
    //public static class ApiVersioningExtension
    //{
    //    #region ApiVersionInfrastructure
    //    #region ApiVersionInfrastructure Summary
    //    /// <summary>
    //    /// ApiVersionInfrastructure
    //    /// Developer: ALI RAZA MUSHTAQ
    //    /// Date: 07-Feb-2024
    //    /// alisaivi786@gmail.com
    //    /// </summary>
    //    /// <param name="services"></param>
    //    /// <returns>Return AddApiVersioning Service</returns> 
    //    #endregion
    //    public static IServiceCollection ApiVersionInfrastructure(this IServiceCollection services)
    //    {
    //        #region ...
    //        #region AddApiVersioning
    //        services.AddApiVersioning(options =>
    //        {
    //            options.DefaultApiVersion = new ApiVersion(1, 0);
    //            options.AssumeDefaultVersionWhenUnspecified = true;
    //            options.ReportApiVersions = true;
    //        });
    //        #endregion

    //        #region Return Service
    //        return services;
    //        #endregion
    //        #endregion
    //    }
    //    #endregion
    //}
    //#endregion

    //#endregion

    //#region WebChat.Infrastructure.Services.ApplicationInfrastructure;


    //#region PersistenceServiceRegistration
    ///// <summary>
    ///// Persistence Service Registration
    ///// Developer: ALI RAZA MUSHTAQ
    ///// Date: 30-Jan-2024
    ///// alisaivi786@gmail.com
    ///// </summary>
    //public static class PersistenceServiceRegistration
    //{
    //    public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IAppSettings applicationSettings)
    //    {
    //        var dbProvider = applicationSettings.DBProvider;
    //        var migrationAssembly = $"WebChat.Infrastructure.{dbProvider}";
    //        Console.WriteLine("DBProvider: " + dbProvider);
    //        if (!string.IsNullOrEmpty(dbProvider) && dbProvider == "Mongo")
    //        {
    //            // Register Mongo DB Context
    //            services.AddMongoDbContext(applicationSettings.MongoConnectionString);
    //            // Register Mongo Repositories
    //            services.AddMongoRepositories();
    //        }
    //        else
    //        {
    //            // Register Context Switching Between Relational Database
    //            services.AddDbContext<WebchatDBContext>(options => _ = dbProvider switch
    //            {
    //                "SqlServer" => options.UseSqlServer(
    //                    applicationSettings.SqlConnectionString,
    //                    b =>
    //                    {
    //                        b.MigrationsAssembly(migrationAssembly);
    //                    }),

    //                "Npgsql" => options.UseNpgsql(
    //                    applicationSettings.PostgresConnectionString,
    //                    b =>
    //                    {
    //                        b.MigrationsAssembly(migrationAssembly);
    //                    }),

    //                "MySQL" => options.UseMySQL(
    //                    applicationSettings.MySqlConnectionString,
    //                    b => b.MigrationsAssembly(migrationAssembly)),

    //                //"Oracle" => options.UseOracle(
    //                //    applicationSettings.OracleConnectionString,
    //                //    b => b.MigrationsAssembly(migrationAssembly)),

    //                _ =>
    //                    options.UseMySQL(
    //                    applicationSettings.MySqlConnectionString,
    //                    b => b.MigrationsAssembly(migrationAssembly)),
    //                //throw new InvalidOperationException($"Unsupported DBProvider: {dbProvider}")
    //            });

    //            services.AddScoped<IWebchatDBContext>(provider => provider.GetRequiredService<WebchatDBContext>());
    //            services.AddScoped<IUnitOfWork, UnitOfWork>();

    //        }
    //        return services;
    //    }




    //}

    //#endregion

    //#endregion


    //#region WebChat.Infrastructure.Services.SwaggerExtension;


    //#region SwaggerExtensions
    //#region SwaggerExtensions Summary
    ///// <summary>
    ///// SwaggerExtensions
    ///// Developer: ALI RAZA MUSHTAQ
    ///// Date: 07-Feb-2024
    ///// alisaivi786@gmail.com
    ///// </summary> 
    //#endregion
    //public static class SwaggerExtensions
    //{
    //    private static readonly string[] value = new[] { "Bearer " };
    //    #region AddSwaggerWithVersioning
    //    #region AddSwaggerWithVersioning Summary
    //    /// <summary>
    //    /// AddSwaggerWithVersioning Service Infrastructure
    //    /// Developer: ALI RAZA MUSHTAQ
    //    /// Date: 07-Feb-2024
    //    /// alisaivi786@gmail.com
    //    /// </summary>
    //    /// <param name="services"></param> 
    //    #endregion
    //    public static void AddSwaggerWithVersioning(this IServiceCollection services)
    //    {
    //        #region AddSwaggerGen
    //        services.AddSwaggerGen(options =>
    //        {
    //            #region ...
    //            #region Configure Swagger to use versioning
    //            options.DocInclusionPredicate((version, desc) =>
    //            {
    //                var versions = desc.CustomAttributes().OfType<ApiVersionAttribute>().SelectMany(attr => attr.Versions);
    //                return versions.Any(v => $"v{v}" == version);
    //            });
    //            #endregion

    //            #region Add a Swagger document for each discovered API version
    //            foreach (var version in VersionHelper.GetApiVersions())
    //            {
    //                options.SwaggerDoc($"{version}", new OpenApiInfo
    //                {
    //                    Title = $"Chat.API {version}",
    //                    Version = $"{version}",
    //                });
    //            }
    //            #endregion

    //            //options.SchemaFilter<HideSchemaFilter>();

    //            // Add JWT Authentication
    //            var securityScheme = new OpenApiSecurityScheme
    //            {
    //                Name = "JWT Authentication",
    //                Description = "Enter your JWT token",
    //                In = ParameterLocation.Header,
    //                Type = SecuritySchemeType.Http,
    //                Scheme = "bearer",
    //                BearerFormat = "JWT"
    //            };

    //            options.AddSecurityDefinition("Bearer", securityScheme);

    //            var securityRequirement = new OpenApiSecurityRequirement
    //        {
    //            { securityScheme, value }
    //        };

    //            options.AddSecurityRequirement(securityRequirement);

    //            #endregion

    //        });
    //        #endregion
    //    }
    //    #endregion

    //}

    //#endregion

    //#endregion
}




