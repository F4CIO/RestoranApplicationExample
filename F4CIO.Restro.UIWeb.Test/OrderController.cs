using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using F4CIO.Restro.Entities;

namespace F4CIO.Restro.UIWeb.Test
{
    [TestClass]
    public class OrderController
    {
        private F4CIO.Restro.UIWeb.Controllers.OrderController _orderController;

        [TestInitialize()]
        public void TestInitialize()
        {
            //construct controller and fake business logic layer underneeth it
            var dlMemoryStorage = new F4CIO.Restro.Data.MemoryStorage();
            var dlHandlerForOrders = new F4CIO.Restro.Data.HandlerForOrders(dlMemoryStorage);
            var blHandlerForOrders = new F4CIO.Restro.BusinessLogic.HandlerForOrders(dlHandlerForOrders);
            this._orderController = new F4CIO.Restro.UIWeb.Controllers.OrderController(blHandlerForOrders);
        }

        [TestMethod]
        public void TestMethodAddOrder_OnEmptyFixture()
        {
            //Act
            var order = new Order() { Date = DateTime.Now.ToShortDateString(), Status = "Processing", Summary = "Fake order 1" };
            this._orderController.AddOrder(order);

            //Assert
            //method returns void so just making sure no exceptions
        }

       [TestMethod]
        public void TestMethodGetOrders_OnEmptyFixture_ShouldReturnEmptyList()
        {
            //Act
            var result = this._orderController.GetOrders();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);          
        }

        [TestMethod]
        public void TestMethodGetOrders_OnFixtureWithSingleItem_ShouldReturnSingleItem()
        {
            //Act
            var order = new Order() { Date = DateTime.Now.ToShortDateString(), Status = "Processing", Summary = "Fake order 1" };
            this._orderController.AddOrder(order);
            var result = this._orderController.GetOrders();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(result[0].Date, order.Date);
            Assert.AreEqual(result[0].Status, order.Status);
            Assert.AreEqual(result[0].Summary, order.Summary);
        }

        [TestMethod]
        public void TestMethodGetOrders_OnFixtureWithTwoItems_ShouldReturnTwoItems()
        {
            //Act
            var order = new Order() { Date = DateTime.Now.ToShortDateString(), Status = "Processing", Summary = "Fake order 1" };
            this._orderController.AddOrder(order);
            var order2 = new Order() { Date = DateTime.Now.ToShortDateString(), Status = "Processing", Summary = "Fake order 2" };
            this._orderController.AddOrder(order2);
            var result = this._orderController.GetOrders();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(result[0].Date, order.Date);
            Assert.AreEqual(result[0].Status, order.Status);
            Assert.AreEqual(result[0].Summary, order.Summary);
            Assert.AreEqual(result[1].Date, order2.Date);
            Assert.AreEqual(result[1].Status, order2.Status);
            Assert.AreEqual(result[1].Summary, order2.Summary);
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            //cleanup fixture
            this._orderController = null;
        }
    }
}
