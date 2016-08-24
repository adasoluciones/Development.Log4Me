using Ada.Framework.Development.Log4Me.Entities;
using System;
using System.Reflection;

namespace Ada.Framework.Development.Log4Me
{
    /// <summary>
    /// Contrato del Log.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public interface ILog
    {
        /// <summary>
        /// Obtiene el valor único (GUID) que identifíca el hilo de ejecución actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        string ThreadGUID { get; }

        /// <summary>
        ///  Obtiene el valor único (GUID) que identifíca la ejecución (método) actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        string MethodGUID { get; }

        /// <summary>
        /// Permite obtener el método actual mediante reflexión.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        MethodBase Metodo { get; }

        /// <summary>
        /// Registra el inicio de un método, guarda la hora actual y cada parametro especificando
        /// nombre, tipo y valor. Se recomienda que esta sea la primera instrucción de cada método.
        /// Si se logea el inicio, es obligatorio logear el retorno aunque el método sea Void.
        /// </summary>
        /// <example>
        ///     public void Metodo1(int a, string b, bool c)
        ///     {
        ///         log.Inicio(a, b, c);
        ///         log.Retorno();
        ///     }
        ///     
        ///     public void Metodo2()
        ///     {
        ///         log.Inicio();
        ///         log.Retorno();
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="parametros">Lista de parametros del método actual.</param>
        void Inicio(params object[] parametros);

        /// <summary>
        /// Registra el fin de la ejecución de un método, guardando la fecha de termino, el valor de retorno y su tipo.
        /// Se debe logear antes de retornar. Requiere que se haya logeado el inicio del método.
        /// </summary>
        /// <example>
        ///     public int Sumar(int valor1, int valor2)
        ///     {
        ///         log.Inicio(valor1, valor2);
        ///         int resultado = valor1 + valor2;
        ///         log.Retorno(resultado);
        ///         return resultado;
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="valor">Valor de retorno del método.</param>
        void Retorno(object valor);

        /// <summary>
        /// Registra el fin de la ejecución de un método, guardando la fecha de termino, y un retorno de tipo Void.
        /// Se debe logear antes de retornar. Requiere que se haya logeado el inicio del método.
        /// </summary>
        /// <example>
        ///     public void Metodo1()
        ///     {
        ///         log.Retorno();
        ///         // return; --> No es necesario. Sirve para ejemplificar que es el final del método.
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        void Retorno();

        /// <summary>
        /// Registra la información relevante de una excepción lanzada por un método. Se debe logear antes de ser lanzada.
        /// Requiere que el inicio y el retorno del método esté logeado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="excepcion">Excepción lanzada.</param>
        /// <param name="permiteContinuar">Valor que indica si la excepción interrumpe el flujo (no permite continuar).
        /// En caso de ser falso, se logea automáticamente el retorno del método como Excepción.</param>
        void Excepcion(Exception excepcion, bool permiteContinuar);

        /// <summary>
        /// Registra el nombre, tipo y valor de una variable en el método actual.
        /// Requiere que el inicio y el retorno del método esté logeado.
        /// </summary>
        /// <example>
        ///     public int Sumar(int valor1, int valor2, int valor3)
        ///     {
        ///         log.Inicio(valor1, valor2);
        ///         int resultado = valor1 + valor2;
        ///         
        ///         log.Variable("resultado", resultado);
        ///         retultado += valor3;
        ///         
        ///         log.Retorno(resultado);
        ///         return resultado;
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="nombre">Nombre de la variable.</param>
        /// <param name="valor">Valor de la variable.</param>
        void Variable(string nombre, object valor);

        /// <summary>
        /// Registra un mensaje con un nivel de importancia en el flujo del método actual.
        /// Requiere que el inicio y el retorno del método esté logeado.
        /// </summary>
        /// <example>
        ///     public class UsuarioBO
        ///     {
        ///         private UsuarioDAO dao = new UsuarioDAO();
        ///         
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             log.Mensaje("Antes de llamar al DAO", Nivel.INFO);
        ///             dao.Agregar(usuario);
        ///             log.Mensaje("Luego de llamar al DAO", Nivel.INFO);
        ///         }
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="mensaje">Mensaje a registrar.</param>
        /// <param name="nivel">Nivel de importancia o tipo del mensaje.</param>
        void Mensaje(string mensaje, Nivel nivel);

        /// <summary>
        /// Carga el puntero del log (MethodGUID) en una excepción.
        /// Es útil para guardar el puntero exactamente donde ocurrió la excepción.
        /// </summary>
        /// <example>
        ///     public class UsuarioDAO
        ///     {
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             try
        ///             {
        ///                 //Llamada a base de datos.
        ///             }
        ///             catch(Exception e)
        ///             {
        ///                 throw log.CargarPuntero(e);
        ///             }
        ///         }
        ///     }
        ///     
        ///     public class UsuarioBO
        ///     {
        ///         private UsuarioDAO dao = new UsuarioDAO();
        ///         
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             try
        ///             {
        ///                 dao.Agregar(usuario);
        ///             }catch(Exception e)
        ///             {
        ///                 string MethodGUID = log.ObtenerPuntero(e);
        ///             }
        ///         }
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <typeparam name="E">Tipo de la excepción que se lanzó.</typeparam>
        /// <param name="excepcion">Excepción que se lanzó.</param>
        /// <returns>Excepción cargada.</returns>
        E CargarPuntero<E>(E excepcion) where E : Exception;

        /// <summary>
        /// Obtiene el puntero (MethodGUID) de una excepción con el puntero cargado mediante el método <see cref="Ada.Framework.Development.Log4Me.ILog.CargarPuntero"/>.
        /// </summary>
        /// <example>
        ///     public class UsuarioBO
        ///     {
        ///         private UsuarioDAO dao = new UsuarioDAO();
        ///         
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             try
        ///             {
        ///                 dao.Agregar(usuario);
        ///             }catch(Exception e)
        ///             {
        ///                 string MethodGUID = log.ObtenerPuntero(e);
        ///             }
        ///         }
        ///     }
        ///     
        ///     public class UsuarioDAO
        ///     {
        ///         public void Agregar(UsuarioTO usuario)
        ///         {
        ///             try
        ///             {
        ///                 //Llamada a base de datos.
        ///             }
        ///             catch(Exception e)
        ///             {
        ///                 log.CargarPuntero(e);
        ///                 throw e;
        ///             }
        ///         }
        ///     }
        /// </example>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="excepcion">Excepción que contiene el puntero.</param>
        /// <returns>MethodGUID.</returns>
        string ObtenerPuntero(Exception excepcion);
    }
}
