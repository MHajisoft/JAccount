using Microsoft.Extensions.Configuration;

namespace Account.Common.Util;

public class ConfigurationUtil
{
    private static IConfiguration _configuration = null!;

    public static void Initialize(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static T GetAppSetting<T>(string name, bool needToLower = false, bool needToException = false, bool provUseCommaSeparatorForListType = false)
    {
        var result = _configuration.GetSection("appSettings")[name];

        if (needToException && string.IsNullOrEmpty(result))
            throw new Exception($"App Setting << {name} >> Not Found!");

        result = needToLower ? result?.ToLower() : result;

        return StringUtil.ConvertToType<T>(result, provUseCommaSeparatorForListType);
    }

    public static string? GetConnectionString(string? name = null)
    {
        return _configuration.GetConnectionString(name ?? "LocalSqlServer");
    }
}
