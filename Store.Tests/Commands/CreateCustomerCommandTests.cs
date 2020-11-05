using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.CustomerComands.Inputs;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {

        [TestMethod]
        public void Deve_Validar_Se_Comando_Esta_Valido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Andre";
            command.LastName = "Machado";
            command.Document = "45455717863";
            command.Email = "andre.machado@gmail.com";
            command.Phone = "1198213781287";

            Assert.AreEqual(true, command.IsValid());
        }
    }
}