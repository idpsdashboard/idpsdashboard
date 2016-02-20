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
        /// Constructor de la clase. Recibe el mensaje de la excepci�n.
        /// </summary>
        /// <param name="message">String conteniendo el mensaje de la excepci�n.</param>
        public SqlImplException(string message) : base(message) { }

        /// <summary>
        /// Constructor de la clase. Recible el mensaje de la excepci�n y una referencia a la excepci�n original.
        /// </summary>
        /// <param name="message">String conteniendo el mensaje de la excepci�n.</param>
        /// <param name="innerException">Objeto Exception conteniendo una referencia a la excepci�n original.</param>
        public SqlImplException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Constructor de la clase. Recibe un objeto SerializationInfo y un StreamingContext.
        /// </summary>
        /// <param name="info">SerializationInfo conteniendo informaci�n de la excepci�n.</param>
        /// <param name="context">StreamingContext.</param>
        public SqlImplException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }

}