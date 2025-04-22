using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using My_App.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDBContext>(Options =>
{
    var ConnectionString = builder.Configuration.GetConnectionString("ConString");
    Options.UseSqlServer(ConnectionString);
}
);
builder.Services.AddTransient<OpenAIService>();

builder.Services.AddSingleton<OpenAIService>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<VisitorCounter>();
var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customers}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
