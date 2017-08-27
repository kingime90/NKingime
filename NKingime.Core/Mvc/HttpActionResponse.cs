
using NKingime.Core.Util;
using System;
using System.Net;

namespace NKingime.Core.Mvc
{
    /// <summary>
    /// HTTP动作响应
    /// </summary>
    public abstract class HttpActionResponse : IHttpResponse
    {

        public HttpActionResponse() : this(HttpStatusCode.OK, null)
        {

        }

        public HttpActionResponse(HttpStatusCode statusCode, string errMsg)
        {
            Status = (int)statusCode;
            ErrMsg = errMsg;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            return JsonUtil.Serialize(this);
        }

        public override string ToString()
        {
            return Serialize();
        }
    }

    /// <summary>
    /// 泛型HTTP动作响应
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpActionResponse<T> : HttpActionResponse
    {

        public HttpActionResponse() : base()
        {

        }

        public HttpActionResponse(T result) : this()
        {
            Result = result;
        }

        public HttpActionResponse(HttpStatusCode statusCode, string errMsg) : base(statusCode, errMsg)
        {

        }

        /// <summary>
        /// 结果
        /// </summary>
        public T Result { get; set; }
    }
}
