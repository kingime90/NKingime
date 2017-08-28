using System.Collections.Generic;
using System.Net;

namespace NKingime.Core.Mvc
{
    /// <summary>
    /// HTTP列表响应
    /// </summary>
    public class HttpListResponse<T> : HttpActionResponse
    {

        /// <summary>
        /// HTTP列表响应成功
        /// </summary>
        public HttpListResponse() : base()
        {

        }

        /// <summary>
        /// HTTP列表响应成功
        /// </summary>
        /// <param name="result">结果</param>
        public HttpListResponse(IEnumerable<T> result) : base()
        {
            Result = result;
        }

        public HttpListResponse(HttpStatusCode statusCode, string errMsg) : base(statusCode, errMsg)
        {

        }

        /// <summary>
        /// 结果
        /// </summary>
        public IEnumerable<T> Result { get; set; }
    }
}
