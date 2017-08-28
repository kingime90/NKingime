using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Util
{
    /// <summary>
    /// 枚举工具
    /// </summary>
    public class EnumUtil
    {

        /// <summary>
        /// 检索指定枚举中常数名称的数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">枚举类型</param>
        /// <returns></returns>
        public static string[] GetNames<T>(Type enumType = null) where T : struct
        {
            if (enumType == null)
            {
                enumType = typeof(T);
            }
            //
            if (enumType.IsEnum)
            {
                return Enum.GetNames(enumType);
            }
            return null;
        }

        /// <summary>
        /// 转换枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">要转换的枚举名称或基础值的字符串表示形式</param>
        /// <param name="enumType">要将 value 转换为的枚举类型</param>
        /// <param name="ignoreCase">true 表示不区分大小写；false 表示区分大小写</param>
        /// <returns></returns>
        public static T? ConvertToEnum<T>(string value, Type enumType = null, bool ignoreCase = true) where T : struct
        {
            if (enumType == null)
            {
                enumType = typeof(T);
            }
            if (!enumType.IsEnum)
            {
                return null;
            }
            T result;
            if (Enum.TryParse<T>(value, ignoreCase, out result))
            {
                return result;
            }
            return null;
        }

        /// <summary>
        /// 转换枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">要转换的枚举名称或基础值的字符串表示形式</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="enumType">要将 value 转换为的枚举类型</param>
        /// <param name="ignoreCase">true 表示不区分大小写；false 表示区分大小写</param>
        /// <returns></returns>
        public static T ConvertToEnum<T>(string value, T defaultValue, Type enumType = null, bool ignoreCase = true) where T : struct
        {
            var result = ConvertToEnum<T>(value, enumType, ignoreCase);
            if (result != null)
            {
                return result.Value;
            }
            return defaultValue;
        }
    }
}
