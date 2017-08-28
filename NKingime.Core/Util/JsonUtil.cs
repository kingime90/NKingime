using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace NKingime.Core.Util
{
    /// <summary>
    /// Json工具
    /// </summary>
    public class JsonUtil
    {
        /// <summary>
        /// JSON转换器的默认设置
        /// </summary>
        static JsonUtil()
        {
            if (JsonConvert.DefaultSettings == null)
            {
                JsonConvert.DefaultSettings = () =>
                {
                    var serializerSettings = new JsonSerializerSettings();
                    serializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                    return serializerSettings;
                };
            }
        }

        /// <summary>
        /// 序列化的JSON的字符串
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        /// <summary>
        /// 序列化的JSON的字符串
        /// </summary>
        /// <param name="o"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string Serialize(object o, Formatting format)
        {
            return JsonConvert.SerializeObject(o, format);
        }

        /// <summary>
        /// 反序列化的JSON的动态类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static dynamic Deserialize(string value)
        {
            return JObject.Parse(value);
        }

        /// <summary>
        /// 反序列化的JSON的对象类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }

        /// <summary>
        /// 反序列化的JSON的实体类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <summary>
        /// 反序列化的JSON的匿名类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="anonymousTypeObject"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string value, T anonymousTypeObject)
        {
            try
            {
                return JsonConvert.DeserializeAnonymousType(value, anonymousTypeObject);
            }
            catch
            {
                return anonymousTypeObject;
            }
        }
    }
}
