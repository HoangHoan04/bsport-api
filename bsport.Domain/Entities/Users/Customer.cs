using System;
using System.Collections.Generic;

namespace bsport.Domain.Entities.Users
{
    public class Customer : BaseEntity
    {
        /* Mã khách hàng */
        public string Code { get; set; } = string.Empty;

        /* Tên khách hàng */
        public string Name { get; set; } = string.Empty;

        /* Tên nickname */
        public string? Nickname { get; set; }

        /* Số điện thoại */
        public string? Phone { get; set; }

        /* Giới tính */
        public string? Gender { get; set; }

        /* Ngày sinh */
        public DateTime? Birthday { get; set; }

        /* Id loại khách hàng */
        public Guid? CustomerTypeId { get; set; }

        /* Mã loại khách hàng */
        public string? CustomerTypeCode { get; set; }

        /* Tên loại khách hàng */
        public string? CustomerTypeName { get; set; }

        /* Email */
        public string? Email { get; set; }

        /* Số CCCD / CMND */
        public string? IdCard { get; set; }

        /* Ngày cấp CCCD */
        public DateTime? IdCardIssuedDate { get; set; }

        /* Nơi cấp CCCD */
        public string? IdCardIssuedPlace { get; set; }

        /* Đã xác thực chưa */
        public bool IsVerified { get; set; } = false;

        /* Link mạng xã hội */
        public string? SocialLink { get; set; }

        /* Firebase Cloud Messaging Token */
        public string? FmcToken { get; set; }

        /* Có phải học sinh/sinh viên? */
        public bool IsStudent { get; set; } = false;

        /* Có tham gia giải đấu? */
        public bool IsTournament { get; set; } = false;

        /* Có đặt sân? */
        public bool IsBooking { get; set; } = false;

        /* Địa chỉ */
        public string? Address { get; set; }

        /* Ghi chú */
        public string? Description { get; set; }

        /* ======================== FILE ======================== */

        /* Avatar / Ảnh đại diện */
        public string? Avatar { get; set; }

        /* Ảnh CCCD mặt trước */
        public string? IdCardFrontUrl { get; set; }

        /* Ảnh CCCD mặt sau */
        public string? IdCardBackUrl { get; set; }

        /* Ảnh chân dung (KYC) */
        public string? PortraitUrl { get; set; }

        /* Ảnh thẻ học sinh / sinh viên */
        public string? StudentCardUrl { get; set; }

        /* ======================== NAVIGATION ======================== */

        /* Navigation property - liên kết với User */
        public User? User { get; set; }

        /* Navigation property - file đính kèm */
        public ICollection<FileArchival> Files { get; set; } = new List<FileArchival>();
    }
}