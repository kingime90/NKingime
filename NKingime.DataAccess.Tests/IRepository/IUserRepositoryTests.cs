using System;
using NUnit.Framework;
using NKingime.Core.Data;
using NKingime.DataAccess.DbContext;

namespace NKingime.DataAccess.Tests.IRepository
{
    /// <summary>
    /// 用户数据仓储单元测试
    /// </summary>
    [TestFixture]
    public class IUserRepositoryTests
    {

        /// <summary>
        /// 初始化
        /// </summary>
        [SetUp]
        public static void Initialize()
        {
            UnitOfWorkContextManage.Register(() => new EFUnitOfWorkContext());
            DbContextManage.Register(() => new NKingimeDb());
        }

        /// <summary>
        /// 测试保存
        /// </summary>
        [Test]
        public void SaveTest()
        {

        }
    }
}
