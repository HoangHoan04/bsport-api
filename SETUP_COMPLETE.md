# ✅ Setup Migration Hoàn Tất - BSport API

## Tóm Tắt

Hệ thống migration đã được **thiết lập và cấu hình hoàn toàn**. Database đã được tạo trên PostgreSQL với 7 tables.

---

## 📋 Những gì đã được thiết lập

### 1. **Cấu hình Entity Framework Core**

- ✅ Cài đặt Microsoft.EntityFrameworkCore 9.0.0
- ✅ Cài đặt Npgsql.EntityFrameworkCore.PostgreSQL 9.0.0
- ✅ Cài đặt Entity Framework CLI Tools

### 2. **Tạo DbContext**

- File: `bsport.Infrastructure/Persistence/ApplicationDbContext.cs`
- Cấu hình cho 7 entities: User, Customer, Employee, UserToken, VerifyOtp, EmployeeSchedule, FileArchival
- Cấu hình relationships, indexes, và constraints

### 3. **Migration đầu tiên**

- Migration ID: `20260418092745_InitialCreate`
- Location: `bsport.Infrastructure/Migrations/`
- Status: ✅ **Đã áp dụng vào database**

### 4. **Database đã được tạo**

- **Server:** localhost:5432 (PostgreSQL)
- **Database:** BSportDB
- **7 Tables created:**
  - Users (quản lý người dùng)
  - Customers (khách hàng)
  - Employees (nhân viên)
  - UserTokens (tokens đăng nhập)
  - VerifyOtps (OTP xác thực)
  - EmployeeSchedules (lịch làm việc)
  - FileArchival (lưu trữ file)
  - \_\_EFMigrationsHistory (theo dõi migrations)

---

## 🚀 Các câu lệnh hữu ích

### Xem migrations hiện có

```bash
cd f:\Project\Bsport\bsport-api
dotnet ef migrations list -p bsport.Infrastructure -s bsport.Api
```

### Tạo migration mới (sau khi thay đổi models)

```bash
dotnet ef migrations add <TênMigration> -p bsport.Infrastructure -s bsport.Api
```

### Áp dụng migration mới

```bash
dotnet ef database update -p bsport.Infrastructure -s bsport.Api
```

### Revert về migration trước

```bash
dotnet ef database update <NameMigrationTrước> -p bsport.Infrastructure -s bsport.Api
```

### Xem SQL của migration

```bash
dotnet ef migrations script -p bsport.Infrastructure -s bsport.Api
```

---

## 💾 Thêm Seed Data (Dữ liệu mẫu)

Để thêm dữ liệu mẫu vào database, làm theo các bước:

### 1. Tạo file SeedData

Tạo file `bsport.Infrastructure/Persistence/SeedData.cs`:

```csharp
using bsport.Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace bsport.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Kiểm tra xem đã có dữ liệu chưa
            if (context.Users.Any())
                return;

            // Thêm dữ liệu mẫu
            var users = new List<User>
            {
                new User
                {
                    Username = "admin",
                    Password = "admin123", // Trong thực tế phải hash password
                    IsActive = true,
                    IsAdmin = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = Guid.NewGuid()
                },
                new User
                {
                    Username = "user1",
                    Password = "user123",
                    IsActive = true,
                    IsAdmin = false,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = Guid.NewGuid()
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
```

### 2. Gọi SeedData trong Program.cs

Thêm vào `bsport.Api/Program.cs` trước `app.Run()`:

```csharp
// Seed database with sample data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedData.Initialize(db);
}
```

---

## 🔧 Cấu hình Database

**Connection String (appsettings.json):**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=BSportDB;Username=postgres;Password=root;"
  }
}
```

Nếu cần thay đổi thông tin PostgreSQL:

- **Host:** Thay đổi localhost nếu server khác
- **Port:** Mặc định 5432
- **Database:** BSportDB
- **Username:** postgres
- **Password:** root

---

## 🐛 Troubleshooting

### Database connection failed

```
Error: could not connect to server: Connection refused
```

**Giải pháp:**

- Kiểm tra PostgreSQL đang chạy: `pg_isready -h localhost`
- Kiểm tra username/password trong connection string
- Tạo database nếu chưa tồn tại:
  ```sql
  CREATE DATABASE "BSportDB";
  ```

### Migration failed

```
Error: The specified migration was not found
```

**Giải pháp:**

- Chạy `dotnet ef migrations list` để xem các migration
- Đảm bảo tên migration chính xác

### Changes not applying

```
Error: Unable to resolve service
```

**Giải pháp:**

- Chạy `dotnet restore`
- Đảm bảo Infrastructure project được referenced

---

## 📚 Tài liệu thêm

Xem file `MIGRATION_GUIDE.md` cho hướng dẫn chi tiết hơn.

---

## ✨ Tiếp theo

1. **Thêm seed data** (xem phần trên)
2. **Phát triển APIs** sử dụng DbContext
3. **Tạo migrations mới** khi thay đổi models
4. **Testing** với dữ liệu mẫu

**Setup đã sẵn sàng - Bạn có thể bắt đầu phát triển! 🎉**
