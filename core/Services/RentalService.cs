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

    public bool TryRent (int number, int levelusing)
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

        if (!vehicle.CanBeRentedByBeginner())
        {
            return false;
        }
 
        return false;
    }

}