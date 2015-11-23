using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tie.Data.Store;

namespace Tie.Data
{
    public class DataStoreHelper
    {
        private static DataStoreHelper m_Instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataStoreHelper"/> class.
        /// </summary>
        /// <param name="Database">The database.</param>
        public DataStoreHelper(DataStore store)
        {
            this.Store = store;
        }


        /// <summary>
        /// Gets or sets the data store.
        /// </summary>
        /// <value>
        /// The data store.
        /// </value>
        public DataStore Store
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static DataStoreHelper Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    Database Database = ((SqlDatabase)Tie.Data.Provider.DataProviderManager.Provider).Database;
                    m_Instance = new DataStoreHelper(Database.Store);
                }

                return m_Instance;
            }
        }

        /// <summary>
        /// Gets the type of the page.
        /// </summary>
        /// <param name="QualifiedName">Name of the qualified.</param>
        /// <returns></returns>
        public PageType GetPageType(string QualifiedName)
        {
            return Instance.Store.PageTypes.All()
                .Where((item) => item.QualifiedName == QualifiedName)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the type of the page.
        /// </summary>
        /// <param name="PageTypeID">The page type identifier.</param>
        /// <returns></returns>
        public PageType GetPageType(int PageTypeID)
        {
            return Instance.Store.PageTypes.All()
                .Where((item) => item.ID == PageTypeID)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the property types.
        /// </summary>
        /// <param name="PageTypeID">The page type identifier.</param>
        /// <returns></returns>
        public IEnumerable<PropertyType> GetPropertyTypes(int PageTypeID)
        {
            return Instance.Store.PropertyTypes.All()
                    .Where((item) => item.PageTypeID == PageTypeID);
        }

        /// <summary>
        /// Gets the property types.
        /// </summary>
        /// <param name="PageTypeID">The page type identifier.</param>
        /// <param name="Name">The name.</param>
        /// <returns></returns>
        public PropertyType GetPropertyTypes(int PageTypeID, string Name)
        {
            return Instance.Store.PropertyTypes.All()
                    .Where((item) => item.PageTypeID == PageTypeID && item.Name == Name)
                    .FirstOrDefault();
        }

        /// <summary>
        /// Gets the page by slug.
        /// </summary>
        /// <param name="PageTypeID">The page type identifier.</param>
        /// <param name="Slug">The slug.</param>
        /// <returns></returns>
        public Page GetPageBySlug(int PageTypeID, string Slug)
        {
            return Instance.Store.Pages.All()
                .Where((item) => item.PageTypeID == PageTypeID && item.Slug.ToLower() == Slug.ToLower())
                .OrderByDescending((item) => item.Version)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <param name="PageID">The page identifier.</param>
        /// <returns></returns>
        public Page GetPage(int PageID)
        {
            return Instance.Store.Pages.All()
                .Where((item) => item.ID == PageID)
                .OrderByDescending((item) => item.Version)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the page property.
        /// </summary>
        /// <param name="PageID">The page identifier.</param>
        /// <param name="PropertyTypeID">The property type identifier.</param>
        /// <returns></returns>
        public PageProperty GetPageProperty(int PageID, int PropertyTypeID)
        {
            return Instance.Store.PageProperties.All()
                .Where((item) => item.PageID == PageID && item.PropertyTypeID == PropertyTypeID)
                .OrderByDescending((item) => item.Version)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the page field.
        /// </summary>
        /// <param name="PageID">The page identifier.</param>
        /// <param name="Key">The key.</param>
        /// <returns></returns>
        public PageField GetPageField(int PageID, string Key)
        {
            return Instance.Store.PageFields.All()
                .Where((item) => item.PageID == PageID && item.Key == Key)
                .OrderByDescending((item) => item.Version)
                .FirstOrDefault();
        }
    }
}
