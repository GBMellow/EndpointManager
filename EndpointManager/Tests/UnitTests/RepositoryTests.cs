using NUnit.Framework;
using Moq;
using System;

namespace EndpointEntity.Tests
{
    [TestFixture]
    public class InMemoryEndpointRepositoryTests
    {
        private InMemoryEndpointRepository _endpointRepository;

        [SetUp]
        public void Setup()
        {
            _endpointRepository = new InMemoryEndpointRepository();
        }

        [Test]
        public void CreateEndpointTest()
        {
            // Arrange
            var endpoint = new Endpoint
            {
                SerialNumber = "123456",
                MeterModelId = 16,
                SwitchState = 1
            };

            // Act
            var result = _endpointRepository.Create(endpoint);

            // Assert
            Assert.AreEqual(endpoint, result);
        }

        [Test]
        public void ThrowsDuplicatedExceptionTest()
        {
            // Arrange
            var endpoint = new Endpoint
            {
                SerialNumber = "123456",
                MeterModelId = 16,
                SwitchState = 1
            };

            _endpointRepository.Create(endpoint);

            // Act & Assert
            Assert.Throws<Exception>(() => _endpointRepository.Create(endpoint));
        }

        [Test]
        public void UpdateEndpointTest()
        {
            // Arrange
            var endpoint = new Endpoint
            {
                SerialNumber = "123456",
                MeterModelId = 16,
                SwitchState = 1
            };

            _endpointRepository.Create(endpoint);

            // Act
            var updatedEndpoint = _endpointRepository.Update("123456", 2);

            // Assert
            Assert.AreEqual(2, updatedEndpoint.SwitchState);
        }

        [Test]
        public void ThrowsUpdateNonExistingEndpointExceptionTest()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _endpointRepository.Update("123456", 2));
        }

        [Test]
        public void DeleteEndpointTest()
        {
            // Arrange
            var endpoint = new Endpoint
            {
                SerialNumber = "123456",
                MeterModelId = 16,
                SwitchState = 1
            };

            _endpointRepository.Create(endpoint);

            // Act
            var result = _endpointRepository.Delete("123456");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ThrowsNonExistingEndpointExceptionTest()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _endpointRepository.Delete("123456"));
        }

        [Test]
        public void GetBySerialNumberTest()
        {
            // Arrange
            var endpoint = new Endpoint
            {
                SerialNumber = "123456",
                MeterModelId = 16,
                SwitchState = 1
            };

            _endpointRepository.Create(endpoint);

            // Act
            var result = _endpointRepository.GetBySerialNumber("123456");

            // Assert
            Assert.AreEqual(endpoint, result);
        }

        [Test]
        public void GetBySerialNumberThrowsNonExistingExceptionTest()
        {
            // Act & Assert
            Assert.Throws<Exception>(() => _endpointRepository.GetBySerialNumber("123456"));
        }

        [Test]
        public void GetAllTest()
        {
            // Arrange
            var endpoint1 = new Endpoint
            {
                SerialNumber = "123456",
                MeterModelId = 16,
                SwitchState = 1
            };

            var endpoint2 = new Endpoint
            {
                SerialNumber = "789012",
                MeterModelId = 17,
                SwitchState = 1
            };

            _endpointRepository.Create(endpoint1);
            _endpointRepository.Create(endpoint2);

            // Act
            var result = _endpointRepository.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void ValidSwitchStateDoesNotThrowExceptionTest()
        {
            // Arrange
            var endpoint = new Endpoint("123456", 16, 1, "1.0", 1);

            // Act & Assert
            Assert.DoesNotThrow(() => _endpointRepository.ValidateSwitchState(endpoint.));
        }

        [Test]
        public void InvalidSwitchStateThrowsExceptionTest()
        {
            // Arrange
            var endpoint = new Endpoint("123456", 16, 1, "1.0", 1);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => endpoint.ValidateSwitchState(4));
        }

        [Test]
        public void ValidMeterModelIdDoesNotThrowExceptionTest()
        {
            // Arrange
            var endpoint = new Endpoint("123456", 16, 1, "1.0", 1);

            // Act & Assert
            Assert.DoesNotThrow(() => endpoint.ValidateMeterModelId(16));
        }

        [Test]
        public void InvalidMeterModelIdThrowsExceptionTest()
        {
            // Arrange
            var endpoint = new Endpoint("123456", 16, 1, "1.0", 1);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => endpoint.ValidateMeterModelId(15));
        }
    }
}
