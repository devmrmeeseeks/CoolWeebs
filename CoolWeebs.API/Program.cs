using CoolWeebs.API.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseProvider(builder.Configuration);

var app = builder.Build();

// Init DB and apply pending migrations
//using (IServiceScope scope = app.Services.CreateScope())
//{
//    BaseContext baseContext = scope.ServiceProvider.GetRequiredService<BaseContext>();
//    baseContext.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
