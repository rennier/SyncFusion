using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace TelerikBlazorApp1.Data
{
    public class DepartmentService : IDepartmentService
    {
        // Database connection
        private readonly SqlConnectionConfiguration _configuration;
        public DepartmentService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        // Add (create) a Department table row (SQL Insert)
        // This only works if you're already created the stored procedure.
        public async Task<bool> DepartmentInsert(Department department)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("DeptName", department.DeptName, DbType.String);
                parameters.Add("DeptLocation", department.DeptLocation, DbType.String);

                // Stored procedure method
                await conn.ExecuteAsync("spDepartment_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }
        // Get a list of department rows (SQL Select)
        // This only works if you're already created the stored procedure.
        public async Task<IEnumerable<Department>> DepartmentList()
        {
            IEnumerable<Department> departments;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                departments = await conn.QueryAsync<Department>("spDepartment_List", commandType: CommandType.StoredProcedure);
            }
            return departments;
        }
        //Search for data (very generic...you may need to adjust.
        public async Task<IEnumerable<Department>> DepartmentSearch(string @Param)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Param", Param, DbType.String);
            IEnumerable<Department> departments;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                departments = await conn.QueryAsync<Department>("spDepartment_Search", parameters, commandType: CommandType.StoredProcedure);
            }
            return departments;
        }
        // Search based on date range. Code generator makes wild guess, you 
        // will likely need to adjust field names
        public async Task<IEnumerable<Department>> DepartmentDateRange(DateTime @StartDate, DateTime @EndDate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", StartDate, DbType.Date);
            parameters.Add("@EndDate", EndDate, DbType.Date);
            IEnumerable<Department> departments;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                departments = await conn.QueryAsync<Department>("spDepartment_DateRange", parameters, commandType: CommandType.StoredProcedure);
            }
            return departments;
        }

        // Get one department based on its DepartmentID (SQL Select)
        // This only works if you're already created the stored procedure.
        public async Task<Department> Department_GetOne(int @DeptID)
        {
            Department department = new Department();
            var parameters = new DynamicParameters();
            parameters.Add("@DeptID", DeptID, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                department = await conn.QueryFirstOrDefaultAsync<Department>("spDepartment_GetOne", parameters, commandType: CommandType.StoredProcedure);
            }
            return department;
        }
        // Update one Department row based on its DepartmentID (SQL Update)
        // This only works if you're already created the stored procedure.
        public async Task<bool> DepartmentUpdate(Department department)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("DeptID", department.DeptID, DbType.Int32);

                parameters.Add("DeptName", department.DeptName, DbType.String);
                parameters.Add("DeptLocation", department.DeptLocation, DbType.String);

                await conn.ExecuteAsync("spDepartment_Update", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        // Physically delete one Department row based on its DepartmentID (SQL Delete)
        // This only works if you're already created the stored procedure.
        public async Task<bool> DepartmentDelete(int DeptID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DeptID", DeptID, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                await conn.ExecuteAsync("spDepartment_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }
    }
}