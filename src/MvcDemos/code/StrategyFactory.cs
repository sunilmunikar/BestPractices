using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace MvcDemos.code
{
    internal class Program
    {
        //private static void Main(string[] args)
        //{
        //    ConfigureContainer();

        //    IdentifyRoleFactory factory = new IdentifyRoleFactory();

        //    var adminDataService = factory.CreateDataService(RoleNames.Admin);

        //    foreach (var user in adminDataService.GetData())
        //    {
        //        Console.WriteLine("User Id : {0} UserRole : {1}", user.Id, user.UserRole);
        //    }
        //    Console.ReadKey();
        //}

        private static void ConfigureContainer()
        {
            IUnityContainer container = new UnityContainer();

            // register the service implementation
            //container.RegisterType<IBusinessService, BusinessServiceImpl>();
            //container.RegisterType<IRepository<User>, UserRepository>();

            // configure the factory provider
            BusinessServiceFactoryProvider.SetupFactory(new ContainerBusinessServiceFactory(container));
        }
    }

    public class ContainerBusinessServiceFactory : IBusinessServiceFactory
    {
        private readonly IUnityContainer _container;

        public ContainerBusinessServiceFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IBusinessService CreateService()
        {
            return _container.Resolve<IBusinessService>();
        }

        public IRepository<User> CreateUserRepository()
        {
            return _container.Resolve<IRepository<User>>();
        }
    }

    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserRole { get; set; }
    }

    public interface IDataService
    {
        IEnumerable<User> GetData();
    }

    internal class AdminDataService : IDataService
    {
        private readonly IRepository<User> _userRepo;

        public AdminDataService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public IEnumerable<User> GetData()
        {
            Console.WriteLine("Admin data service.");
            return _userRepo.GetAll().Where(x => x.UserRole.Equals(RoleNames.Admin));
        }
    }

    internal class ParticipantDataService : IDataService
    {
        private readonly IRepository<User> _userRepo;

        public ParticipantDataService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public IEnumerable<User> GetData()
        {
            Console.WriteLine("Participant data service.");
            return _userRepo.GetAll().Where(x => x.UserRole.Equals(RoleNames.Participant));
        }
    }

    public class IdentifyRoleFactory
    {
        public IDataService CreateDataService(string role)
        {
            var factoryProvider = new BusinessServiceFactoryProvider();

            var factory = factoryProvider.Factory;

            if (role.Equals(RoleNames.Admin))
                return new AdminDataService(factory.CreateUserRepository());
            return new ParticipantDataService(factory.CreateUserRepository());
        }
    }

    public class RoleNames
    {
        public const string Admin = "admin";
        public const string Participant = "participant";
    }

    public interface IEntity
    {
    }

    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
    }

    public class UserRepository : IRepository<User>
    {
        public IEnumerable<User> GetAll()
        {
            return new List<User>()
                       {
                           new User() {Id = 1, UserRole = RoleNames.Admin},
                           new User() {Id = 2, UserRole = RoleNames.Participant}
                       };
        }
    }
}