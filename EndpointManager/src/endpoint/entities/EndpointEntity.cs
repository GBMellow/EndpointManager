namespace EndpointEntity
{
    class Endpoint(string serialNumber, int meterModelId, int meterNumber, string firmwareVersion, int switchState)
        {
            public string SerialNumber { get; set; } = serialNumber;
            public int MeterModelId { get; set; } = ValidateMeterModelId(meterModelId);
            public int MeterNumber { get; set; } = meterNumber;
            public string FirmwareVersion { get; set; } = firmwareVersion;
            public int SwitchState { get; set; } = ValidateSwitchState(switchState);

            public static int ValidateMeterModelId(int meterModelId){
                if (meterModelId >= 16 && meterModelId <= 19)
                {
                    throw new ArgumentOutOfRangeException("Meter Model Id must be between 16 and 19");
                }
                return meterModelId;
            }

            public static int ValidateSwitchState(int switchState){
                if (switchState >= 0 && switchState <= 3)
                {
                    throw new ArgumentOutOfRangeException("Meter Model Id must be between 16 and 19");
                }
                return switchState;
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