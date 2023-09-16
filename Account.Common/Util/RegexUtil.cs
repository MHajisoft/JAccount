using System.Text.RegularExpressions;

namespace Account.Common.Util;

public class RegexUtil
{
    public static string GetMatch(string input, string pattern)
    {
        return string.IsNullOrEmpty(input) ? null : Regex.Match(input, pattern).Groups[1].Value;
    }

    public static bool IsMatch(string input, string pattern, bool needToExactMatch = false)
    {
        //Prov: علت استفاده از فلگ و پارامتر سوم اینه که میخواهیم ماسک ارسال شده فقط یکبار انجام شده باشد، احتمالا باید این روند برای تمامی فراخوانی های این متد در نظر گرفته شود
        // اما از آنجایی که سایر استفاده ها در کلاینت توسط ماسک محدود شده اند لذا فعلا این فیلتر اعمال نمی شود، در ادامه کار باید دید آیا لازم است این فلگ به صورت عمومی اعمال شود
        if (needToExactMatch)
            pattern = $"{Separator.Caret}{pattern}{Separator.Dollar}";

        return Regex.IsMatch(input, pattern);
    }

    public static string Replace(string input, string pattern, string replacement)
    {
        return Regex.Replace(input, pattern, replacement);
    }
}