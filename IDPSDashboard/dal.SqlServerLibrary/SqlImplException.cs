using System;
using System.Runtime.Serialization;

namespace dal.SqlServerLibrary
{
    public class SqlImplException : ApplicationException
    {
        /// <summary>
        /// Constructor de la clase. No posee parametros. Utilizado por defecto.
        /// </summary>
        public SqlImplException() : base() { }

        /// <summary>
        /// Constructor de la clase. Recibe el mensaje de la excepción.
        /// </summary>
        /// <param name="message">String conteniendo el mensaje de la excepción.</param>
        public SqlImplException(string message) : base(message) { }

        /// <summary>
        /// Constructor de la clase. Recible el mensaje de la excepción y una referencia a la excepción original.
        /// </summary>
        /// <param name="message">String conteniendo el mensaje de la excepción.</param>
        /// <param name="innerException">Objeto Exception conteniendo una referencia a la excepción original.</param>
        public SqlImplException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor de la clase. Recibe un objeto SerializationInfo y un StreamingContext.
        /// </summary>
        /// <param name="info">SerializationInfo conteniendo información de la excepción.</param>
        /// <param name="context">StreamingContext.</param>
        public SqlImplException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }

}