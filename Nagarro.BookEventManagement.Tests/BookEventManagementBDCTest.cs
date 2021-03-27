using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nagarro.BookEventManagement.Business;
using Nagarro.BookEventManagement.Shared;

namespace Nagarro.BookEventManagement.Tests
{
    [TestClass]
    public class BookEventManagementBDCTest
    {

        private readonly IEventBDC eventBDC;
        private readonly Mock<IDACFactory> mockDacFactory;
        private readonly Mock<IEventDAC> mockEventDac;

        public EventDTO eventDTO = new EventDTO
        {
            Title = "Book-A-Fiesta",
            AddressId = 30,
            Date = DateTime.Today,
            StartTime = new TimeSpan(3,5,6),
            Duration = 4,
            Description = "Mahima",
            OtherDetails = "Nothing",
            Invitations = "mahima.munjal@nagarro.com"

        };

        public BookEventManagementBDCTest()
        {
            mockDacFactory = new Mock<IDACFactory>();
            mockEventDac = new Mock<IEventDAC>();
            mockDacFactory.Setup(x => x.Create(It.IsAny<DACType>())).Returns(mockEventDac.Object);
            eventBDC = new EventBDC(mockDacFactory.Object);
        }

        [TestMethod]
        public void TestMethodSuccess()
        {
            mockEventDac.Setup(x => x.CreateEvent(It.IsAny<EventDTO>())).Returns(eventDTO);
            var response = eventBDC.CreateEvent(eventDTO);
            Assert.AreEqual(OperationResultType.Success, response.ResultType);
        }

        [TestMethod]
        public void TestMethodFailure()
        {
            mockEventDac.Setup(x => x.CreateEvent(It.IsAny<EventDTO>())).Returns(eventDTO);
            var response = eventBDC.CreateEvent(new EventDTO());
            Assert.AreEqual(OperationResultType.Failure, response.ResultType);
        }

       

    }
}
