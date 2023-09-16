using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace Account.Common.Util;

public class StringUtil
{
    #region GetFlatString

    public static string GetFlatString(string separator, params string[] parameters)
    {
        return GetFlatString(separator, parameters, false);
    }

    public static string GetFlatStringWithSpace(string separator, params string[] parameters)
    {
        return GetFlatString(separator, parameters, true);
    }

    public static string GetFlatString(string separator, IEnumerable<string> parameters)
    {
        return GetFlatString(separator, parameters, false);
    }

    public static string GetFlatStringWithSpace(string separator, IEnumerable<string> parameters)
    {
        return GetFlatString(separator, parameters, true);
    }

    public static string GetFlatString(Dictionary<string, string> dictionary)
    {
        //Prov: شاید بهتر باشد که یک ورودی برای جدا کننده در متد گذاشته شود
        if (dictionary == null)
            return null;

        //Prov: شاید بهتر باشد این مورد نیز در کانستنت ها گذاشته شود
        const string tripleSpace = Separator.Space + Separator.Space + Separator.Space;

        return GetFlatString(tripleSpace, dictionary.Select(item => GetFlatStringWithSpace(Separator.Colon, item.Key, item.Value)));
    }

    private static string GetFlatString(string separator, IEnumerable<string> list, bool needToAddSpaceForSeparator)
    {
        // این متد بهتر است بصورت آپشنال نوشته شود و گزینه هایی داشته باشد مانند اینکه با جدا کننده شروع شود
        // همچنین در صورت اجرای این مورد متد ویداسپیس برداشته شود
        if (list == null || !list.Any())
            return null;

        if (needToAddSpaceForSeparator)
            separator = Separator.Space + separator + Separator.Space;

        return string.Join(separator, list.Where(x => x != null));
    }

    #endregion

    public static T ConvertToType<T>(string input, bool provUseCommaSeparatorForListType, CultureInfo? culture = null)
    {
        culture ??= new CultureInfo("en-US");

        var separatorForListType = provUseCommaSeparatorForListType ? SeparatorChar.Comma : SeparatorChar.VerticalBar;

        switch (typeof(T))
        {
            #region String

            case var type when type == typeof(string):
            {
                if (string.IsNullOrEmpty(input))
                    return (T)(object)null;

                return (T)(object)input;
            }

            #endregion

            #region Int

            case var type when type == typeof(int):
            {
                int.TryParse(input, NumberStyles.Any, culture, out var result);

                return (T)(object)result;
            }

            #endregion

            #region Int?

            case var type when type == typeof(int?):
            {
                if (string.IsNullOrEmpty(input))
                    return (T)(object)null;

                int.TryParse(input, NumberStyles.Any, culture, out var result);

                return (T)(object)result;
            }

            #endregion

            #region Long

            case var type when type == typeof(long):
            {
                long.TryParse(input, NumberStyles.Any, culture, out var result);

                return (T)(object)result;
            }

            #endregion

            #region Long?

            case var type when type == typeof(long?):
            {
                if (string.IsNullOrEmpty(input))
                    return (T)(object)null;

                long.TryParse(input, NumberStyles.Any, culture, out var result);

                return (T)(object)result;
            }

            #endregion

            #region bool

            case var type when type == typeof(bool):
            {
                bool.TryParse(input, out var result);

                return (T)(object)result;
            }

            #endregion

            #region bool?

            case var type when type == typeof(bool?):
            {
                if (string.IsNullOrEmpty(input))
                    return (T)(object)null;

                bool.TryParse(input, out var result);

                return (T)(object)result;
            }

            #endregion

            #region Float

            case var type when type == typeof(float):
            {
                float.TryParse(input, NumberStyles.Any, culture, out var result);

                return (T)(object)result;
            }

            #endregion

            #region Float?

            case var type when type == typeof(float?):
            {
                if (string.IsNullOrEmpty(input))
                    return (T)(object)null;

                float.TryParse(input, NumberStyles.Any, culture, out var result);

                return (T)(object)result;
            }

            #endregion

            #region Double

            case var type when type == typeof(double):
            {
                double.TryParse(input, NumberStyles.Any, culture, out var result);

                return (T)(object)result;
            }

            #endregion

            #region Double?

            case var type when type == typeof(double?):
            {
                if (string.IsNullOrEmpty(input))
                    return (T)(object)null;

                double.TryParse(input, NumberStyles.Any, culture, out var result);

                return (T)(object)result;
            }

            #endregion

            #region Decimal

            case var type when type == typeof(decimal):
            {
                decimal.TryParse(input, NumberStyles.Any, culture, out var result);

                return (T)(object)result;
            }

            #endregion

            #region Decimal?

            case var type when type == typeof(decimal?):
            {
                if (!string.IsNullOrEmpty(input))
                {
                    decimal.TryParse(input, NumberStyles.Any, culture, out var result);

                    return (T)(object)result;
                }

                return default;
            }

            #endregion

            #region DateTime

            case var type when type == typeof(DateTime):
            {
                if (!string.IsNullOrEmpty(input))
                {
                    DateTime.TryParse(input, culture, DateTimeStyles.None, out var result);

                    return (T)(object)result;
                }

                return default;
            }

            #endregion

            #region DateTime?

            case var type when type == typeof(DateTime?):
            {
                if (!string.IsNullOrEmpty(input))
                {
                    DateTime.TryParse(input, culture, DateTimeStyles.None, out var result);

                    return (T)(object)result;
                }

                return default;
            }

            #endregion

            #region TimeSpan

            case var type when type == typeof(TimeSpan):
            {
                if (!string.IsNullOrEmpty(input))
                {
                    TimeSpan.TryParse(input, culture, out var result);

                    return (T)(object)result;
                }

                return default;
            }

            #endregion

            #region TimeSpan?

            case var type when type == typeof(TimeSpan?):
            {
                if (!string.IsNullOrEmpty(input))
                {
                    TimeSpan.TryParse(input, culture, out var result);

                    return (T)(object)result;
                }

                return default;
            }

            #endregion

            #region Enum

            case var type when type.IsSubclassOf(typeof(System.Enum)):
            {
                var result = System.Enum.Parse(typeof(T), input);

                return (T)result;
            }

            #endregion

            #region List<string>

            // نوع های اینترفیسی به علت تبدیل ران تایم توسط رفلکشن افزوده شده اند. دقت شود که به علت نبود رفرنس حذف نشوند
            case var type when type == typeof(List<string>) || typeof(T) == typeof(IList<string>):
            {
                if (string.IsNullOrEmpty(input))
                    return (T)(object)null;

                return (T)(object)input.Split(separatorForListType).ToList();
            }

            #endregion

            #region List<int>

            case var type when type == typeof(List<int>) || typeof(T) == typeof(IList<int>):
            {
                if (string.IsNullOrEmpty(input))
                    return (T)(object)null;

                var result = new List<int>();
                var listInput = input.Split(separatorForListType);

                foreach (var item in listInput)
                {
                    int.TryParse(item, NumberStyles.Any, culture, out var intInput);
                    result.Add(intInput);
                }

                return (T)(object)result;
            }

            #endregion

            #region List<long>

            case var type when type == typeof(List<long>) || typeof(T) == typeof(IList<long>):
            {
                if (string.IsNullOrEmpty(input))
                    return (T)(object)null;

                var result = new List<long>();
                var listInput = input.Split(separatorForListType);

                foreach (var item in listInput)
                {
                    long.TryParse(item, NumberStyles.Any, culture, out var longInput);
                    result.Add(longInput);
                }

                return (T)(object)result;
            }

            #endregion

            default:
                throw new NotImplementedException();
        }
    }

    public static string? GetWebString(string? text)
    {
        return !string.IsNullOrEmpty(text)
            ? text.Replace(Separator.Enter, Separator.EnterForWeb).Replace(Separator.Enter2, Separator.EnterForWeb)
            : null;
    }

    public static string GetPlainText(string strHtml, bool isAdvanced)
    {
        if (strHtml == null)
            return null;

        //Prov: با ید بررسی شود که آیا این حالت پیشرفته همیشه وجود دارد یا نه. مثلا ممکن است تحت شرایطی بوجود بیاید
        // مثلا بدنه رندر شده را کپی کرده باشیم و بخواهیم از آن استفاده کنیم. در صورتیکه امکان آن وجود داشته باشد
        // کلا این حالت را فعال کنیم
        if (isAdvanced)
        {
            var lineBreakRegex = new Regex(@"<(br|BR)\s{0,1}\/{0,1}>", RegexOptions.Multiline); //matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var stripFormattingRegex = new Regex(@"<[^>]*(>|$)", RegexOptions.Multiline); //match any character between '<' and '>', even when end tag is missing
            var tagWhiteSpaceRegex = new Regex(@"(>|$)(\W|\n|\r)+<", RegexOptions.Multiline); //matches one or more (white space or line breaks) between '>' and '<'

            //Decode html specific characters
            var text = WebUtility.HtmlDecode(strHtml);
            text = RegexUtil.Replace(text, "<(.|\n)*?>", string.Empty);

            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");

            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);

            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            var noHtml = RegexUtil.Replace(text, @"<[^>]*(>|$)|&nbsp;|&zwnj;|&raquo;|&laquo;", string.Empty).Trim();
            noHtml = noHtml.Replace(SeparatorChar.Greater, SeparatorChar.Space);

            return noHtml;
        }

        // 1399-03-07
        // این خط کد به خاطر این گذاشته شد که برخی از کازاکتر های خاص به صورت انکد شده از بدنه اچ-تی-ام-ال گرفته می شوند و در هنگام
        // ویرایش باعث ایجاد خطا می شوند. لذا این مدل کاراکترها به حروف اصلی خودشان تبدیل می شوند
        // این کار باعث می شود که حروف غیرمجاز به صورت مستقیم وارد دیتابیس شوند
        strHtml = WebUtility.HtmlDecode(strHtml);

        return RegexUtil.Replace(strHtml, "<(.|\n)*?>", string.Empty);
    }
}