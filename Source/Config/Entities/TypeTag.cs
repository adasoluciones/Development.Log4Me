using Ada.Framework.Development.Log4Me.Entities;
using Ada.Framework.Development.Log4Me.Writers;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Config.Entities
{
    /// <summary>
    /// Tag que representa el tipo del registro que de cumplir ciertas condiciones, se deben excluir.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    [XmlType(TypeName = "Type")]
    public class TypeTag
    {
        /// <summary>
        /// Permite obtener o establecer el nombre del escritor.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlIgnore]
        public Tipo Nombre
        {
            get
            {
                return Tipo.ObtenerEnumeracion(_Nombre) as Tipo;
            }
            set
            {
                _Nombre = value == null ? value.Codigo : null;
            }
        }

        /// <summary>
        /// Permite obtener o establecer el nombre del escritor.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute(AttributeName = "Name")]
        public string _Nombre { get; set; }
        
        /// <summary>
        /// Permite obtener o establecer el nivel del mensaje.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlIgnore]
        public Nivel Nivel
        {
            get
            {
                return Nivel.ObtenerEnumeracion(_Nivel) as Nivel;
            }
            set
            {
                _Nivel = value == null ? value.Codigo : null;
            }
        }

        /// <summary>
        /// Permite obtener o establecer el nivel del mensaje.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute(AttributeName = "Level")]
        public string _Nivel { get; set; }
        
        /// <summary>
        /// Permite obtener o establecer el modo del escritor.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlIgnore]
        public Modo Modo
        {
            get
            {
                return Modo.ObtenerEnumeracion(_Modo) as Modo;
            }
            set
            {
                _Modo = value == null ? value.Codigo : null;
            }
        }

        /// <summary>
        /// Permite obtener o establecer el modo del escritor.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute(AttributeName = "Mode")]
        public string _Modo { get; set; }
    }
}