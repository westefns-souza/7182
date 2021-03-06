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
            _discount = new Discount(10, DateTime.Now.AddDays(-5));
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
            _order.AddItem(_product, 1);
            _order.Pay(10);
            Assert.AreEqual(EOrderStatus.WaitingDelivery, _order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_cancelado_seu_status_deve_ser_cancelado()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_sem_produto_o_mesmo_nao_deve_ser_adicionado()
        {
            _order.AddItem(null, 1);
            Assert.AreEqual(0, _order.Items.Count);
        }
    
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_item_com_quantidade_zero_ou_menor_o_mesmo_nao_deve_ser_adicionado()
        {
            _order.AddItem(_product, 0);
            Assert.AreEqual(0, _order.Items.Count);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_seu_total_deve_ser_50()
        {
            _order.AddItem(_product, 5);
            Assert.AreEqual(50, _order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_expirado_o_valor_do_pedido_deve_ser_60()
        {
            _order.AddItem(_product, 6);
            Assert.AreEqual(60, _order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_costumer, 0, null);
            order.AddItem(_product, 6);
            Assert.AreEqual(60, order.Total());
        }
    
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_de_10_o_valor_do_pedido_deve_ser_50()
        {
            var discount = new Discount(10, DateTime.Now.AddDays(5));
            var order = new Order(_costumer, 0, discount);
            order.AddItem(_product, 6);
            Assert.AreEqual(50, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void dado_uma_taxa_de_entrega_de_10_o_valor_do_pedido_deve_ser_60()
        {
            var order = new Order(_costumer, 10, null);
            order.AddItem(_product, 5);
            Assert.AreEqual(60, order.Total());
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_pedido_sem_cliente_o_mesmo_deve_ser_invalido()
        {
            var order = new Order(null, 10, _discount);
            Assert.AreEqual(true, order.Invalid);
        }
    }
}