using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _costumer;
        private readonly Product _product;
        private readonly Discount _discount;
        private readonly Order _order;

        public OrderTests()
        {
            _costumer = new Customer("Westefns", "westefns@outlook.com.br");
            _product = new Product("Produto 1", 10, true);
            _discount = new Discount(10, DateTime.Now.AddDays(5));
            _order = new Order(_costumer, 0, _discount);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            Assert.AreEqual(8, _order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_seu_status_deve_ser_aguardando_pagamento()
        {
            Assert.AreEqual(EOrderStatus.WaitingPayment, _order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pagamento_do_pedido_seu_status_deve_ser_aguardando_entrega()
        {
            Assert.Fail();
        }
    }
}