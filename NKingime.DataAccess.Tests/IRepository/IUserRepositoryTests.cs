using System;
using NUnit.Framework;
using NKingime.Core.Data;
using NKingime.DataAccess.DbContext;
using Autofac;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;
using NKingime.Core.Ioc;

namespace NKingime.DataAccess.Tests.IRepository
{
    /// <summary>
    /// 用户数据仓储单元测试
    /// </summary>
    [TestFixture]
    public class IUserRepositoryTests
    {
        private static IUserRepository userRepository;

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
            userRepository = IocContainerManage.IocContainer.Resolve<IUserRepository>();
        }

        /// <summary>
        /// 测试保存
        /// </summary>
        [Test]
        public void SaveTest()
        {
            var user = new User
            {
                Username = "admin",
                Password = "admin",
                Nickname = "admin",
                Gender = 1,
                Mobile = "13535555555",
                Enabled = 1,
                RegisterDate = DateTime.Now
            };
            var result = userRepository.Save(user, true);
            Assert.IsTrue(result > 0);
        }

        /// <summary>
        /// 根据主键获取单个数据实体
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            int id = 1;
            var user = userRepository.GetById(id);
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// 测试更新
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            int id = 1;
            string mobile = "13588888888";
            var user = userRepository.GetById(id);
            user.Mobile = mobile;
            userRepository.Update(user);
            user = userRepository.GetById(id);
            Assert.IsTrue(user.Mobile == mobile);
        }

        /// <summary>
        /// 测试根据主键删除单个数据实体
        /// </summary>
        [Test]
        public void DeleteByIdTest()
        {
            int id = 3;
            var result = userRepository.DeleteById(id);
            Assert.IsTrue(result > 0);
        }
    }
}
