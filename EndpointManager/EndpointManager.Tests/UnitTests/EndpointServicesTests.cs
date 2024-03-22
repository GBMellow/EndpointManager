using NUnit.Framework;
using Moq;
using System.Collections.Generic;

using EndpointManager;

namespace EndpointEntity.Tests
{

    public class EndpointServiceTests
    {
        private Mock<IEndpointRepositoryInterface> _mockEndpointRepository;
        private EndpointService _endpointService;

        [SetUp]
        public void Setup()
        {
            _mockEndpointRepository = new Mock<IEndpointRepositoryInterface>();
            _endpointService = new EndpointService(_mockEndpointRepository.Object);
        }

        [Test]
        public void TestCreateEndpoint()
        {
            // Arrange
            var endpoint = new Endpoint("123456", 16, 11, "1.1", 1);

            _mockEndpointRepository.Setup(repo => repo.Create(endpoint)).Returns(endpoint);

            // Act
            var result = _endpointService.CreateEndpoint(endpoint);

            // Assert
            Assert.Equals(endpoint, result);
        }

        [Test]
        public void TestUpdateEndpoint()
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
        public void TestDeleteEndpoint()
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
        public void TestGetEndpoint()
        {
            // Arrange
            var serialNumber = "123456";
            var expectedEndpoint = new Endpoint("123456", 16, 11, "1.1", 1);

            _mockEndpointRepository.Setup(repo => repo.GetBySerialNumber(serialNumber)).Returns(expectedEndpoint);

            // Act
            var result = _endpointService.GetEndpointBySerialNumber(serialNumber);

            // Assert
            Assert.Equals(expectedEndpoint, result);
        }

        [Test]
        public void TestGetAll()
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
