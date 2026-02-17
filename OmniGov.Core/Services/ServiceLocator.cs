using Microsoft.Extensions.DependencyInjection;

namespace OmniGov.Core.Services
{
    /// <summary>
    /// Service Locator pattern for accessing DI services in WinForms applications
    /// This is a bridge between the DI container and WinForms which doesn't have built-in DI support
    /// </summary>
    public static class ServiceLocator
    {
        private static IServiceProvider? _serviceProvider;

        /// <summary>
        /// Initializes the service locator with a service provider
        /// </summary>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        /// <summary>
        /// Gets a service of the specified type
        /// </summary>
        public static T GetService<T>() where T : notnull
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("ServiceLocator has not been initialized. Call Initialize() first.");

            var service = _serviceProvider.GetService<T>();
            if (service == null)
                throw new InvalidOperationException($"Service of type {typeof(T).Name} is not registered.");

            return service;
        }

        /// <summary>
        /// Gets a required service of the specified type (throws if not found)
        /// </summary>
        public static T GetRequiredService<T>() where T : notnull
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("ServiceLocator has not been initialized. Call Initialize() first.");

            return _serviceProvider.GetRequiredService<T>();
        }

        /// <summary>
        /// Creates a new scope for scoped services
        /// </summary>
        public static IServiceScope CreateScope()
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("ServiceLocator has not been initialized. Call Initialize() first.");

            return _serviceProvider.CreateScope();
        }

        /// <summary>
        /// Checks if the service locator has been initialized
        /// </summary>
        public static bool IsInitialized => _serviceProvider != null;
    }
}
