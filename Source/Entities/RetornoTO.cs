
namespace Ada.Framework.Development.Log4Me.Entities
{
    /// <summary>
    /// Representación del registro del retorno de un método.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class RetornoTO : RegistroTO
    {
        /// <summary>
        /// Obtiene o establece el valor retornado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Valor { get; set; }
    }
}
