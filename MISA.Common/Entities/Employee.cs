using MISA.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Entities
{
    /// <summary>
    /// Thông tin khách khách
    /// </summary>
    /// CreatedBy: NVMANH ()
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        [MISARequired("Mã nhân viên không được phép để trống!")]
        public string EmployeeCode { get; set; }
        
        [MISARequired("Tên nhân viên không được phép để trống!")]
        public string FullName { get; set; }

       // [MISARequired("Tên đơn vị không được phép để trống!")]
        public Guid EmployeeGroupId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string PositionName { get; set; }
        public string IdentityCardNumber { get; set; }
        public DateTime IdentityCardDate { get; set; }
        public string IdentityCardPlace { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankCardNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
