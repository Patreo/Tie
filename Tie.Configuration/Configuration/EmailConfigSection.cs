using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Tie.Configuration
{
    public class EmailConfigSection : ConfigurationSection
    {

        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        /// <value>The default.</value>
        [ConfigurationProperty("default", DefaultValue = "EmailProvider")]
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
