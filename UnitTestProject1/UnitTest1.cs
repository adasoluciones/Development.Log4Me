using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ada.Framework.Development.Log4Me;
using ConsoleTest.Entities;
using ConsoleTest.DAO;
using Ada.Framework.Development.Log4Me.Entities;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Log.Identificador("1-9");

            UsuarioTO to = new UsuarioTO()
            {
                Nombre = "Juan Perez",
                Edad = 22,
                FechaNacimiento = DateTime.Now
            };

            Log4MeManager.CurrentInstance.Variable("to", to);
            Log4MeManager.CurrentInstance.Mensaje("Mensaje1", Nivel.Debug);
            Log4MeManager.CurrentInstance.Mensaje("Mensaje2", Nivel.Alert);
            Log4MeManager.CurrentInstance.Mensaje("Mensaje3", Nivel.Error);

            EjemploDAO dao = new EjemploDAO();
            dao.Agregar("Juan");
            dao.Modificar();
        }
    }
}
