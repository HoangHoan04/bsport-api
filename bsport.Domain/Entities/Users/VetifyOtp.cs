using System;

namespace bsport.Domain.Entities.Users
{
    public class VerifyOtp : BaseEntity
    {
        /* ID người dùng */
        public Guid UserId { get; set; }

        /* Mã OTP */
        public string Otp { get; set; } = string.Empty;

        /* Loại OTP: REGISTER | FORGOT_PASSWORD | CHANGE_PHONE | CHANGE_EMAIL */
        public string OtpType { get; set; } = string.Empty;

        /* Thời gian hết hạn */
        public DateTime ExpiredAt { get; set; }

        /* Đã sử dụng chưa */
        public bool IsUsed { get; set; } = false;

        /* Số lần nhập sai */
        public int FailedAttempts { get; set; } = 0;

        /* Số điện thoại hoặc email nhận OTP */
        public string? Receiver { get; set; }

        /* Navigation property */
        public User User { get; set; } = null!;
    }
}