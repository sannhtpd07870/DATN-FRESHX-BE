using Freshx_API.Interfaces;
using Freshx_API.Repository;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Freshx_API.Services;
using Freshx_API.Mappers;
using System.Text;
using Azure.Identity;
using DotNetEnv;
// Tải biến môi trường từ tệp .env
Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Đọc password và salt từ biến môi trườn g
string password = Environment.GetEnvironmentVariable("ENCRYPTION_PASSWORD");
?? builder.Configuration["EncryptionSettings:Password"]
?? "DefaultPassword";
string saltString = Environment.GetEnvironmentVariable("ENCRYPTION_SALT");
?? builder.Configuration["EncryptionSettings:Salt"]
?? "DefaultSalt";
//kết thúc biến môi trường
    
// Kiểm tra nếu không lấy được biến môi trường và dừng quá trình build
if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(saltString))
{
    Console.WriteLine("Lỗi: Không thể lấy được ENCRYPTION_PASSWORD hoặc ENCRYPTION_SALT từ biến môi trường.");
    throw new InvalidOperationException("Dừng quá trình build vì thiếu biến môi trường.");
}

byte[] salt = Encoding.UTF8.GetBytes(saltString);


builder.Configuration.AddConfiguration(
    new ConfigurationBuilder()
        .Add(new EncryptedConfigurationSource( password, salt))
        .Build());

var connectionString = builder.Configuration["ConnectionStrings:DBFreshx"];
var jwtKey = builder.Configuration["Jwt:Key"];
var blobConnectionString = builder.Configuration["AzureBlobStorage:ConnectionString"];
var containerName = builder.Configuration["AzureBlobStorage:ContainerName"];

// Add services to the container.
builder.Services.AddDbContext<FreshxDBContext>(options =>{
    options.UseSqlServer(connectionString);
        });
    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Thêm cấu hình AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    // Thêm các profile của bạn ở đây
    // mc.AddProfile(new YourAutoMapperProfile());
});

builder.Services.AddScoped<BlobServices>();
builder.Services.AddScoped<IFilesRepository, FileRepository>();

// Thêm AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Thêm DefaultAzureCredential
builder.Services.AddSingleton<DefaultAzureCredential>();

var app = builder.Build();

// Cấu hình CORS để cho phép truy cập từ mọi nguồn
// Enable CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();

