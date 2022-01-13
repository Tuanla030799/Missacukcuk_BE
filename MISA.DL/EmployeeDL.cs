using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using MySqlConnector;
using System.Linq;

namespace MISA.DL
{
    public class EmployeeDL:BaseDL<Employee>
    {
        
        public bool CheckEmployeeCodeExist(string EmployeeCode)
        {
            // 1. Khai báo thông tin kết nối:
            var connectionString = "" +
               "Host = 47.241.69.179;" +
               "Port = 3306;" +
               "Database= 15B_MF64_CukCuk_LeAnhTuan;" +
               "User Id = dev;" +
               "Password= 12345678";

            // 2. Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // 3. Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_CheckEmployeeCodeExists";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@m_EmployeeCode", EmployeeCode);
            var res = dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        public bool CheckEmployeeCode(string EmployeeCode)
        {
            // 1. Khai báo thông tin kết nối:
            var connectionString = "" +
               "Host = 47.241.69.179;" +
               "Port = 3306;" +
               "Database= 15B_MF64_CukCuk_LeAnhTuan;" +
               "User Id = dev;" +
               "Password= 12345678";

            // 2. Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // 3. Thực thi lệnh lấy dữ liệu trong Database:
            var sqlCommand = $"Proc_CheckEmployeeCodeExists";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@m_EmployeeCode", EmployeeCode);
            var res = dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }
    }
}
