using System;

namespace Ada.Framework.Development.Log4Me.Entities
{
    /// <summary>
    /// Representación de un registro del log (una línea en el txt).
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class RegistroInLineTO
    {
        /// <summary>
        /// Obtiene o establece el identificador único del hilo(GUID).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string ThreadGUID { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del método(GUID).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string MethodGUID { get; set; }

        /// <summary>
        /// Obtiene o establece el espacio de nombres al que pertenece la clase.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Namespace { get; set; }
        
        /// <summary>
        /// Obtiene o establece el nombre de la clase a la que pertenece el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Clase { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del método de que se está registrando.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Metodo { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de registro.
        /// </summary>
        /// <example>
        ///     -Tipo.Inicio
        ///     -Tipo.Parametro
        ///     -Tipo.Variable
        ///     -Tipo.Excepcion
        ///     -Tipo.Mensaje
        ///     -Tipo.Retorno
        ///     ......
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public Tipo Tipo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en que se registró el evento.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la variable registrada.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string NombreVariable { get; set; }
        
        /// <summary>
        /// Obtiene o establece el valor(estado) de la variable registrada.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string ValorVariable { get; set; }

        /// <summary>
        /// Obtiene o establece la pila de llamados que contiene la excepción.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string StackTrace { get; set; }

        /// <summary>
        /// Obtiene o establece datos adicionales que fueron recogidos al lanzarse la excepción.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Data { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo (clase) de la instancia de excepción.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string TipoExcepcion { get; set; }

        /// <summary>
        /// Obtiene o establece el mensaje del flujo de un método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Mensaje { get; set; }

        /// <summary>
        /// Obtiene o establece el nivel del mensaje.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public Nivel Nivel { get; set; }

        /// <summary>
        /// Obtiene o establece el número (correlativo) de la llamada actual de la instancia en el método.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public int Correlativo { get; set; }
    }
}
