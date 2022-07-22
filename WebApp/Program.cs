using Contracts.DAL.App;
using DAL.App.DTO.MapperProfiles;
using DAL.App.EF;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using WebApp.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=database.db"));*/

var connectionString = builder.Configuration.GetConnectionString("MsSQL");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
            connectionString)
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging());


builder.Services.AddAutoMapper(
    typeof(AutoMapperProfile),
    typeof(AutoMapperProfiles));


builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});

builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });


builder.Services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();