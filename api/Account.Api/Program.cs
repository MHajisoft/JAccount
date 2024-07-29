using Account.Api.Base;
using Account.Service.InfraStructure;

var builder = WebApplication.CreateBuilder(args);

BaseInitializer.InitializeServices<AppDbContext>(builder);

var app = builder.Build();

BaseInitializer.InitializeApp<AppDbContext>(app);

app.Run();
