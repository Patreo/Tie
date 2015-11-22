using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;

namespace Tie.Data.Provider
{
    public class DataProviderBase : ProviderBase
    {
        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        Database Database
        {
            get;
            set;
        }
    }
}
