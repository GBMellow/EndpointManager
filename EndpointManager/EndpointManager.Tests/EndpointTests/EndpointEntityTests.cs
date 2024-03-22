using NUnit.Framework;

namespace EndpointEntity.Tests
{
    [TestFixture]
    public class EndpointTests
    {  
            private string _serialNumber = "123456";
            private int _meterModelId = 16;
            private int _meterNumber = 123;
            private string _firmwareVersion = "1.0";
            private int _switchState = 1;
            private Endpoint _endpoint = new Endpoint("123456", 16, 123, "1.0", 1);
        [Test]
        public void ConstructorTest()
        {
            //Assert
            Assert.Equals(_serialNumber, _endpoint.SerialNumber);
            Assert.Equals(_meterModelId, _endpoint.MeterModelId);
            Assert.Equals(_meterNumber, _endpoint.MeterNumber);
            Assert.Equals(_firmwareVersion, _endpoint.FirmwareVersion);
            Assert.Equals(_switchState, _endpoint.SwitchState);
        }

        [Test]
        public void ToStringOverrideTest()
        {
            // Arrange
            string expectedString = $"Endpoint Serial Number: {_serialNumber}\n" +
                                    $"Meter Model Id: {_meterModelId}\n" +
                                    $"Meter Number: {_meterNumber}\n" +
                                    $"Meter Firmware Version: {_firmwareVersion}\n" +
                                    $"Switch State: {_switchState}\n";

            // Act
            string result = _endpoint.ToString();

            // Assert
            Assert.Equals(expectedString, result);
        }
    }
}
