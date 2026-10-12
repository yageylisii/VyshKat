using VyshKat.Core.Vehicles;

namespace VyshKat.Core.Interfaces;

public interface IServiceCenter
{
    bool CanAccept(Vehicle vehicle);
}