using Microsoft.EntityFrameworkCore;
using SignalRBusinessLayer.Abstract;
using SignalRBusinessLayer.Concrete;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.EntityFrameWork;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<SignalRContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
// AutoMapper configuration
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Manager sýnýflarý
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

// Dal sýnýflarý
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();


// Add controllers
builder.Services.AddControllers();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
