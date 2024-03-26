namespace DependencyInjectionServiceContracts
{
    public interface ICitiesService
    {
        Guid ServiceInstanceId { get; }
        List<string> GetCities();
    }
}