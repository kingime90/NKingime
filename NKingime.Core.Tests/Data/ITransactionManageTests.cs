using Autofac;
using NKingime.Core.Data;
using NKingime.Core.Generic;
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
        private static IContainer container;
        private static ITransactionManage transactionManage;
        /// <summary>
        /// 初始化
        /// </summary>
        [SetUp]
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            var dependencyType = typeof(IDependency);
            var repositoryAss = Assembly.Load("NKingime.DataAccess");
            var coreAss = Assembly.Load("NKingime.Core");
            var assemblies = new Assembly[] { repositoryAss, coreAss };
            builder.RegisterAssemblyTypes(assemblies).Where(type => dependencyType.IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();
            container = builder.Build();
            //
            UnitOfWorkContextManage.Register(() => new EFUnitOfWorkContext());
            DbContextManage.Register(() => new NKingimeDb());
            //
            transactionManage = container.Resolve<ITransactionManage>();
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
        }
    }
}
