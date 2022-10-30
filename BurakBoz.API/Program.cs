using BurakBoz.Core.Repositories;
using BurakBoz.Core.Services;
using BurakBoz.Core.UnitOfWork;
using BurakBoz.Repository;
using BurakBoz.Repository.Repositories;
using BurakBoz.Repository.UnitOfWork;
using BurakBoz.Service.Mapping;
using BurakBoz.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();
builder.Services.AddScoped<IMainCategoryService, MainCategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddDbContext<AppDbContext>(x=> {
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader()
      .AllowAnyMethod()
      .WithOrigins("http://localhost:3000")
      .WithMethods("POST","GET","PUT","DELETE")
      .WithHeaders(HeaderNames.ContentType)
);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

string filePath = Path.GetPathRoot(Environment.SystemDirectory) + "BurakBozWeb";
if (!Directory.Exists(filePath))
{
    DirectoryInfo di = Directory.CreateDirectory(filePath);
    string categoryImageFile = filePath + @"\CategoryImages";
    DirectoryInfo di2 = Directory.CreateDirectory(categoryImageFile);

}

app.Run();
