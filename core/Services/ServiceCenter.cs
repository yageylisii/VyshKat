// принимать
using VyshKat.Core.Interfaces;
using VyshKat.Core.Vehicles;
namespace VyshKat.Core.Services;

public class ServiceCenter : IServiceCenter
{
    private const int LowLimitAccept = 70;

    public bool CanAccept(Vehicle vehicle)
    {
        return vehicle.Statement >= LowLimitAccept;
    }

}