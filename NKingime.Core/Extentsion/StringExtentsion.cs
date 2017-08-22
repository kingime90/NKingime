using System;
using System.Text;

namespace NKingime.Core.Extentsion
{
    /// <summary>
    /// String扩展方法
    /// </summary>
    public static class StringExtentsion
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 如果指定的字符串不是 null、System.String.Empty 字符串，返回此字符串，反之返回设置的默认值
        /// </summary>
        /// <param name="value">字符串值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string IfNullOrEmpty(this string value, string defaultValue = "")
        {
            return !string.IsNullOrEmpty(value) ? value : defaultValue;
        }

        /// <summary>
        /// 如果指定的字符串不是 null、空、空白字符，返回此字符串，反之返回设置的默认值
        /// </summary>
        /// <param name="value">字符串值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string IfNullOrWhiteSpace(this string value, string defaultValue = "")
        {
            return !string.IsNullOrWhiteSpace(value) ? value : defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="clearWhite"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static string GetString(this string value, bool clearWhite = true, string defValue = "")
        {
            return value != null ? (clearWhite ? value.Trim() : value) : defValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBase64(this string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromBase64(this string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
    }
}
