namespace bsport.Domain.Entities.Users
{
    public class EmployeeSchedule : BaseEntity
    {
        /* Id nhân viên */
        public Guid EmployeeId { get; set; }

        /* Ngày làm việc */
        public DateTime WorkDate { get; set; }

        /* Giờ bắt đầu */
        public TimeSpan StartTime { get; set; }

        /* Giờ kết thúc */
        public TimeSpan EndTime { get; set; }

        /* Trạng thái: SCHEDULED | CHECKED_IN | ABSENT | LATE */
        public string Status { get; set; } = "SCHEDULED";

        /* Ghi chú */
        public string? Note { get; set; }

        /* Navigation property */
        public Employee Employee { get; set; } = null!;
    }
}