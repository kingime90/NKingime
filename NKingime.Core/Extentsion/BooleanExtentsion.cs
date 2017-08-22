using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Extentsion
{
    /// <summary>
    /// 
    /// </summary>
    public static class BooleanExtentsion
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseValue"></param>
        /// <returns></returns>
        public static T If<T>(this bool value, T trueValue, T falseValue)
        {
            return value ? trueValue : falseValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseValue"></param>
        /// <returns></returns>
        public static T If<T>(this bool? value, T trueValue, T falseValue)
        {
            return value != null && value.Value ? trueValue : falseValue;
        }
    }
}
