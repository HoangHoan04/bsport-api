# Hướng dẫn Chạy Migration cho BSport API

## Điều kiện tiên quyết

1. **PostgreSQL** phải được cài đặt và chạy trên máy
2. **Database BSportDB** phải tồn tại (hoặc migration sẽ tự tạo)
3. **.NET 10.0** SDK phải được cài đặt
4. **Entity Framework Core CLI** phải được cài đặt

## Cấu hình Database

Connection string hiện tại trong `appsettings.json`:

```
Host=localhost;Port=5432;Database=BSportDB;Username=postgres;Password=root;
```

Nếu cần thay đổi, hãy cập nhật trong file: `bsport.Api/appsettings.json`

## Các bước chạy Migration

### 1. Cài đặt Entity Framework CLI (Nếu chưa có)

```bash
dotnet tool install --global dotnet-ef
```

### 2. Restore NuGet Packages

```bash
cd bsport-api
dotnet restore
```

### 3. Tạo Initial Migration

```bash
dotnet ef migrations add InitialCreate -p bsport.Infrastructure -s bsport.Api
```

Lệnh này sẽ:

- Tạo folder `Migrations` trong `bsport.Infrastructure`
- Tạo file snapshot của database schema

### 4. Áp dụng Migration (Tạo Database)

```bash
dotnet ef database update -p bsport.Infrastructure -s bsport.Api
```

Lệnh này sẽ:

- Tạo các table trong database
- Áp dụng tất cả các migrations chưa được áp dụng

## Các lệnh hữu ích khác

### Xem các migrations

```bash
dotnet ef migrations list -p bsport.Infrastructure -s bsport.Api
```

### Xem SQL được tạo từ migration

```bash
dotnet ef migrations script -p bsport.Infrastructure -s bsport.Api
```

### Revert migration gần nhất

```bash
dotnet ef database update <migration-name-trước> -p bsport.Infrastructure -s bsport.Api
```

### Remove migration chưa được áp dụng

```bash
dotnet ef migrations remove -p bsport.Infrastructure -s bsport.Api
```

## Troubleshooting

### Lỗi: "Database does not exist"

- Đảm bảo PostgreSQL đang chạy
- Kiểm tra connection string trong appsettings.json
- Nếu database không tồn tại, hãy tạo nó trong PostgreSQL:
  ```sql
  CREATE DATABASE "BSportDB";
  ```

### Lỗi: "Could not connect to server"

- Kiểm tra PostgreSQL đang chạy: `pg_isready -h localhost`
- Kiểm tra username/password trong connection string
- Kiểm tra port 5432 có lắng nghe không

### Lỗi: "Unable to resolve service"

- Đảm bảo đã chạy `dotnet restore`
- Đảm bảo bsport.Infrastructure được referenced trong bsport.Api

## Seed Data (Thêm dữ liệu mẫu)

Sau khi migration hoàn tất, nếu muốn thêm dữ liệu mẫu:

1. Tạo file `SeedData.cs` trong `bsport.Infrastructure/Persistence`
2. Thêm dữ liệu mẫu vào file này
3. Gọi seed data trong `Program.cs` sau khi `app.Build()`:

```csharp
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
    // Gọi seed data method ở đây
}
```

## Kiểm tra kết quả

Sau khi chạy migration thành công, hãy kiểm tra:

1. Kết nối đến PostgreSQL và kiểm tra database:

   ```sql
   \c "BSportDB"
   \dt
   ```

2. Hoặc sử dụng pgAdmin hoặc DBeaver để xem các table

## Lưu ý quan trọng

- Mỗi lần thay đổi entity model, hãy tạo migration mới
- Luôn kiểm tra migration trước khi apply vào production
- Giữ database backup trước khi apply migration
- Không sửa trực tiếp các file trong folder Migrations, hãy tạo migration mới
