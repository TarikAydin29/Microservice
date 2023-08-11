using CasgemMicroservice.Services.Catalog.Services.CategoryServices;
using CasgemMicroservice.Services.Catalog.Services.ProductServices;
using CasgemMicroservice.Services.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "resource_catalog";
    options.RequireHttpsMetadata = false;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
builder.Services.AddSingleton<IDbSettings>(st =>
{
    return st.GetRequiredService<IOptions<DbSettings>>().Value;
});


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

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
