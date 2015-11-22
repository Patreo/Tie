using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Tie.Data
{
    public interface IDatabase
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        string ConnectionString { get; set; }

        /// <summary>
        /// Connects this instance.
        /// </summary>
        void Connect();

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        DataSet GetDataSet(string sql);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        object GetValue(string sql);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        object GetValue(string sql, string fieldName);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        T GetValue<T>(string sql);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        T GetValue<T>(string sql, string fieldName);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        IEnumerable<T> Map<T>(string sql);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        IEnumerable<dynamic> Map(string sql);

        /// <summary>
        /// Executes the batch.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        int ExecuteBatch(Array array);
    }
}
