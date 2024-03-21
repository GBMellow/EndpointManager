using EndpointEntity;

public class EndpointService
{
    private readonly IEndpointRepositoryInterface _endpointRepository;

    public EndpointService(IEndpointRepositoryInterface endpointRepository)
    {
        _endpointRepository = endpointRepository;
    }

    public Endpoint CreateEndpoint(Endpoint endpoint)
    {
        return _endpointRepository.Create(endpoint);
    }

    public Endpoint UpdateEndpoint(string serialNumber, int switchState)
    {
        return _endpointRepository.Update(serialNumber, switchState);
    }

    public bool Delete(string serialNumber)
    {
        return _endpointRepository.Delete(serialNumber);
    }

    public Endpoint GetEndpointBySerialNumber(string serialNumber)
    {
        return _endpointRepository.GetBySerialNumber(serialNumber);
    }

    public List<string> GetAll()
    {
        return _endpointRepository.GetAll();
    }
}