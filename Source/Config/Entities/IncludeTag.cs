using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Config.Entities
{
    /// <summary>
    /// Tag que representa entidades que de cumplir ciertas condiciones, se deben incluir.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    [XmlType(TypeName = "Include")]
    public class IncludeTag : Filtro { }
}
