using AutenticacaoComEmail.Data;
using AutenticacaoComEmail.Data.Ef;
using AutenticacaoComEmail.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var coon = builder.Configuration.GetConnectionString("EmailConn");
// Add services to the container.
builder.Services.AddTransient<IUserDao, UserDaoComEfCore>();
builder.Services.AddTransient<IEmailDao, EmailDaoEfCore>();
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseMySql(coon,ServerVersion.AutoDetect(coon));
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
