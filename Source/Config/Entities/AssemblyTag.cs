﻿using System;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Config.Entities
{
    /// <summary>
    /// Tag que representa un ensamblado.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class AssemblyTag
    {
        /// <summary>
        /// Permite obtener o establecer las condiciones aplicables al nombre (título) de un ensamblado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlElement]
        public AssemblyTitleTag Title { get; set; }

        /// <summary>
        /// Permite obtener o establecer la configuración de compilación de un ensamblado. Tales como RELEASE o DEBUG.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string Configuration { get; set; }

        /// <summary>
        /// Permite obtener o establecer las condiciones aplicables a la compañia que creo un ensamblado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlElement]
        public AssemblyCompanyTag Company { get; set; }

        /// <summary>
        /// Permite obtener o establecer el identificador único global (GUID) del ensamblado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string GUID { get; set; }

        /// <summary>
        /// Permite obtener o establecer la versión mínima de un ensamblado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string MinimalVersion { get; set; }

        /// <summary>
        /// Permite obtener o establecer la versión máxima de un ensamblado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string MaxiumVersion { get; set; }

        /// <summary>
        /// Permite obtener o establecer la versión mínima del archivo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string MinimalFileVersion { get; set; }

        /// <summary>
        /// Permite obtener o establecer la versión máxima del archivo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [XmlAttribute]
        public string MaxiumFileVersion { get; set; }

        /// <summary>
        /// Compara 2 versiones y retorna -1 en caso que versionB sea menor a versionA, 1 en caso que versionB sea mayor a versionA, o 0 en caso que sean iguales.
        /// Si versionB o un segmento (separados por ".") de éste sea igual a "*" lo coinciderará como iguales.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="versionA">Versión de referencia.</param>
        /// <param name="versionB">Versión a comparar.</param>
        /// <returns></returns>
        public static int CompararVersiones(string versionA, string versionB)
        {
            string retorno = string.Empty;

            if (versionB == "*") return 0;

            string[] arrayVersionA = versionA.Split('.');
            string[] arrayVersionB = versionB.Split('.');

            for (int i = 0; i < arrayVersionA.Length; i++)
            {
                if (arrayVersionB.Length > i)
                {
                    if (arrayVersionB[i].Equals("*")) return 0;

                    uint segmentoNumericoA = ObtenerSegmentoNumericoVersion(arrayVersionA[i]);
                    uint segmentoNumericoB = ObtenerSegmentoNumericoVersion(arrayVersionB[i]);

                    if (segmentoNumericoA > segmentoNumericoB)
                    {
                        return -1;
                    }

                    if (segmentoNumericoA < segmentoNumericoB)
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Obtiene el segmento de versión como un valor numérico.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="segmentoVersion">Segmento de versión.</param>
        /// <returns></returns>
        public static uint ObtenerSegmentoNumericoVersion(string segmentoVersion)
        {
            string retorno = string.Empty;

            foreach (char caracterSegmento in segmentoVersion)
            {
                if (caracterSegmento == '1' || caracterSegmento == '2' || caracterSegmento == '3' ||
                    caracterSegmento == '4' || caracterSegmento == '5' || caracterSegmento == '6' ||
                    caracterSegmento == '7' || caracterSegmento == '8' || caracterSegmento == '9' ||
                    caracterSegmento == '0')
                {
                    retorno += caracterSegmento;
                }
                else
                {
                    retorno += ((int)caracterSegmento).ToString();
                }
            }

            return Convert.ToUInt32(retorno);
        }
        
    }

    /// <summary>
    /// Representa las condiciones aplicables al nombre (título) de un ensamblado.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class AssemblyTitleTag : CondicionSimple { }
    
    /// <summary>
    /// Representa las condiciones aplicables a la compañía de un ensamblado.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 30/03/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class AssemblyCompanyTag : CondicionSimple { }
}
