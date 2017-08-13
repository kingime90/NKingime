using Autofac;
using NKingime.Core.Data;
using NKingime.Core.Ioc;
using NKingime.DataAccess.DbContext;
using NKingime.DataAccess.IRepository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Tests.Data
{
    /// <summary>
    /// 数据事物管理单元测试
    /// </summary>
    [TestFixture]
    public class ITransactionManageTests
    {
        private static ITransactionManage transactionManage;
        /// <summary>
        /// 初始化
        /// </summary>
        [SetUp]
        public static void Initialize()
        {
            IocContainerManage.Build();
            //
            UnitOfWorkContextManage.Register(() => new EFUnitOfWorkContext());
            DbContextManage.Register(() => new NKingimeDb());
            //
            transactionManage = IocContainerManage.IocContainer.Resolve<ITransactionManage>();
        }

        /// <summary>
        /// 测试创建数据仓储
        /// </summary>
        [Test]
        public void CreateTest()
        {
            var userRepository = transactionManage.Create<IUserRepository>();
            int id = 1;
            var user = userRepository.GetById(id);
            //userRepository.WorkContext.Commit();
            //userRepository.WorkContext.DbContext
            //transactionManage.WorkContext.Commit();
            //transactionManage.WorkContext.DbContext
        }
    }
}
