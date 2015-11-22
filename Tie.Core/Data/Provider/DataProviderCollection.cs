using System;
using System.Configuration.Provider;
using Tie.Data.Provider;

namespace Tie.Data.Provider
{

    public class DataProviderCollection : ProviderCollection
    {
        /// <summary>
        /// Gets the <see cref="DataProviderBase"/> with the specified name.
        /// </summary>
        /// <value>
        /// The <see cref="DataProviderBase"/>.
        /// </value>
        /// <param name="Name">The name.</param>
        /// <returns></returns>
        new public DataProviderBase this[string Name]
        {
            get { return (DataProviderBase)base[Name]; }
        }
    }

}
