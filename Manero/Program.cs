using Manero.Contexts;
using Manero.Middleware;
using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Manero.Repositories;
using Manero.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


// Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlDatabase")));


// Identities
builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<DataContext>()
  .AddDefaultTokenProviders();



// Add Repositories (eg. builder.Services.AddScoped<CategoryRepository>(); )
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductTagRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<ProductCategoryRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ProductReviewRepository>();
builder.Services.AddScoped<ProductVariantRepository>();
builder.Services.AddScoped<ColorRepository>();
builder.Services.AddScoped<SizeRepository>();
builder.Services.AddScoped<IAdressRepository, AdressRepository>();
builder.Services.AddScoped<IUserAdressRepository, UserAdressRepository>();
builder.Services.AddScoped<ProductImageRepository>();
builder.Services.AddScoped<ImageRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderRowRepository, OrderRowRepository>();
builder.Services.AddScoped<CheckoutRepository>();
builder.Services.AddScoped<IPromocodeRepository, PromocodeRepository>();
builder.Services.AddScoped<UserPromocodeRepository>();
builder.Services.AddScoped<UserPaymentMethodsRepository>();
builder.Services.AddScoped<PaymentMethodRepository>();


// Add Services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IPaymentService ,PaymentService>();
builder.Services.AddScoped<IUserManagerProvider, UserService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});



var app = builder.Build();
app.UseHttpsRedirection();
app.UseHsts();
app.UseStaticFiles();
app.UseMiddleware<EssentialCookieConsentMiddleware>();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "productReviews",
    pattern: "product/{articleNumber}/reviews",
    defaults: new { controller = "Product", action = "Reviews" });
app.MapControllerRoute(
    name: "cardDetails",
    pattern: "payment/carddetails/{id}",
    defaults: new { controller = "Payment", action = "CardDetails" });
app.MapControllerRoute(
    name: "editCard",
    pattern: "payment/edit/{id}",
    defaults: new { controller = "Payment", action = "Edit" });



app.Run();

