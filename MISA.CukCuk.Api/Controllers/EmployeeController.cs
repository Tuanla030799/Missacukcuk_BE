using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;
using MISA.BL;
using MISA.Common.Entities;
using MISA.BL.Exceptions;
using MISA.BL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class EmployeeController: MISAEntityController<Employee>
    {

        public EmployeeController(IEmployeeBL employeeBL) :base(employeeBL)
        {

        }
        [HttpGet("Paging")]
        public IActionResult GetPaging(int pageIndex, int pageSize)
        {
            // 1. Khai báo thông tin kết nối tới Database:
            var connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= 15B_MF64_CukCuk_LeAnhTuan;" +
                "User Id = dev;" +
                "Password= 12345678";

            // 2. Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
            var sqlCommand = "Proc_GetEmployeePaging";
            var param = new
            {
                m_PageIndex = pageIndex,
                m_PageSize = pageSize
            };

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@m_PageIndex", pageIndex);
            dynamicParameters.Add("@m_PageSize", pageSize);
            var employee = (dbConnection.Query<Employee>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure));
            // 4. Kiểm tra dữ liệu và trả về cho Client
            // - Nếu có dữ liệu thì trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (employee.Count() > 0)
            {
                return Ok(employee);
            }
            else
            {
                return NoContent();
            }
        }


    }
}
