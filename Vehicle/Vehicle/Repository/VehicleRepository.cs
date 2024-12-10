namespace Vehicle.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> IVehicleRepository.Create(Vehicle v)
        {
        }

        Task<Vehicle> IVehicleRepository.GetAll()
        {
        }
    }
}
