using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.CustomerComands.Inputs;
using Store.Domain.StoreContext.Handlers;
using Store.Tests.Fakes;

namespace Store.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {

        [TestMethod]
        public void Deve_Registrar_Um_Cliente_Se_Valido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "André";
            command.LastName = "Machado";
            command.Document = "45455717863";
            command.Email = "andre.machado@gmail.com";
            command.Phone = "11972787352";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}