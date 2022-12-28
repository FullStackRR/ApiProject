
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUsersData,UsersData>();

builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IOrderData, OrderData>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryData, CategoryData>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductData, ProductData>();

builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IOrderItemData, OrderItemData>();

builder.Services.AddScoped<IPasswordService,PasswordService>();
builder.Services.AddDbContext<_213836612_web_apiContext>(options=>options.UseSqlServer(@"Data Source=SRV2\PUPILS;Initial Catalog=213836612_web_api;Integrated Security=True"));
var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
