using VyshKat.Core.Interfaces;
using VyshKat.Core.Vehicles;

namespace VyshKat.Core.Services;

public class RentalService
{
    private readonly IPark _park;


    public RentalService (IPark park)
    {
        _park = park;
    }

    public bool TryRent(int number, bool isBeginner)
    {   

        Vehicle? vehicle =
            _park.FindVehicle(number);

        if (vehicle == null)
        {
            return false;
        }

        if (vehicle.IsRented)
        {
            return false;
        }

        if (isBeginner && !vehicle.CanBeRentedByBeginner())
        {
            return false;
        }

        vehicle.Rent();
        return true;
    }

}
