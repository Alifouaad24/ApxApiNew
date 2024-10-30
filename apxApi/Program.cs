//using AinAlfahd.BL;
//using AinAlfahd.Data;
//using Microsoft.EntityFrameworkCore;
using AinAlfahd.BL;
using AinAlfahd.Data;
using apxApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "A sample ASP.NET Core API"
    });
});

builder.Services.AddDbContext<MasterDBContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("FirstConnect")));


builder.Services.AddScoped<ICustomer, CutomerRepo>();
builder.Services.AddScoped<ApiResponse>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddRazorPages();





var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.Run();
