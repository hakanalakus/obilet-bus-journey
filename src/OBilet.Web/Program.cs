using OBilet.HttpClient;
using OBilet.Web;
using OBilet.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<OBiletApiSessionBuilderMiddleware>();
builder.Services.AddControllersWithViews();
builder.Services.AddOBiletHttpClient(builder.Configuration);
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromHours(1);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
    opt.Cookie.Name = ".OBilet.Session";
});

builder.Services.AddOBiletWeb();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePagesWithReExecute("");
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseMiddleware<OBiletApiSessionBuilderMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
