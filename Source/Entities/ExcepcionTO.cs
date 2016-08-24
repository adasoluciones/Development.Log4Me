
namespace Ada.Framework.Development.Log4Me.Entities
{
    /// <summary>
    /// Representación del registro de una excepción.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class ExcepcionTO : RegistroTO
    {
        /// <summary>
        /// Obtiene o establece el mensaje de la excepción.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Mensaje { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo (clase) de la instancia de excepción.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Tipo { get; set; }

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
    }
}
