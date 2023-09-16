using Account.Api.Base;
using Account.Service.InfraStructure;

var builder = WebApplication.CreateBuilder(args);

BaseInitializer.InitializeServices<AppDbContext>(builder);

var app = builder.Build();

BaseInitializer.InitializeApp<AppDbContext>(app);

using var fileServerProviderScope = app.Services.CreateScope();

try
{
    //ToDo تصمیم گیری در مورد ایجاد داده های اولیه کاربران و نقش ها

    /*
    using var scope = app.Services.CreateScope();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
*/
}
catch (Exception ex)
{
    app.Logger.LogError(ex, "An error occurred seeding the DB");
}

app.Run();
