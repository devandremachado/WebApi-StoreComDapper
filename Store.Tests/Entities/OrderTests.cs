using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entites;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class OrderTests
    {

        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;

        public OrderTests()
        {
            var name = new Name("André", "Machado");
            var document = new Document("45455717863");
            var email = new Email("andre.machado@gmail.com");

            _customer = new Customer(name, document, email, "119828384");
            _order = new Order(_customer);

            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado Gamer", "Teclado Gamer", "teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "monitor.jpg", 100M, 10);
        } 

        [TestMethod]
        public void Deve_Conseguir_Criar_Um_Pedido_Valido()
        {
            
            Assert.AreEqual(true, _order.Valid);
        }

        [TestMethod]
        public void Deve_Retornar_Status_Created_Ao_Criar_Um_Pedido()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void Deve_Retornar_Dois_Quando_Adicionado_Dois_Itens_No_Pedido()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_keyboard, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        [TestMethod]
        public void Deve_Subtrair_A_Quantidade_Do_Estoque_Ao_Comprar_Um_Produto()
        {
           _order.AddItem(_mouse, 5);
           Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

         [TestMethod]
        public void Deve_Retornar_Um_Numero_Ao_Gerar_Um_Pedido()
        {
           _order.Place();
           Assert.AreNotEqual("", _order.Number);
        }

        [TestMethod]
        public void Deve_Retornar_Status_Paid_Quando_O_Pedido_For_Pago()
        {
            _order.Pay();
           Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void Deve_Retornar_Duas_Entregas_Quando_Comprar_Dez_Produtos()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        [TestMethod]
        public void Deve_Retornar_Status_Should_Quando_O_Pedido_For_Cancelado()
        {
           _order.Cancel();
           Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void Deve_Cancelar_As_Entregas_Ao_Cancelar_Um_Pedido()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            _order.Cancel();

            foreach(var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
}