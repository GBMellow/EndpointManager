using NUnit.Framework;
using Moq;
using System;

namespace EndpointEntity.Tests
{
    [TestFixture]
    public class InMemoryEndpointRepositoryTests
    {
        private InMemoryEndpointRepository _endpointRepository;
        private Endpoint _endpoint = new Endpoint("123456", 16, 11, "1.1", 1);
        private Endpoint _endpoint1 = new Endpoint("123461", 16, 11, "1.1", 1);

        [SetUp]
        public void Setup()
        {
            _endpointRepository = new InMemoryEndpointRepository();
        }

        [Test]
        public void CreateEndpointTest()
        {
            // Act & Arrange
            var result = _endpointRepository.Create(_endpoint);

            // Assert
            Assert.Equals(_endpoint, result);
        }

        [Test]
        public void ThrowsDuplicatedExceptionTest()
        {
            // Arrange
            _endpointRepository.Create(_endpoint);

            // Act & Assert
            Assert.Throws<Exception>(() => _endpointRepository.Create(_endpoint));
        }

        [Test]
        public void UpdateEndpointTest()
        {
            // Arrange
            _endpointRepository.Create(_endpoint);

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
            _endpointRepository.Create(_endpoint);

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
            _endpointRepository.Create(_endpoint);

            // Act
            var result = _endpointRepository.GetBySerialNumber("123456");

            // Assert
            Assert.Equals(_endpoint, result);
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
            _endpointRepository.Create(_endpoint);
            _endpointRepository.Create(_endpoint);

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
