using Vehicle.Model;

namespace Vehicle.Repository
{
    public interface IVehicleRepository
    {
        public Task<Vehicle> GetAll();
        public Task<IEnumerable<Vehicle>> Create(Vehicle v);
    }
}
