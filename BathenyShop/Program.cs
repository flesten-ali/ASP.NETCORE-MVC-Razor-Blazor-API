using BathenyShop;
using BathenyShop.App;
using BathenyShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);




//DI
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddDbContext<BathenyShopDbContext>(opt =>
opt.UseSqlServer(
    builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection"))
);
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<BathenyShopDbContext>();

//enable mvc support
builder.Services.AddControllersWithViews()
  .AddJsonOptions(op =>
  op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
  );

////////sessions/////////
// the ShoppingCart that return from GetCart will be injected (per request (Scoped))
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serviceProvider => ShoppingCart.GetCart(serviceProvider));
// support sessions
builder.Services.AddSession();
// since we needed to access IHttpContextAccessor in GetCart
builder.Services.AddHttpContextAccessor();
/////////////////
///
// Razor pages
builder.Services.AddRazorPages();

// add Blazor Server Rendering 
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();

// show the exceptions page
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
//try to add my custome mw
app.UseMiddleware<UseCustomeMiddleware>();
//return any requested static file middle war
app.UseStaticFiles();


// support sessions
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();




// handle (route) incoming req to the {controllers}/{action}/{id?}  route // have to go at the end
//id? mean optional id
//app.MapDefaultControllerRoute();
//app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Blazor
app.UseAntiforgery();

// Razor pages
app.MapRazorPages();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();


// Blazor
DbInitializer.Seed(app);
app.Run();
