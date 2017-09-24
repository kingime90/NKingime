
namespace NKingime.Core.Proxy
{
    /// <summary>
    /// 注册代理接口
    /// </summary>
    public interface IProxy
    {

        /// <summary>
        /// 是否启用
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// 存储和检索键
        /// </summary>
        string Key { get; }

        /// <summary>
        /// 优先级（升序）
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 注册
        /// </summary>
        void Register();
    }
}
