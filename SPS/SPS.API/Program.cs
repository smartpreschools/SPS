using SPS.API;
using SPS.Repository.Interface.Common;
using SPS.Repository.Interface.ProductAdmin;
using SPS.Repository.Repository.Common;
using SPS.Repository.Repository.ProductAdmin;
using SPS.Services.Interface.ProductAdmin;
using SPS.Services.Services.ProductAdmin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ApiModule.RegisterDependecy(builder.Services);
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

//Services
builder.Services.AddScoped<ICategoryService,CategoryService>();

//Repository
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

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
