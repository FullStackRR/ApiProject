
using ApiProject.Middlware;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
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


builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IRatingMiddlewareData, RatingMiddlewareData>();

builder.Services.AddScoped<IPasswordService,PasswordService>();
string connectionString = builder.Configuration.GetConnectionString("school");
//string connectionString = builder.Configuration.GetValue<string>("ConnectionString");
builder.Services.AddDbContext<_213836612_web_apiContext>(options=>options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Host.UseNLog();
var app = builder.Build();
app.UseCacheMiddleware();
app.UseErrorHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCacheMiddleware();
app.UseStaticFiles();

app.UseAuthorization();
app.UseRating();
app.MapControllers();

app.Run();
