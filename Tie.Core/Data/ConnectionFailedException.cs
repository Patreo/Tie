using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tie.Data
{
    public  class ConnectionFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFailedException"/> class.
        /// </summary>
        public ConnectionFailedException()
            : base("Connection Failed, see if connection string is well formatted.")
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFailedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ConnectionFailedException(string message)
            : base(message)
        {

        }

    }
}
