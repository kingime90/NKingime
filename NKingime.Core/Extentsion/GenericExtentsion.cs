using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Extentsion
{
    /// <summary>
    /// 泛型扩展方法
    /// </summary>
    public static class GenericExtentsion
    {

        /// <summary>
        /// 对象不为空，返回对象，反之，返回设置的默认值
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="t">泛型实例</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static T IfNull<T>(this T t, T defaultValue)
        {
            return t != null ? t : defaultValue;
        }

        /// <summary>
        /// 如果指定的类型是Int32整型，则返回等效 32 位有符号整数，反之返回默认值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">类型实例</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ToInt<T>(this T t, int defaultValue = 0)
        {
            if (t == null)
            {
                return defaultValue;
            }
            //
            int.TryParse(t.ToString(), out defaultValue);
            //
            return defaultValue;
        }
    }
}
