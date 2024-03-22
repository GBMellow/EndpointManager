using EndpointEntity;

public class InMemoryEndpointRepository : IEndpointRepositoryInterface
{
    private List<Endpoint> _endpoints;
    private int _nextId;

    public InMemoryEndpointRepository()
    {
        _endpoints = new List<Endpoint>();
        _nextId = 1;
    }

    public Endpoint Create(Endpoint endpoint)
    {
        if (endpoint == null)
            throw new ArgumentNullException(nameof(endpoint));
        
        if (_endpoints.Exists(ep => ep.SerialNumber == endpoint.SerialNumber))
            {
                throw new Exception("Error: Endpoint with the same serial number already exists.");
            }

        ValidateMeterModelId(endpoint.MeterModelId);
        ValidateSwitchState(endpoint.SwitchState);

        endpoint.Id = _nextId++;
        _endpoints.Add(endpoint);
        return endpoint;
    }

    public Endpoint Update(string serialNumber, int switchState)
    {
        if (serialNumber == null)
            throw new ArgumentNullException(nameof(serialNumber));

        int index = _endpoints.FindIndex(e => e.SerialNumber == serialNumber);

        if (index != -1)
        {
            ValidateSwitchState(switchState);
            _endpoints[index].SwitchState = switchState;
        }
        else
        {
            throw new Exception("Error: Endpoint with this serial number not found");
        }

        return _endpoints[index];
    }

    public bool Delete(string serialNumber)
    {
        if (serialNumber == null)
            throw new ArgumentNullException(nameof(serialNumber));

        int index = _endpoints.FindIndex(e => e.SerialNumber == serialNumber);

        if (index != -1)
        {
            _endpoints.RemoveAt(index);
            if (_endpoints.Find(e => e.SerialNumber == serialNumber) != null)
            {
                throw new Exception("Error: Could not delete endpoint with this serial number!");
            }
        }
        else
        {
            throw new Exception("Error: Endpoint with this serial number not found");
        }

        return true;
    }

    public Endpoint GetBySerialNumber(string serialNumber)
    {
        var endpoint = _endpoints.Find(e => e.SerialNumber == serialNumber);

        if (endpoint == null)
        {
            throw new Exception("No endpoint with this Serial Number were found!");
        }
        
        return endpoint;
    }

    public List<String> GetAll()
    {
        List<String> allEndpoints = _endpoints.ConvertAll(e => e.ToString());

        if (allEndpoints.Count == 0)
        {
            throw new Exception("No endpoints were found!");
        }
        
        return allEndpoints;
    }

    public void ValidateSwitchState(int switchState)
    {
        if (switchState < 0 || switchState > 3)
        {
            throw new ArgumentOutOfRangeException("Switch state must be 0, 1 or 2");
        }
    } 

    public void ValidateMeterModelId(int meterModelId)
    {
        if (meterModelId < 16 || meterModelId > 19)
        {
            throw new ArgumentOutOfRangeException("Meter Model Id must be between 16 and 19");
        }
    }
}
