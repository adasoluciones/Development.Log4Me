using Ada.Framework.Core;

namespace Ada.Framework.Development.Log4Me.Writers
{
    /// <summary>
    /// Enumeración de los modos de los writers disponibles.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public sealed class Modo : Enumeracion<string>
    {
        /// <summary>
        /// Obtiene o establece el código del modo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        private Modo(string codigo) : base(codigo) { }

        /// <summary>
        /// Obtiene el modo encendido (On). Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Modo On = new Modo("On");

        /// <summary>
        /// Obtiene el modo apagado (Off). Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Modo Off = new Modo("Off");
    }
}
