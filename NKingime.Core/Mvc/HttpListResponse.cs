using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Mvc
{
    /// <summary>
    /// HTTP列表响应
    /// </summary>
    public class HttpListResponse<T> : HttpActionResponse
    {
        public HttpListResponse() : base()
        {

        }

        public HttpListResponse(IEnumerable<T> result) : this()
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
