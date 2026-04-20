using System;

namespace bsport.Domain.Entities.Users
{
    public class UserToken : BaseEntity
    {
        /* ID của người dùng */
        public Guid UserId { get; set; }

        /* Access token */
        public string? AccessToken { get; set; }

        /* Refresh token */
        public string? RefreshToken { get; set; }

        /* IP address */
        public string? IpAddress { get; set; }

        /* Ghi chú */
        public string? Note { get; set; }

        /* Nền tảng truy cập: WEB | MOBILE | ADMIN */
        public string? ClientType { get; set; }

        /* Token id / device id */
        public string? TokenId { get; set; }

        /* Navigation property - liên kết với User */
        public User User { get; set; } = null!;

        /* Ngày hết hạn RefreshToken */
        public DateTime? RefreshTokenExpiry { get; set; }
    }
}