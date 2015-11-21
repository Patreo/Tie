using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace Tie.Data
{
    public class Database : IDatabase
    {
        private SqlConnection m_Connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database()
        {
            this.m_Connection = new SqlConnection();
        }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// Connects this instance.
        /// </summary>
        /// <exception cref="System.Exception">ConnectionString is null or empty.</exception>
        /// <exception cref="ConnectionFailedException"></exception>
        public void Connect()
        {
            if (String.IsNullOrEmpty(this.ConnectionString))
            {
                throw new Exception("ConnectionString is null or empty.");
            }

            m_Connection.ConnectionString = this.ConnectionString;
            m_Connection.Open();

            if (m_Connection.State != System.Data.ConnectionState.Open)
            {
                throw new ConnectionFailedException();
            }
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        public void Disconnect()
        {
            if (m_Connection.State == System.Data.ConnectionState.Open)
            {
                this.m_Connection.Close();
            }
        }

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public System.Data.DataSet GetDataSet(string sql)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, this.m_Connection);
            adapter.Fill(ds);

            return ds;
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, this.m_Connection) { CommandType = CommandType.Text };
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public object GetValue(string sql)
        {
            return GetValue(sql, "");
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public object GetValue(string sql, string fieldName)
        {
            DataSet ds = this.GetDataSet(sql);

            if (ds.Tables.Count == 0)
            {
                return null;
            }
            else
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                if (String.IsNullOrEmpty(fieldName))
                {
                    return ds.Tables[0].Rows[0][0];
                }
                else
                {
                    return ds.Tables[0].Rows[0][fieldName];
                }
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public T GetValue<T>(string sql)
        {
            return GetValue<T>(sql, "");
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        public T GetValue<T>(string sql, string fieldName)
        {
            return GetValue<T>(sql, fieldName);
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public IEnumerable<T> Map<T>(string sql)
        {
            return this.m_Connection.Query<T>(sql);
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public IEnumerable<dynamic> Map(string sql)
        {
            return this.m_Connection.Query(sql);
        }

        /// <summary>
        /// Executes the batch.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public int ExecuteBatch(Array array)
        {            
            SqlTransaction transaction = m_Connection.BeginTransaction();
            int intTotal = 0;
            int intAffected = 0;

            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    SqlCommand cmd = new SqlCommand(array.GetValue(i).ToString(), this.m_Connection);
                    cmd.CommandType = CommandType.Text;

                    intAffected = cmd.ExecuteNonQuery();

                    if (intAffected > 0)
                    {
                        intTotal += intAffected;
                    }
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                intTotal = 0;
            }

            return intTotal;
        }
    }
}
