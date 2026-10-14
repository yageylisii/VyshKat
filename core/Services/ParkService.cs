using VyshKat.Core.Interfaces;

namespace VyshKat.Core.Services;

public class ParkService
{
    private readonly IPark _park;
    private readonly IServiceCenter _serviceCenter;

    public bool TryAcceptThing(IInventoryItem thing)
    {
        if (!_serviceCenter.CanAccept(thing))
        {
            return false;
        }

        _park.Add(thing);
        return true;
    }
    public ParkService(
        IPark park,
        IServiceCenter serviceCenter)
    {
        _park = park;
        _serviceCenter = serviceCenter;
    }
}
