using Modulo_Tareas.Controllers;
using Modulo_Tareas.Models;

namespace Tesr
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void Login()
        {             
            HomeController controller = new HomeController();
            bool resultado = controller.Verificar_Usuario();
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void Reg_Tarea()
        {
            Send controller = new Send();
            bool resultado = controller.Guardar();
            Assert.AreEqual(true, resultado);
        }
    }
}