using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Configuration;

namespace Tie.Data.Provider
{
    public class DataProviderManager
    {
        private static DataProviderBase defaultProvider;
        private static DataProviderCollection providers;

        /// <summary>
        /// Initializes the <see cref="DataProviderManager"/> class.
        /// </summary>
        static DataProviderManager()
        {
            if (ConfigurationManager.GetSection("ConnectionProvider") != null)
            {
                Initialize();
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private static void Initialize()
        {
            ConnectionConfigSection configuration =
                (ConnectionConfigSection)
                    ConfigurationManager.GetSection("ConnectionProvider");

            if (configuration == null)
            {
                throw new ConfigurationErrorsException
                    ("ConnectionProvider configuration section is not set correctly.");
            }

            providers = new DataProviderCollection();
            ProvidersHelper.InstantiateProviders(configuration.Providers, providers, typeof(DataProviderBase));
            providers.SetReadOnly();
            defaultProvider = providers[configuration.Default];

            if (defaultProvider == null)
            {
                throw new Exception("Default database provider not exist.");
            }
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static DataProviderBase Provider
        {
            get
            {
                return defaultProvider;
            }
        }

        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        public static DataProviderCollection Providers
        {
            get
            {
                return providers;
            }
        }
    }
}
