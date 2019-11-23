using Facade.Models;

namespace Facade.Builders
{
    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            Car = car;
        }

        public CarAddressBuilder WithCity(string name)
        {
            Car.City = name;
            return this;
        }

        public CarAddressBuilder WithAddress(string address)
        {
            Car.Address = address;
            return this;
        }
    }
}
