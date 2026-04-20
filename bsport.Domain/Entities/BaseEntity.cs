using System;
using System.Collections.Generic;
using System.Text;

namespace bsport.Domain.Entities
{
    public class BaseEntity
    {
        // Id của bảng
        public Guid Id { get; set; } = Guid.NewGuid();

        /* Người tạo */
        public Guid CreatedBy { get; set; }

        /* Ngày tạo */
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /* Người cập nhật */
        public Guid UpdatedBy { get; set; }

        /* Ngày cập nhật */
        public DateTime UpdatedAt { get; set; }

        /* Trạng thái xóa mềm */
        public bool IsDeleted { get; set; }

        /* Phiên bản (dùng cho Optimistic Concurrency) */
        public int Version { get; set; } = 1;
    }
}