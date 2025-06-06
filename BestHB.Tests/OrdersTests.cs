using BestHB.Domain.Commands;
using BestHB.Domain.Entities;
using BestHB.Domain.Repositories;
using BestHB.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BestHB.Tests
{
    [TestClass]
    public class OrdersTest
    {
        [TestMethod]
        public void invalid_lot_size_on_create_order_test() //TODO: Mudar nome do método, sem underlines e em pascalCase -> InvalidLotSizeOnCreateOrderTest
        {
            //given
            var command = new CreateOrderCommand { //ainda nao sei pq um comando é um objeto
                Price = 10,
                Quantity = 40,
                Side = Domain.Commands.OrderSide.Sell,
                Symbol = "PETR4",
                Type = Domain.Commands.OrderType.Market,
                UserId = 123
            };

            var instrumentInfo = new InstrumentInfo
            {
                Type = InstrumentType.Stock,
                Symbol = "PETR4",
                Description = "PETROBRAS",
                Exchange = "BOVESPA",
                ISIN = "123456",
                LotStep = 100,
                MaxLot = 100000,
                MinLot = 100
            };

            
            var instrumentInfoRepositoryMock = new Mock<IRepository>();

            instrumentInfoRepositoryMock.Setup(i => i.Get(It.IsAny<string>())).ReturnsAsync(instrumentInfo);

            var orderRepositoryMock = new Mock<IRepository>();

            var message = string.Empty;

            try
            {
                var orderService = new OrderService(orderRepositoryMock.Object, instrumentInfoRepositoryMock.Object);
                
                orderService.Create(command);
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Quantidade inv�lida.", message);
        }
    }
}
