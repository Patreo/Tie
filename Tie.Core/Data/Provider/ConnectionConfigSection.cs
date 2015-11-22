using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Tie
{
    public class ConnectionConfigSection : ConfigurationSection
    {

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        /// <value>The default.</value>
        [ConfigurationProperty("default", DefaultValue = "SqlProvider")]
        public string Default
        {
            get { return (string)base["default"]; }
            set { base["default"] = value; }
        }

        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get { return (ProviderSettingsCollection)base["providers"]; }
        }
    }
}
