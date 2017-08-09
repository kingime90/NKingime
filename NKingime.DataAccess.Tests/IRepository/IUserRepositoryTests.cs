using System;
using NUnit.Framework;
using NKingime.Core.Data;
using NKingime.DataAccess.DbContext;
using Autofac;
using NKingime.Core.Generic;
using System.Reflection;
using NKingime.DataAccess.IRepository;
using NKingime.Entity.Mapping;

namespace NKingime.DataAccess.Tests.IRepository
{
    /// <summary>
    /// 用户数据仓储单元测试
    /// </summary>
    [TestFixture]
    public class IUserRepositoryTests
    {
        private static IContainer container;

        /// <summary>
        /// 初始化
        /// </summary>
        [SetUp]
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            var dependencyType = typeof(IDependency);
            var repositoryAss = Assembly.Load("NKingime.DataAccess");
            var assemblies = new Assembly[] { repositoryAss };
            builder.RegisterAssemblyTypes(assemblies).Where(type => dependencyType.IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();
            container = builder.Build();
            //
            UnitOfWorkContextManage.Register(() => new EFUnitOfWorkContext());
            DbContextManage.Register(() => new NKingimeDb());
        }

        /// <summary>
        /// 测试保存
        /// </summary>
        [Test]
        public void SaveTest()
        {
            var userRepository = container.Resolve<IUserRepository>();
            var user = new User
            {
                Username = "dev012",
                Password = "123456",
                Nickname = "dev011",
                Gender = 1,
                Mobile = "13535555555",
                RegisterDate = DateTime.Now
            };
            var result = userRepository.Save(user, true);
            Assert.IsTrue(result > 0);
        }
    }
}
