using Facade.Builders;
using Facade.Models;

namespace Facade
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            this.Car = new Car();
        }

        public Car Build()
            => this.Car;

        public CarInfoBuilder Info
            => new CarInfoBuilder(this.Car);

        public CarAddressBuilder Address
            => new CarAddressBuilder(this.Car);
    }
}
