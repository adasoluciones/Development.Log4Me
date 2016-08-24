using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Config.Entities
{
    /// <summary>
    /// Representa al filtro aplicable a los registros a logear.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class Filtro
    {
        /// <summary>
        /// Permite obtener o establecer la condición que guarda relación con el ensamblado del registro.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlElement(ElementName = "Assembly")]
        public AssemblyTag Assembly { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que guarda relación con el espacio de nombres del registro.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlElement(ElementName = "NameSpace")]
        public NameSpaceTag NameSpace { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que guarda relación con la clase del registro.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlElement(ElementName = "Class")]
        public ClassTag Clase { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que guarda relación con el método del registro.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlElement(ElementName = "Method")]
        public MethodTag Metodo { get; set; }
    }
}
