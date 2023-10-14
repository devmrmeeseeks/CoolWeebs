using CoolWeebs.API;
using CoolWeebs.API.Database;
using CoolWeebs.API.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container Web Application.
builder.Services.AddControllersWithViews();

// Add services to the container API.
builder.Services.AddCoolWeebsApi(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // API
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoolWeebs API V1");
    });
} else
{
    // Web Application
    app.UseExceptionHandler("/Home/Error");
}

// Init DB and apply pending migrations
using (IServiceScope scope = app.Services.CreateScope())
{
    BaseContext baseContext = scope.ServiceProvider.GetRequiredService<BaseContext>();
    baseContext.Database.Migrate();
}

// Middlewares
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// API
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
