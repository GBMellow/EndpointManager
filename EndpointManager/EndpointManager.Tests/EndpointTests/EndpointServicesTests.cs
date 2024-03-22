using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace EndpointEntity.Tests
{
    [TestFixture]
    public class EndpointServiceTests
    {
        private Mock<IEndpointRepositoryInterface> _mockEndpointRepository;
        private EndpointService _endpointService;
        private Endpoint _endpoint = new Endpoint("123456", 16, 11, "1.1", 1);
        [SetUp]
        public void Setup()
        {
            _mockEndpointRepository = new Mock<IEndpointRepositoryInterface>();
            _endpointService = new EndpointService(_mockEndpointRepository.Object);
        }

        [Test]
        public void CreateEndpointTest()
        {
            // Arrange
            _mockEndpointRepository.Setup(repo => repo.Create(_endpoint)).Returns(_endpoint);

            // Act
            var result = _endpointService.CreateEndpoint(_endpoint);

            // Assert
            Assert.Equals(_endpoint, result);
        }

        [Test]
        public void UpdateEndpointTest()
        {
            // Arrange
            var serialNumber = "123456";
            var switchState = 1;
            var updatedEndpoint = new Endpoint("123456", 16, 11, "1.1", 2);

            _mockEndpointRepository.Setup(repo => repo.Update(serialNumber, switchState)).Returns(updatedEndpoint);

            // Act
            var result = _endpointService.UpdateEndpoint(serialNumber, switchState);

            // Assert
            Assert.Equals(updatedEndpoint, result);
        }

        [Test]
        public void DeleteEndpointTest()
        {
            // Arrange
            var serialNumber = "123456";

            _mockEndpointRepository.Setup(repo => repo.Delete(serialNumber)).Returns(true);

            // Act
            var result = _endpointService.Delete(serialNumber);

            // Assert
            Assert.Equals(result, true);
        }

        [Test]
        public void GetEndpointTest()
        {
            // Arrange
            var serialNumber = "123456";

            _mockEndpointRepository.Setup(repo => repo.GetBySerialNumber(serialNumber)).Returns(_endpoint);

            // Act
            var result = _endpointService.GetEndpointBySerialNumber(serialNumber);

            // Assert
            Assert.Equals(_endpoint, result);
        }

        [Test]
        public void GetAllTest()
        {
            // Arrange
            var expectedEndpoints = new List<string> { "123456", "789012", "345678" };

            _mockEndpointRepository.Setup(repo => repo.GetAll()).Returns(expectedEndpoints);

            // Act
            var result = _endpointService.GetAll();

            // Assert
            Assert.Equals(expectedEndpoints, result);
        }
    }
}
