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
            var endpoint = new Endpoint("123456", 16, 11, "1.1", 1);

            // Act
            var result = _endpointRepository.Create(endpoint);

            // Assert
            Assert.Equals(endpoint, result);
        }

        [Test]
        public void ThrowsDuplicatedExceptionTest()
        {
            // Arrange
            var endpoint = new Endpoint("123456", 16, 11, "1.1", 1);

            _endpointRepository.Create(endpoint);

            // Act & Assert
            Assert.Throws<Exception>(() => _endpointRepository.Create(endpoint));
        }

        [Test]
        public void UpdateEndpointTest()
        {
            // Arrange
            var endpoint = new Endpoint("123456", 16, 11, "1.1", 1);

            _endpointRepository.Create(endpoint);

            // Act
            var updatedEndpoint = _endpointRepository.Update("123456", 2);

            // Assert
            Assert.Equals(2, updatedEndpoint.SwitchState);
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
            var endpoint = new Endpoint("123456", 16, 11, "1.1", 1);

            _endpointRepository.Create(endpoint);

            // Act
            var result = _endpointRepository.Delete("123456");

            // Assert
            Assert.Equals(result, true);
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
            var endpoint = new Endpoint("123456", 16, 11, "1.1", 1);

            _endpointRepository.Create(endpoint);

            // Act
            var result = _endpointRepository.GetBySerialNumber("123456");

            // Assert
            Assert.Equals(endpoint, result);
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
            var endpoint1 = new Endpoint("123457", 16, 11, "1.1", 1);

            var endpoint2 = new Endpoint("123456", 16, 11, "1.1", 1);

            _endpointRepository.Create(endpoint1);
            _endpointRepository.Create(endpoint2);

            // Act
            var result = _endpointRepository.GetAll();

            // Assert
            Assert.Equals(2, result.Count);
        }

        [Test]
        public void ValidSwitchStateDoesNotThrowExceptionTest()
        {
            // Arrange
            int switchState = 1;

            // Act & Assert
            Assert.DoesNotThrow(() => _endpointRepository.ValidateSwitchState(switchState));
        }

        [Test]
        public void InvalidSwitchStateThrowsExceptionTest()
        {
            // Arrange
            int switchState = 4;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _endpointRepository.ValidateSwitchState(switchState));
        }

        [Test]
        public void ValidMeterModelIdDoesNotThrowExceptionTest()
        {
            // Arrange
            int meterModelId = 16;

            // Act & Assert
            Assert.DoesNotThrow(() => _endpointRepository.ValidateMeterModelId(meterModelId));
        }

        [Test]
        public void InvalidMeterModelIdThrowsExceptionTest()
        {
            // Arrange
            int meterModelId = 16;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _endpointRepository.ValidateMeterModelId(meterModelId));
        }
    }
}
