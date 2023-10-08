using System.Text;
using System.Text.Json.Serialization;
using Account.Api.Middleware;
using Account.Common;
using Account.Common.Base;
using Account.Common.Entity;
using Account.Common.Enum;
using Account.Common.IService;
using Account.Common.Util;
using Account.Service.InfraStructure;
using Account.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestSharp;
using Swashbuckle.AspNetCore.SwaggerUI;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

namespace Account.Api.Base;

public abstract class BaseInitializer
{
    public static void InitializeServices<T>(WebApplicationBuilder builder) where T : AppDbContext
    {
        builder.Configuration.AddJsonFile("appsettings.json").AddEnvironmentVariables();

        ConfigurationUtil.Initialize(builder.Configuration);

        #region Database

        builder.Services.AddDbContext<T>(c =>
            c.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"))
                //.UseLazyLoadingProxies()
                .EnableDetailedErrors());

        builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<T>().AddDefaultTokenProviders();

        #endregion

        #region Add services to the container

        builder.Services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();

        /*builder.Services.AddScoped<ICustomConverter, CustomConverter>();
        builder.Services.AddScoped(typeof(ITransManager), typeof(TransManagerEf<T>));*/
        builder.Services.AddScoped<IGeneralTypeService, GeneralTypeService>();
        builder.Services.AddScoped<IPersonService, PersonService>();
        builder.Services.AddScoped<IAttachmentService, AttachmentService>();
        builder.Services.AddScoped<ITransactionService, TransactionService>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

        #endregion

        #region AutoMapper

        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

        #endregion

        #region JWT

        var key = Encoding.ASCII.GetBytes(AccountConstant.JwtSecretKey);
        builder.Services.AddAuthentication(config => { config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters { ValidateIssuerSigningKey = true, IssuerSigningKey = new SymmetricSecurityKey(key), ValidateIssuer = false, ValidateAudience = false };
            });

        #endregion

        #region CORS

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: AccountConstant.CorsPolicy,
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyOrigin();
                    //corsPolicyBuilder.WithOrigins(baseUrlConfig.WebBase.Replace("host.docker.internal", "localhost").TrimEnd('/'));
                    corsPolicyBuilder.AllowAnyMethod();
                    corsPolicyBuilder.AllowAnyHeader();
                });
        });

        #endregion

        builder.Services.AddMemoryCache();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        builder.Services.AddControllers(x => { x.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer())); })
            .AddJsonOptions(x => { x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; });

        builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        // جهت خاموش کردن ولیدیت انتیتی قبل از ورود به کنترلر  
        builder.Services.Configure<ApiBehaviorOptions>(x => x.SuppressModelStateInvalidFilter = true);

        #region Swagger

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = $"JameJafari API", Version = "v1" });
            c.EnableAnnotations();
            c.SchemaFilter<CustomSchemaFilters>();
            c.SchemaFilter<EnumSchemaFilter>();
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = KnownHeaders.Authorization,
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = JwtBearerDefaults.AuthenticationScheme }, Scheme = "oauth2", Name = JwtBearerDefaults.AuthenticationScheme, In = ParameterLocation.Header }, new List<string>() } });

            c.UseInlineDefinitionsForEnums(); //add this...
        });

        builder.Services.AddSwaggerGenNewtonsoftSupport(); // explicit opt-in - needs to be placed after AddSwaggerGen()

        #endregion

        SerilogInitializer.AddService(builder);
    }

    public static async void InitializeApp<T>(WebApplication app) where T : AppDbContext
    {
        SerilogInitializer.UseService(app);

        app.Logger.LogInformation("App created...");

        app.UseDeveloperExceptionPage();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(AccountConstant.CorsPolicy);

        app.UseAuthentication();
        app.UseAuthorization();

        if (app.Environment.IsDevelopment())
        {
            Serilog.Debugging.SelfLog.Enable(Console.Error);
        }
        else
        {
            //به صورت موقت برداشته شده است
            //TODO
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
        }

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "JameJafari API V1");
            c.DocExpansion(DocExpansion.None);
        });

        app.MapControllers();
        app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

        #region Migration

        //ToDo تصمیم گیری در مورد ایجاد داده های اولیه کاربران و نقش ها

        using var scope = app.Services.CreateScope();
        var scopedProvider = scope.ServiceProvider;
        try
        {
            var dbContext = scopedProvider.GetRequiredService<T>();
            await dbContext.Database.MigrateAsync();

            var userManager = scopedProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scopedProvider.GetRequiredService<RoleManager<AppRole>>();

            var list = await roleManager.Roles.ToListAsync();
            if (!list.Any())
            {
                var adminRole = new AppRole { Name = "Admin", Title = "مدیر" };
                var userRole = new AppRole { Name = "User", Title = "کاربر" };
                await roleManager.CreateAsync(adminRole);
                await roleManager.CreateAsync(userRole);

                var adminUser = new AppUser { UserName = "Admin", DisplayName = "مدیر سامانه" };
                await userManager.CreateAsync(adminUser);

                await userManager.AddToRoleAsync(adminUser, "Admin");
                await userManager.AddToRoleAsync(adminUser, "User");

                await userManager.AddPasswordAsync(adminUser, "1qaz!QAZ");

                var accountTypeList = new List<GeneralType>
                {
                    new() { Category = AccountConstant.AccountType, Title = "نقدی", IsActive = true, OrderIndex = 1, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.AccountType, Title = "حواله بانکی", IsActive = true, OrderIndex = 2, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.AccountType, Title = "کارت به کارت", IsActive = true, OrderIndex = 3, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.AccountType, Title = "دستگاه پوز", IsActive = true, OrderIndex = 4, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.AccountType, Title = "چک", IsActive = true, OrderIndex = 5, CreateUserId = 1, CreateDate = DateTime.Now },
                };

                var costTypeList = new List<GeneralType>
                {
                    new() { Category = AccountConstant.CostType, Title = "عمومی", IsActive = true, OrderIndex = 1, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.CostType, Title = "پذیرایی", IsActive = true, OrderIndex = 2, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.CostType, Title = "محرم و صفر", IsActive = true, OrderIndex = 3, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.CostType, Title = "اعیاد", IsActive = true, OrderIndex = 4, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.CostType, Title = "نیمه شعبان", IsActive = true, OrderIndex = 5, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.CostType, Title = "فاطمیه", IsActive = true, OrderIndex = 6, CreateUserId = 1, CreateDate = DateTime.Now },
                };

                var relativeTypeList = new List<GeneralType>
                {
                    new() { Category = AccountConstant.RelativeType, Title = "پدر", IsActive = true, OrderIndex = 1, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.RelativeType, Title = "مادر", IsActive = true, OrderIndex = 2, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.RelativeType, Title = "فرزند", IsActive = true, OrderIndex = 3, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.RelativeType, Title = "برادر", IsActive = true, OrderIndex = 4, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.RelativeType, Title = "خواهر", IsActive = true, OrderIndex = 5, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.RelativeType, Title = "داماد", IsActive = true, OrderIndex = 6, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.RelativeType, Title = "عروس", IsActive = true, OrderIndex = 7, CreateUserId = 1, CreateDate = DateTime.Now },
                };

                var itemTypeList = new List<GeneralType>
                {
                    new() { Category = AccountConstant.ItemType, Title = "شیرینی", IsActive = true, OrderIndex = 1, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.ItemType, Title = "خرما", IsActive = true, OrderIndex = 2, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.ItemType, Title = "سخنرانی", IsActive = true, OrderIndex = 3, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.ItemType, Title = "مداحی", IsActive = true, OrderIndex = 4, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { Category = AccountConstant.ItemType, Title = "متفرقه", IsActive = true, OrderIndex = 1000, CreateUserId = 1, CreateDate = DateTime.Now },
                };

                await dbContext.GeneralTypes.AddRangeAsync(accountTypeList);
                await dbContext.GeneralTypes.AddRangeAsync(costTypeList);
                await dbContext.GeneralTypes.AddRangeAsync(relativeTypeList);
                await dbContext.GeneralTypes.AddRangeAsync(itemTypeList);

                var personList = new List<Person>
                {
                    new() { FirstName = "ناشناس", Gender = Gender.Male, CreateUserId = 1, CreateDate = DateTime.Now },
                    new() { FirstName = "هزینه متفرقه", Gender = Gender.Male, CreateUserId = 1, CreateDate = DateTime.Now },
                };

                await dbContext.Persons.AddRangeAsync(personList);
                
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            app.Logger.LogError(ex, "An error occurred migrating database");
        }

        #endregion

        app.Logger.LogInformation("JameJafari app started...");
    }
}