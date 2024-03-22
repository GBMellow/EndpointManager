using System.Dynamic;

namespace EndpointEntity
{
    public class Endpoint
        {
            public int Id { get; set; }
            public string SerialNumber { get; set; }
            public int MeterModelId { get; set; }
            public int MeterNumber { get; set; }
            public string FirmwareVersion { get; set; }
            public int SwitchState { get; set; }
            public Endpoint(string serialNumber, int meterModelId, int meterNumber, string firmwareVersion, int switchState)
            {
                SerialNumber    = serialNumber;
                MeterModelId    = meterModelId;
                MeterNumber     = meterNumber;
                FirmwareVersion = firmwareVersion;
                SwitchState     = switchState;
            }

            public override string ToString()
            {
                return $"Endpoint Serial Number: {SerialNumber}\n" +
                    $"Meter Model Id: {MeterModelId}\n" +
                    $"Meter Number: {MeterNumber}\n" +
                    $"Meter Firmware Version: {FirmwareVersion}\n" +
                    $"Switch State: {SwitchState}\n";
            }
        }
}