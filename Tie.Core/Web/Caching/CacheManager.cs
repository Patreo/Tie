using System;
using System.Web;
using System.Web.Caching;

namespace Tie.Web.Caching
{

    public static class CacheManager
    {
        public delegate T Fetcher<T, D>(D data);
        public delegate T ParameterlessFetcher<T>();

        /// <summary>
        /// Gets from cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="D"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="dependencies">The dependencies.</param>
        /// <param name="fetcher">The fetcher.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static T GetFromCache<T, D>(string key, string[] dependencies, Fetcher<T, D> fetcher, D data)
        {
            T result = GetFromCache<T>(key);

            if (result == null)
            {
                result = fetcher(data);

                if (result != null)
                {
                    AddToCache(key, dependencies, result);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets from cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="dependencies">The dependencies.</param>
        /// <param name="fetcher">The fetcher.</param>
        /// <returns></returns>
        public static T GetFromCache<T>(string key, string[] dependencies, ParameterlessFetcher<T> fetcher)
        {
            T result = GetFromCache<T>(key);

            if (result == null)
            {
                result = fetcher();

                if (result != null)
                {
                    AddToCache(key, dependencies, result);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets from cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static T GetFromCache<T>(string key)
        {
            if (HttpContext.Current == null)
            {
                return default(T);
            }
            else
            {
                return (T)HttpContext.Current.Cache[key];                
            }
        }

        /// <summary>
        /// Ensures the dependency.
        /// </summary>
        /// <param name="dependencyKey">The dependency key.</param>
        private static void EnsureDependency(string dependencyKey)
        {
            if (HttpContext.Current.Cache[dependencyKey] == null)
            {
                HttpContext.Current.Cache[dependencyKey] = DateTime.Now;
            }
        }

        /// <summary>
        /// Adds to cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dependencies">The dependencies.</param>
        /// <param name="dataToCache">The data to cache.</param>
        public static void AddToCache(string key, string[] dependencies, object dataToCache)
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            if (dependencies != null && dependencies.Length > 0)
            {
                Array.ForEach(dependencies, (d) => { EnsureDependency(d); });
            }

            if (dataToCache == null)
            {

            }
            else
            {
                HttpContext.Current.Cache.Insert(key, dataToCache, new CacheDependency(null, dependencies), System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(60));
            }
        }

        #region Private functions

        /// <summary>
        /// Removes from cache.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void RemoveFromCache(string key)
        {
            if (HttpContext.Current == null)
            {
                return;
            }

            HttpContext.Current.Cache.Remove(key);
        }

        #endregion

    }
}
