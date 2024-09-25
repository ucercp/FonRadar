using FonRadar.Core.DataAccess.Entities;
using FonRadar.Core.DataAccess.EntityFramework;
using FonRadar.Core.DataAccess.Repositories;
using FonRadar.DataAccess.Abstract;
using FonRadar.DataAccess.Concrete;
using FonRadar.DataAccess;
using FonRadar.Entities;
using FonRadar.Service.Abstract;
using FonRadar.Service.Concrete;
using AutoMapper;
using FonRadar.Service.Mapping;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);
builder.Services.AddScoped(typeof(IEntityRepository<Invoice>), typeof(EfEntityRepositoryBase<Invoice, FonRadarContext>));
builder.Services.AddScoped<IEntity, BaseEntity>();

builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceDal, InvoiceDal>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
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
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
