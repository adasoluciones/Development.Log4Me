
namespace Ada.Framework.Development.Log4Me.Entities
{
    /// <summary>
    /// Representación del registro de un mensaje en el flujo de un método.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class MensajeTO : RegistroTO
    {
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
    }
}
