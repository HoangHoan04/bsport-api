using bsport.Domain.Entities.Users;
using System;

namespace bsport.Domain.Entities
{
    public class FileArchival : BaseEntity
    {
        /* URL truy cập file */
        public string? FileUrl { get; set; }

        /* Tên file */
        public string? FileName { get; set; }

        /* Loại file: IMAGE | VIDEO | DOCUMENT | AUDIO */
        public string? FileType { get; set; }

        /* ID khách hàng */
        public Guid? CustomerId { get; set; }

        /* Navigation property - khách hàng */
        public Customer? Customer { get; set; }

        /* ID nhân viên */
        public Guid? EmployeeId { get; set; }

        /* Navigation property - nhân viên */
        public Employee? Employee { get; set; }

        /* ID tin tức */
        public Guid? NewId { get; set; }

        /* ID banner */
        public Guid? BannerId { get; set; }
     
    }
}