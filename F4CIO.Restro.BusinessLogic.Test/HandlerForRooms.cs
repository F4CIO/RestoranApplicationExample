using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace F4CIO.Restro.BusinessLogic.Test
{
    [TestClass]
    public class HandlerForRooms
    {
        [TestInitialize()]
        public void TestInitialize()
        {
            var handlerForRoomsMock = new F4CIO.Restro.BusinessLogic.Test.HandlerForRoomsMock();

            F4CIO.Restro.Data.HandlersFactory.HandlerForRooms = handlerForRoomsMock;
        }

        [TestMethod]
        public void TestMethodAggregate_WhenMinuteByMinuteOnCorrectFixture_ShouldReturnRoomStructure()
        {
            //Act
            var result = F4CIO.Restro.BusinessLogic.HandlersFactory.HandlerForRoom.Aggregate(1, Entities.AggregationLevel.Minute_by_minute);

            //Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Bob enters the room", result.Items[0].GetLines()[0]);
            Assert.AreEqual("Kate enters the room", result.Items[1].GetLines()[0]);
            Assert.AreEqual("Bob comments: Hey, Kate - high five?", result.Items[2].GetLines()[0]);
            Assert.AreEqual("Kate high-fives Bob", result.Items[3].GetLines()[0]);
            Assert.AreEqual("Bob leaves", result.Items[4].GetLines()[0]);
            Assert.AreEqual("Kate comments: Oh, typical", result.Items[5].GetLines()[0]);
            Assert.AreEqual("Kate leaves", result.Items[6].GetLines()[0]);
        }

        [TestMethod]
        public void TestMethodAggregate_WhenMinuteByMinuteForNonexistentRoom_ShouldReturnNull()
        {
            //Act
            var result = F4CIO.Restro.BusinessLogic.HandlersFactory.HandlerForRoom.Aggregate(13, Entities.AggregationLevel.Minute_by_minute);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestMethodAggregate_WhenHurlyOnCorrectFixture_ShouldReturnAggregatedStructure()
        {
            //Act
            var result = F4CIO.Restro.BusinessLogic.HandlersFactory.HandlerForRoom.Aggregate(1, Entities.AggregationLevel.Hourly);

            //Assert
            Assert.AreEqual(2, result.Items.Count);
            Assert.AreEqual(3, result.Items[1].GetLines().Count);
            Assert.AreEqual("3 people entered", result.Items[1].GetLines()[0]);
            Assert.AreEqual("1 person high-fived 3 other people", result.Items[1].GetLines()[1]);
            Assert.AreEqual("15 comments", result.Items[1].GetLines()[2]);
        }

        [TestMethod]
        public void TestMethodAggregate_WhenHourlyForNonexistentRoom_ShouldReturnNull()
        {
            //Act
            var result = F4CIO.Restro.BusinessLogic.HandlersFactory.HandlerForRoom.Aggregate(13, Entities.AggregationLevel.Hourly);

            //Assert
            Assert.IsNull(result);
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            //cleanup fixture
        }
    }
}
