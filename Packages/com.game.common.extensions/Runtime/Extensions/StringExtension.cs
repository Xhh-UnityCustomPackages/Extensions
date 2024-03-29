using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public static class StringExtension
{
    /// <summary>
    /// 尝试转化为枚举
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    /// <returns>转化结果</returns>
    public static T ToEnum<T>(this string self)
    {
        try
        {
            return (T)Enum.Parse(typeof(T), self);
        }
        catch
        {
            return default;
        }
    }
    /// <summary>
    /// 尝试转化为枚举
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    /// <param name="ignoreCase">是否忽略大小写</param>
    /// <returns>转化结果</returns>
    public static T ToEnum<T>(this string self, bool ignoreCase)
    {
        try
        {
            return (T)Enum.Parse(typeof(T), self, ignoreCase);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// 首字母大写
    /// </summary>
    /// <returns>字符串</returns>
    public static string UppercaseFirst(this string self)
    {
        return char.ToUpper(self[0]) + self.Substring(1);
    }

    /// <summary>
    /// 判断一个字符是否为阿拉伯数字
    /// </summary>
    public static bool IsDigit(char c)
    {
        return c >= '0' && c <= '9';
    }


    /// <summary>
    /// 判断一个字符是否为英文小写字母
    /// </summary>
    public static bool IsEnglishLower(char c)
    {
        return c >= 'a' && c <= 'z';
    }


    /// <summary>
    /// 判断一个字符是否为英文大写字母
    /// </summary>
    public static bool IsEnglishUpper(char c)
    {
        return c >= 'A' && c <= 'Z';
    }


    /// <summary>
    /// 判断一个字符是否为英文字母
    /// </summary>
    public static bool IsEnglishLetter(char c)
    {
        return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
    }

}
