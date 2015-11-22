using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using Tie.Data.Provider;

namespace Tie.Data
{
    public sealed class SqlDatabase : DataProviderBase
    {
        private Database m_Database;

        /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);

            this.Database.ConnectionString = ConfigurationManager.ConnectionStrings[config["connectionStringName"]].ConnectionString;
            this.Database.Connect();
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public Database Database
        {
            get
            {
                if (this.m_Database == null)
                {
                    this.m_Database = new Database();
                }

                return this.m_Database;
            }
        }
    }
}
