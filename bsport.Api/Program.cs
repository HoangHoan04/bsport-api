// Import các namespace cần thiết
using bsport.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// ==================== CẤU HÌNH KẾT NỐI DATABASE POSTGRESQL ====================
// Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Thêm DbContext với PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)
           // Hiển thị log chi tiết khi chạy ở môi trường Development
           .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
);
// ==================== CẤU HÌNH SWAGGER PHÂN NHÓM ====================
builder.Services.AddSwaggerGen(c =>
{
    // Sử dụng trực tiếp OpenApiInfo nhờ lệnh using ở trên
    c.SwaggerDoc("admin", new OpenApiInfo
    {
        Title = "BSport Admin API",
        Version = "v1",
        Description = "API dành cho trang quản trị Admin"
    });

    c.SwaggerDoc("client", new OpenApiInfo
    {
        Title = "BSport Client API",
        Version = "v1",
        Description = "API dành cho Website khách hàng"
    });

    c.SwaggerDoc("mobile", new OpenApiInfo
    {
        Title = "BSport Mobile API",
        Version = "v1",
        Description = "API dành cho Ứng dụng di động"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Kích hoạt Swagger và Swagger UI ở môi trường Development
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Cấu hình 3 endpoint tương ứng với 3 nhóm API đã tạo
        c.SwaggerEndpoint("/swagger/admin/swagger.json", "Admin API");
        c.SwaggerEndpoint("/swagger/client/swagger.json", "Client API");
        c.SwaggerEndpoint("/swagger/mobile/swagger.json", "Mobile API");

        // Tùy chọn UI
        c.DisplayRequestDuration(); // Hiển thị thời gian phản hồi API
        c.DocExpansion(DocExpansion.None); // Mặc định ẩn tất cả API
        c.DefaultModelsExpandDepth(-1); // Ẩn phần Models ở dưới trang
        c.EnableDeepLinking(); // Hỗ trợ liên kết trực tiếp đến mỗi API
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
