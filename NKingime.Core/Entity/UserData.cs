
namespace NKingime.Core.Entity
{
    /// <summary>
    /// 用户数据
    /// </summary>
    public class UserData
    {

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 日期和时间的计时周期数
        /// </summary>
        public long Ticks { get; set; }
    }
}