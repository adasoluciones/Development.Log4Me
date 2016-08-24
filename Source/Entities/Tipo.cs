using Ada.Framework.Core;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Entities
{
    /// <summary>
    /// Enumeración de los tipos de registros de Log4Me.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    [XmlType("Type")]
    public sealed class Tipo : Enumeracion<string>
    {
        /// <summary>
        /// Constructor que establece el código del tipo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="codigo">Código del tipo.</param>
        private Tipo(string codigo) : base(codigo) { }

        /// <summary>
        /// Obtiene el tipo que indica el inicio de un método. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Tipo Inicio = new Tipo("Start");

        /// <summary>
        /// Obtiene el tipo que indica un parámetro de entrada de un método. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Tipo Parametro = new Tipo("Parameter");

        /// <summary>
        /// Obtiene el tipo que indica una variable de una método. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Tipo Variable = new Tipo("Variable");

        /// <summary>
        /// Obtiene el tipo que indica una excepción lanzada en un método. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Tipo Excepcion = new Tipo("Exception");

        /// <summary>
        /// Obtiene el tipo que indica un mensaje registrado en un método. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Tipo Mensaje = new Tipo("Message");

        /// <summary>
        /// Obtiene el tipo que indica el retorno de un método. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Tipo Retorno = new Tipo("Return");

        /// <summary>
        /// Obtiene el tipo que indica el identificador del flujo. Valor de sólo lectura.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public static readonly Tipo Identificador = new Tipo("Identifier");
    }
}
