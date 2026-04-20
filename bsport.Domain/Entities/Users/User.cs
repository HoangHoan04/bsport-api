using System;
using System.Collections.Generic;
using System.Text;

namespace bsport.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        /* Tên đăng nhập */
        public string Username { get; set; } = string.Empty;

        /* Mật khẩu */
        public string Password { get; set; } = string.Empty;

        /* Trạng thái hoạt động */
        public bool IsActive { get; set; } = true;

        /* Có phải là Admin? */
        public bool IsAdmin { get; set; } = false;

        /* Id khách hàng */
        public Guid? CustomerId { get; set; }

        /* Id nhân viên */
        public Guid? EmployeeId { get; set; }

        /* Có đăng nhập bằng Google */
        public bool IsGoogleLogin { get; set; } = false;

        /* GoogleProviderId */
        public string? GoogleProviderId { get; set; }

        /* Có đăng nhập bằng Facebook */
        public bool IsFacebookLogin { get; set; } = false;

        /* FacebookProviderId */
        public string? FacebookProviderId { get; set; }

        /* Có đăng nhập bằng Zalo */
        public bool IsZaloLogin { get; set; } = false;

        /* ZaloProviderId */
        public string? ZaloProviderId { get; set; }

        /* Navigation property - 1 User có nhiều UserToken */
        public ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();

        /* Navigation property - 1 User có nhiều OTP */
        public ICollection<VerifyOtp> VerifyOtps { get; set; } = new List<VerifyOtp>();


    }
}