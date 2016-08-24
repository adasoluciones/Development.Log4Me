using Ada.Framework.Core;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Entities
{
    /// <summary>
    /// Enumeración de los niveles de mensajes disponibles.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    [XmlType("Level")]
    public sealed class Nivel : Enumeracion<string>
    {
        /// <summary>
        /// Constructor que establece el código del nivel.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="codigo">Código del nivel.</param>
        private Nivel(string codigo) : base(codigo) { }

        /// <summary>
        /// Obtiene el nivel de alerta. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Nivel Alert = new Nivel("Alert");

        /// <summary>
        /// Obtiene el nivel de debug. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Nivel Debug = new Nivel("Debug");

        /// <summary>
        /// Obtiene el nivel de error. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Nivel Error = new Nivel("Error");

        /// <summary>
        /// Obtiene el nivel fatal. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Nivel Fatal = new Nivel("Fatal");

        /// <summary>
        /// Obtiene el nivel de info. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Nivel Info = new Nivel("Info");

        /// <summary>
        /// Obtiene el nivel de éxito. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Nivel Success = new Nivel("Success");
    }
}
