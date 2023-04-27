namespace Infrastructure.Services
{
    public class ServiceLocator
    {
        private static ServiceLocator instance;
        public static ServiceLocator Container => instance ??= new ServiceLocator();

        public void RegisterSingle<TService>(TService implementaton) where TService : IService
        {
            Implementation<TService>.ServiceInstance = implementaton;
        }

        public TService Single<TService>() where TService : IService
        {
            return Implementation<TService>.ServiceInstance;
        }

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}