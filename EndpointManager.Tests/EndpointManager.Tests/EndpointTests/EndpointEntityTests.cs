using NUnit.Framework;

namespace EndpointEntity.Tests
{
    [TestFixture]
    public class EndpointTests
    {
        [Test]
        public void ConstructorTest()
        {
            // Arrange
            string serialNumber = "123456";
            int meterModelId = 16;
            int meterNumber = 123;
            string firmwareVersion = "1.0";
            int switchState = 1;

            // Act
            var endpoint = new Endpoint(serialNumber, meterModelId, meterNumber, firmwareVersion, switchState);

            // Assert
            Assert.AreEqual(serialNumber, endpoint.SerialNumber);
            Assert.AreEqual(meterModelId, endpoint.MeterModelId);
            Assert.AreEqual(meterNumber, endpoint.MeterNumber);
            Assert.AreEqual(firmwareVersion, endpoint.FirmwareVersion);
            Assert.AreEqual(switchState, endpoint.SwitchState);
        }

        [Test]
        public void ToStringOverrideTest()
        {
            // Arrange
            string serialNumber = "123456";
            int meterModelId = 16;
            int meterNumber = 123;
            string firmwareVersion = "1.0";
            int switchState = 1;
            var endpoint = new Endpoint(serialNumber, meterModelId, meterNumber, firmwareVersion, switchState);
            string expectedString = $"Endpoint Serial Number: {serialNumber}\n" +
                                    $"Meter Model Id: {meterModelId}\n" +
                                    $"Meter Number: {meterNumber}\n" +
                                    $"Meter Firmware Version: {firmwareVersion}\n" +
                                    $"Switch State: {switchState}\n";

            // Act
            string result = endpoint.ToString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }
    }
}
