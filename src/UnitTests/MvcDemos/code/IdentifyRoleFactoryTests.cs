using System.Collections.Generic;
using FakeItEasy;
using Microsoft.Practices.Unity;
using MvcDemos.code;
using Xunit;

namespace UnitTests.MvcDemos.code
{
    public class IdentifyRoleFactoryTests
    {
        private readonly IRepository<User> fakeRepo;
        //private readonly IBusinessServiceFactory _factory;

        public IdentifyRoleFactoryTests()
        {
            fakeRepo = A.Fake<IRepository<User>>();
            //_factory = A.Fake<IBusinessServiceFactory>();
        }

        [Fact]
        public void GivenAdminRole_CreateDataService_ReturnAdminUsers()
        {
            ConfigureContainer();

            var aUser = new List<User>
                            {
                                new User
                                    {
                                        Id = 1,
                                        UserRole = RoleNames.Admin
                                    }
                            };

            A.CallTo(() => fakeRepo.GetAll()).Returns(aUser);

            IdentifyRoleFactory factory = new IdentifyRoleFactory();
            IDataService result = factory.CreateDataService(RoleNames.Admin);

            Assert.NotNull(result.GetData());
        }

        private static void ConfigureContainer()
        {
            IUnityContainer container = new UnityContainer();

            // register the service implementation
            container.RegisterType<IBusinessService, BusinessServiceImpl>();
            container.RegisterType<IRepository<User>, UserRepository>();

            // configure the factory provider
            BusinessServiceFactoryProvider.SetupFactory(new ContainerBusinessServiceFactory(container));
        }
    }
}