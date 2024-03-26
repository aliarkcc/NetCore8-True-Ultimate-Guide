using DependencyInjectionServiceContracts;

namespace DependencyInjectionServices
{
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities;
        private Guid _serviceInstanceId;

        public CitiesService()
        {
            _serviceInstanceId = Guid.NewGuid();
            _cities = new List<string>()
            {
                "London",
                "Paris",
                "Tokyo",
                "New York",
                "Rome",
                "İstanbul",
            };

            //TO DO: Add logic to open the db connection
        }

        public Guid ServiceInstanceId
        {
            get
            {
                return _serviceInstanceId;
            }
        }

        public void Dispose()
        {
            //TO DO: add logic to close db connection
        }

        public List<string> GetCities()
        {
            return _cities;
        }
    }
}