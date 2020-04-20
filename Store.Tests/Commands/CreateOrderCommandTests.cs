using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Commands;

namespace Store.Tests.Commands
{
    [TestClass]
    public class CreateOrderCommandTests
    {
        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
        {
            var command =  new CreateOrderCommand
            {
                Customer = "",
                ZipCode = "593380000",
                PromoCode = "12345678",
            };

            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
            command.Validate();

            Assert.AreEqual(command.Invalid, true);
        }
    }
}