using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie.Data.Store;

namespace Tie.Data
{
    public class DataStore : Dapper.Database<DataStore>
    {
        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        public Table<Page> Pages
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the page types.
        /// </summary>
        /// <value>
        /// The page types.
        /// </value>
        public Table<PageType> PageTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the languages.
        /// </summary>
        /// <value>
        /// The languages.
        /// </value>
        public Table<Language> Languages
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the page properties.
        /// </summary>
        /// <value>
        /// The page properties.
        /// </value>
        public Table<PageProperty> PageProperties
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the property types.
        /// </summary>
        /// <value>
        /// The property types.
        /// </value>
        public Table<PropertyType> PropertyTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public Table<Parameter> Parameters
        {
            get;
            set;
        }
    }
}
