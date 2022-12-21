using Microsoft.EntityFrameworkCore;
using VendorInvoicing.DataAccess;
using VendorInvoicing.Services;
using Vendors.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DB context service
string connStr = builder.Configuration.GetConnectionString("VendorDb");
builder.Services.AddDbContext<VendorDbContext>(options => options.UseSqlServer(connStr));

// add our vendor manager svc:
builder.Services.AddScoped<IVendorManager, VendorManager>();


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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
