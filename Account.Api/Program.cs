using Account.Service.InfraStructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
        //.UseLazyLoadingProxies()
        .EnableDetailedErrors());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

#region Migration

using var scope = app.Services.CreateScope();
var scopedProvider = scope.ServiceProvider;
try
{
    var dbContext = scopedProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    app.Logger.LogError(ex, "An error occurred migrating database");
}

#endregion

app.Run();