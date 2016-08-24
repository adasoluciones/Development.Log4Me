using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Config.Entities
{
    /// <summary>
    /// Tag que representa un método.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class MethodTag : CondicionSimple
    {
        /// <summary>
        /// Permite obtener o establecer el valor que indica si se debe exigir que la clase haya sido declarada como pública.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public bool isPublic { get; set; }

        /// <summary>
        /// Permite obtener o establecer el valor que indica si se debe exigir que la clase haya sido declarada como privada.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public bool isPrivate { get; set; }

        /// <summary>
        /// Permite obtener o establecer el valor que indica si se debe exigir que la clase haya sido declarada como interna (de un ensamblado).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public bool isInternal { get; set; }

        /// <summary>
        /// Permite obtener o establecer el valor que indica si se debe exigir que la clase haya sido declarada como estática (de un ensamblado).
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public bool isStatic { get; set; }
    }
}
