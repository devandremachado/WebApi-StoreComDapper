using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class DocumentTests
    {
        private Document validCoument;
        private Document invalidCoument;
        
        public DocumentTests()
        {
            validCoument = new Document("81532486421");
            invalidCoument = new Document("12345678910");
        }

        [TestMethod]
        public void Deve_Retornar_Uma_Notificacao_Quando_Documento_Invalido()
        {
            Assert.AreEqual(false, invalidCoument.Valid);
        }

        [TestMethod]
        public void Deve_Retornar_Uma_Notificacao_Quando_Documento_Valido()
        {
            Assert.AreEqual(true, validCoument.Valid);
        }
    }
}