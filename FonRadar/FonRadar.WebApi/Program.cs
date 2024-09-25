using FonRadar.Core.DataAccess.Entities;
using FonRadar.Core.DataAccess.EntityFramework;
using FonRadar.Core.DataAccess.Repositories;
using FonRadar.DataAccess;
using FonRadar.DataAccess.Abstract;
using FonRadar.DataAccess.Concrete;
using FonRadar.Entities;
using FonRadar.Service.Abstract;
using FonRadar.Service.Concrete;
using FonRadar.Service.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddDbContext<DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(opt =>
	{
		opt.Authority = builder.Configuration["IdentityServerUrl"];
		opt.Audience = "ResourceInvoice"; 
		opt.RequireHttpsMetadata = false;

		opt.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateAudience = true,
			ValidAudiences = new[] { "supplier_scope", "financial_scope" } 
		};
	});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
//{
//	opt.Authority = builder.Configuration["IdentityServerUrl"];
//	opt.Audience = "ResourceInvoice";
//	opt.RequireHttpsMetadata = false;
//});

builder.Services.AddScoped(typeof(IEntityRepository<Invoice>), typeof(EfEntityRepositoryBase<Invoice, FonRadarContext>));
builder.Services.AddScoped<IEntity, BaseEntity>();

builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IHandlerEvent<InvoiceEvent>, SupplierDeclarationHandler>();
builder.Services.AddScoped<IPublisEvent,PublisEvent>();
builder.Services.AddScoped<IInvoiceDal, InvoiceDal>();
// Add services to the container.

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
