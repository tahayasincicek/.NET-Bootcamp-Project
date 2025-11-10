using BootcampProject.Business.Abstracts;
using BootcampProject.Business.BusinessRules;
using BootcampProject.Business.Mapping;
using Core.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IApplicationService, ApplicationManager>();
builder.Services.AddScoped<ApplicationBusinessRules>();
builder.Services.AddAutoMapper(typeof(ApplicationProfile).Assembly);
builder.Services.AddTransient<GlobalExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<GlobalExceptionMiddleware>(); // Hata yönetimi

app.MapControllers();

app.Run();
