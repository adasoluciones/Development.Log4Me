using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Config.Entities
{
    /// <summary>
    /// Representa una condición simple de valores.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class CondicionSimple
    {
        /// <summary>
        /// Permite obtener o establecer la condición que el valor a comparar contenga el valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string Contains { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que el valor a comparar no contenga el valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string NotContains { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que el valor a comparar termine en el valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string EndWith { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que el valor a comparar no termine en el valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string NotEndWith { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que el valor a comparar sea igual al valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public new string Equals { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que el valor a comparar no sea igual al valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string NotEquals { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que el valor completo a comparar sea igual al valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string FullEquals { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que el valor completo a comparar no sea igual al valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string NotFullEquals { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que el valor a comparar comience por el valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string StartWith { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición que el valor a comparar no comience por el valor de esta propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string NotStartWith { get; set; }

        /// <summary>
        /// Permite obtener o establecer la condición de si se debe tomar o no en cuenta las mayúsculas.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public bool IgnoreCase { get; set; }
    }
}
