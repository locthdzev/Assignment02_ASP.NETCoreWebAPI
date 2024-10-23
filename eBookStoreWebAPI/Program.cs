using BusinessObject.DTOs;
using DataAccess.Repositories.AuthorRepository;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using DataAccess.DAOs;
using DataAccess.Repositories.BookRepository;
using DataAccess.Repositories.PublisherRepository;
using DataAccess.Repositories.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình kết nối cơ sở dữ liệu
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthorDAO>();
builder.Services.AddScoped<BookDAO>();
builder.Services.AddScoped<PublisherDAO>();
builder.Services.AddScoped<UserDAO>();

// Cấu hình OData
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<AuthorDTO>("Author");
modelBuilder.EntitySet<BookDTO>("Book");
modelBuilder.EntitySet<PublisherDTO>("Publisher");
modelBuilder.EntitySet<UserDTO>("User");
modelBuilder.EntitySet<RoleDTO>("Role");

// Thêm dịch vụ OData vào dự án
builder.Services.AddControllers()
    .AddOData(options =>
        options.Select().Expand().Filter().OrderBy().Count().SetMaxTop(100)
            .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

// Thêm Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Đăng ký repository vào DI container
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Sử dụng Swagger trong môi trường phát triển
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
