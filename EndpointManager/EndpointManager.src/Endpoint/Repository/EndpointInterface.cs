using EndpointEntity;

public interface IEndpointRepositoryInterface
{
    Endpoint Create(Endpoint endpoint);
    Endpoint Update(string serialNumber, int switchState);
    bool Delete(string serialNumber);
    Endpoint GetBySerialNumber(string serialNumber);
    List<string> GetAll();
}