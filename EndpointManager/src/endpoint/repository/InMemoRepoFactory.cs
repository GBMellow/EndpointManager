public class InMemoryRepositoryFactory
{
    public IEndpointRepositoryInterface CreateEndpointRepository()
    {
        return new InMemoryEndpointRepository();
    }

    public EndpointService CreateEndpointService()
    {
        return new EndpointService(CreateEndpointRepository());
    }
}