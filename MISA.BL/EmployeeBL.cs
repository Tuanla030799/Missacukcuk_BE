using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
using MISA.Common.Attributes;
using MISA.Common.Entities;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.BL
{
    public class EmployeeBL:BaseBL<Employee>, IEmployeeBL

    {

        public EmployeeBL(IBaseDL<Employee> baseDL) : base(baseDL)
        {

        }
        

        protected override void ValidateInsert(Employee entity)
        {
            base.ValidateInsert(entity);
            if (entity is Employee)
            {
                EmployeeDL employeeDL = new EmployeeDL();
                // Validate dữ liệu:
                // 1. Đã nhập mã hay chưa? nếu chưa nhập thì đưa ra cảnh báo lỗi:
                var employee = entity;
                //if (string.IsNullOrEmpty(Employee.EmployeeCode))
                //{
                //    throw new GuardException<Employee>("Mã khách hàng không được phép để trống.", Employee);
                //}
                // 2. Check mã khách hàng đã tồn tại hay chưa?
                
                var isExists = employeeDL.CheckEmployeeCodeExist(employee.EmployeeCode);
                if (isExists == true)
                {
                    throw new GuardException<Employee>($"Mã nhân viên { employee.EmployeeCode } đã tồn tạo trong hệ thống, vui lòng kiểm tra lại"!, null);
                }
                if (employee.EmployeeGroupId.ToString() == "15fb79ad-271b-30eb-8f32-6a1673ffca7c")
                {
                    throw new GuardException<Employee>($"Đơn vị không được phép để trống"!, null);
                }
                // 3. Kiểm tra Email có đúng định dạng hay không?
                //var emailTemplate = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                //if (!Regex.IsMatch(employee.Email, emailTemplate))
                //{
                //    throw new GuardException<Employee>("Email không đúng định dạng, vui lòng kiểm tra lại", null);
                //}
            }
        }

        protected override void ValidateUpdate(Employee entity, Guid entityId)
        {
            base.ValidateInsert(entity);
            if (entity is Employee)
            {
                EmployeeDL employeeDL = new EmployeeDL();
      
                var employee = entity;

                var isExists = employeeDL.CheckEmployeeCodeExist(employee.EmployeeCode);
                //if (isExists == true)
                //{
                //    throw new GuardException<Employee>($"Mã nhân viên { employee.EmployeeCode } đã tồn tạo trong hệ thống, vui lòng kiểm tra lại"!, null);
                //}
                // 2. Check mã khách hàng đã tồn tại hay chưa?

                //var isExists = employeeDL.CheckEmployeeCodeExist(employee.EmployeeCode);
                //if (isExists == true)
                //{
                //    throw new GuardException<Employee>($"Mã nhân viên { employee.EmployeeCode } đã tồn tạo trong hệ thống, vui lòng kiểm tra lại"!, null);
                //}
                //if (employee.EmployeeGroupId.ToString() == "15fb79ad-271b-30eb-8f32-6a1673ffca7c")
                //{
                //    throw new GuardException<Employee>($"Đơn vị không được phép để trống"!, null);
                //}

            }
        }      

    }
}
