using Ada.Framework.Development.Log4Me.Entities;
using PostSharp.Aspects;
using System;
using System.Reflection;

namespace Ada.Framework.Development.Log4Me
{
    /// <summary>
    /// Anotacion utilizada para interceptar la ejecución de un método, registrando los datos de entrada, salida y excepción del método.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 20/11/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    [Serializable]
    public sealed class Log : OnMethodBoundaryAspect, ILog
    {
        /// <summary>
        /// Campo que contiene el utilitario de log.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 27/06/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        [NonSerialized]
        private Logger<Log> logger;
        
        /// <summary>
        /// Contiene el identificador único global (GUID) del método actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        private string methodGUID;
        
        /// <summary>
        /// Permite obtener el método actual mediante reflexión.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public MethodBase Metodo { get; private set; }
        
        /// <summary>
        /// Permite obtener el identificador único global (GUID) del método actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string MethodGUID
        {
            get
            {
                if (methodGUID == null)
                {
                    methodGUID = Guid.NewGuid().ToString();
                }
                return methodGUID;
            }
        }

        /// <summary>
        /// Obtiene el identificador único (GUID) del hilo actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public string ThreadGUID
        {
            get
            {
                return Log4MeManager.ThreadGUID;
            }
        }

        #region Build-Time Logic

            /// <summary>
            /// Comrpueba si el método interceptado cumple las condiciones.
            /// </summary>
            /// <remarks>
            ///     Registro de versiones:
            ///     
            ///         1.0 20/11/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
            /// </remarks>
            /// <param name="method">Metodo interceptado accedido mediante reflexión.</param>
            /// <returns><value>true</value> en caso de ser válido, o <value>false</value> de lo contrario.</returns>
            public override bool CompileTimeValidate(MethodBase method)
            {
                return true;
            }

        #endregion

        /// <summary>
        /// Es ejecutado al llamar a un método interceptado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 20/11/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="args">Argumento con información de la llamada.</param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            logger = new Logger<Log>(this);
            Metodo = args.Method;
            Inicio(args.Arguments.ToArray());
        }

        /// <summary>
        /// Es ejecutado al salir del método interceptado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 20/11/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="args">Argumento con información de la llamada.</param>
        public override void OnExit(MethodExecutionArgs args)
        {
            Retorno(args.ReturnValue);
        }

        /// <summary>
        /// Es ejecutado al lanzar una excepción desde el método interceptado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 20/11/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="args">Argumento con información de la llamada.</param>
        public override void OnException(MethodExecutionArgs args)
        {
            Excepcion(args.Exception, false);
        }

        /// <summary>
        /// Logea el identifiador de ejecución del hilo actual. Es recomendable utilizar el RUN del usuario u otro valor que identifique la sesión actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 10/04/2016 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="identificador">Identificador del hilo.</param>
        public static void Identificador(string identificador)
        {
            Logger<Log>.Identificador(identificador);
        }

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
        public void Variable(string nombre, object valor)
        {
            logger.Variable(nombre, valor);
        }

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
        public void Mensaje(string mensaje, Nivel nivel)
        {
            logger.Mensaje(mensaje, nivel);
        }

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
        public void Inicio(params object[] parametros)
        {
            logger.Inicio(parametros);
        }

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
        public void Retorno(object valor)
        {
            logger.Retorno(valor);
        }

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
        public void Retorno()
        {
            logger.Retorno();
        }

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
        public void Excepcion(Exception excepcion, bool permiteContinuar)
        {
            logger.Excepcion(excepcion, permiteContinuar);
        }

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
        public E CargarPuntero<E>(E excepcion) where E : Exception
        {
            return logger.CargarPuntero(excepcion);
        }

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
        public string ObtenerPuntero(Exception excepcion)
        {
            return logger.ObtenerPuntero(excepcion);
        }
    }
}
