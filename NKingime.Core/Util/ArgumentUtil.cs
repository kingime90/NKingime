using System;

namespace NKingime.Core.Util
{
    /// <summary>
    /// 参数工具
    /// </summary>
    public class ArgumentUtil
    {

        /// <summary>
        /// 条件校验
        /// </summary>
        /// <param name="condition">要满足的条件</param>
        /// <param name="name">参数名称</param>
        public static void Validate(bool condition, string name)
        {
            if (!condition)
            {
                throw new ArgumentException("Invalid argument", name);
            }
        }

        /// <summary>
        /// 条件校验
        /// </summary>
        /// <param name="condition">要满足的条件</param>
        /// <param name="name">参数名称</param>
        /// <param name="message">不满足时提示信息</param>
        public static void Validate(bool condition, string name, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message, name);
            }
        }

        /// <summary>
        /// 空对象检验
        /// </summary>
        /// <typeparam name="T">参数类型，泛型</typeparam>
        /// <param name="value">参数值</param>
        /// <param name="name">参数名</param>
        public static void ThrowIfNull<T>(T value, string name) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// 空对象检验
        /// </summary>
        /// <typeparam name="T">参数类型，泛型</typeparam>
        /// <param name="value">参数值</param>
        /// <param name="name">参数名</param>
        /// <param name="message">为空时提示信息</param>
        public static void ThrowIfNull<T>(T value, string name, string message) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name, message);
            }
        }

        /// <summary>
        /// 空字符串检验
        /// </summary>
        /// <param name="value">参数值</param>
        /// <param name="name">参数名</param>
        public static void ThrowIfNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Argument must be a non empty string", name);
            }
        }

        /// <summary>
        /// 空字符串检验
        /// </summary>
        /// <param name="value">参数值</param>
        /// <param name="name">参数名</param>
        /// <param name="message">为空时提示信息</param>
        public static void ThrowIfNullOrEmpty(string value, string name, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message, name);
            }
        }
    }
}
