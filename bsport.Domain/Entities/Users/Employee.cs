using System;
using System.Collections.Generic;

namespace bsport.Domain.Entities.Users
{
    public class Employee : BaseEntity
    {
        /* Mã nhân viên */
        public string Code { get; set; } = string.Empty;

        /* Tên nhân viên */
        public string Name { get; set; } = string.Empty;

        /* Giới tính: MALE | FEMALE | OTHER */
        public string? Gender { get; set; }

        /* Số điện thoại */
        public string? Phone { get; set; }

        /* Ngày sinh */
        public DateTime? Birthday { get; set; }

        /* Email */
        public string? Email { get; set; }

        /* Địa chỉ */
        public string? Address { get; set; }

        /* Số CCCD / CMND */
        public string? IdentityNumber { get; set; }

        /* Ngày cấp CCCD */
        public DateTime? IdentityIssuedDate { get; set; }

        /* Nơi cấp CCCD */
        public string? IdentityIssuedPlace { get; set; }

        /* Chức vụ: MANAGER | STAFF | TRAINER ... */
        public string? Position { get; set; }

        /* Phòng ban */
        public string? Department { get; set; }

        /* Ngày vào làm */
        public DateTime? JoinDate { get; set; }

        /* Ngày nghỉ việc */
        public DateTime? ResignDate { get; set; }

        /* Trạng thái: WORKING | RESIGNED | ON_LEAVE */
        public string EmployeeStatus { get; set; } = "WORKING";

        /* Lương cơ bản */
        public decimal? BaseSalary { get; set; }

        /* Số tài khoản ngân hàng */
        public string? BankAccount { get; set; }

        /* Tên ngân hàng */
        public string? BankName { get; set; }

        /* Chủ tài khoản */
        public string? BankOwner { get; set; }

        /* Ghi chú */
        public string? Description { get; set; }

        /* ======================== FILE ======================== */

        /* Avatar / Ảnh đại diện */
        public string? Avatar { get; set; }

        /* Ảnh CCCD mặt trước */
        public string? IdentityFrontUrl { get; set; }

        /* Ảnh CCCD mặt sau */
        public string? IdentityBackUrl { get; set; }

        /* Ảnh chân dung */
        public string? PortraitUrl { get; set; }

        /* Ảnh hợp đồng lao động */
        public string? ContractUrl { get; set; }

        /* Ảnh bằng cấp / chứng chỉ */
        public string? CertificateUrl { get; set; }

        /* Ảnh sổ hộ khẩu */
        public string? HouseholdBookUrl { get; set; }

        /* ======================== NAVIGATION ======================== */

        /* Navigation property - liên kết với User */
        public User? User { get; set; }

        /* Navigation property - lịch làm việc */
        public ICollection<EmployeeSchedule> Schedules { get; set; } = new List<EmployeeSchedule>();

        /* Navigation property - file đính kèm */
        public ICollection<FileArchival> Files { get; set; } = new List<FileArchival>();
    }
}