namespace MvcDemos.code
{
    public interface IBusinessService
    {
        void DoSomeWork();
    }

    public class BusinessServiceImpl : IBusinessService
    {
        public void DoSomeWork()
        {
            throw new System.NotImplementedException();
        }
    }

    public class SomeAnotherClass
    {
        private readonly IBusinessService _businessService;

        public SomeAnotherClass(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        public void DoThat()
        {
            _businessService.DoSomeWork();
        }
    }

    public class SomeClass
    {
        public void DoThis()
        {
            var factoryProvider = new BusinessServiceFactoryProvider();
            var factory = factoryProvider.Factory;
            SomeAnotherClass someAnother = new SomeAnotherClass(factory.CreateService());
            someAnother.DoThat();
        }
    }

    public interface IBusinessServiceFactory
    {
        IBusinessService CreateService();
        IRepository<User> CreateUserRepository();
    }

    public class BusinessServiceFactoryProvider
    {
        private static IBusinessServiceFactory _factory { get; set; }

        public IBusinessServiceFactory Factory
        {
            get { return _factory; }
        }

        /// <summary>
        /// To be called in the Composition Root
        /// </summary>
        public static void SetupFactory(IBusinessServiceFactory factory)
        {
            _factory = factory;
        }
    }
}