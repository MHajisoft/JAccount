using System.Data;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using Serilog.Sinks.MSSqlServer;

namespace Account.Common.Util;

public class SerilogInitializer
{
    public static void AddService(WebApplicationBuilder builder)
    {
        string connectionString;
        connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
        
        AddService( connectionString);

        builder.Host.UseSerilog();
    }

    private static void AddService(string connectionString)
    {
        Console.OutputEncoding = Encoding.Unicode;

        //Prov: Handle DevExpress

        var columnOptions = new ColumnOptions();
        columnOptions.AdditionalColumns = new List<SqlColumn>
        {
            new() { ColumnName = "Ip", DataLength = 255, DataType = SqlDbType.VarChar, PropertyName = "Ip" },
            new() { ColumnName = "CreateUser", DataLength = 100, DataType = SqlDbType.VarChar, PropertyName = "CreateUser" },
            new() { ColumnName = "Browser", DataLength = 255, DataType = SqlDbType.VarChar, PropertyName = "Browser" },
        };

        var sqlLogger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .Filter.ByExcluding(x => Matching.FromSource("Microsoft").Invoke(x))
            .Filter.ByExcluding(x => Matching.FromSource("System").Invoke(x))
            .Filter.ByExcluding(x => Matching.FromSource("Serilog").Invoke(x))
            .Enrich.FromLogContext()
            .Enrich.With<HttpContextEnricher>();

        sqlLogger = sqlLogger.WriteTo.MSSqlServer(connectionString: connectionString,
            sinkOptions: new MSSqlServerSinkOptions
            {
                TableName = "Account_Log",
                //SchemaName = "dbo",
                AutoCreateSqlTable = true,
                // BatchPostingLimit = 1,
                // BatchPeriod = TimeSpan.FromSeconds(1)
            },
            columnOptions: columnOptions
        );

        var consoleLogger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Filter.ByExcluding(x => x.Level < LogEventLevel.Information && Matching.FromSource("Microsoft").Invoke(x))
            .Filter.ByExcluding(x => x.Level < LogEventLevel.Information && Matching.FromSource("System").Invoke(x))
            .Filter.ByExcluding(x => x.Level < LogEventLevel.Information && Matching.FromSource("Serilog").Invoke(x))
            .WriteTo.Console();

        var logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Logger(sqlLogger.CreateLogger())
            .WriteTo.Logger(consoleLogger.CreateLogger())
            .CreateLogger();

        Log.Logger = logger;

        AppDomain.CurrentDomain.ProcessExit += (sender, args) => Log.CloseAndFlush();
    }

    public static void UseService(WebApplication app)
    {
        app.UseSerilogRequestLogging();
    }
}
