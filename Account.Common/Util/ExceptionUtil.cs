using System.Text;

namespace Account.Common.Util;

public static class ExceptionUtil
{
    public static string GetFullMessageException(this Exception ex)
    {
        var sb = new StringBuilder();

        while (ex != null)
        {
            sb.AppendLine(ex.Message);
            ex = ex.InnerException;
        }

        return sb.ToString();
    }
}