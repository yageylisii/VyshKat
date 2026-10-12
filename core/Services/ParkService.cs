using VyshKat.Core.Vehicles;
using VyshKat.Core.Interfaces;
using VyshKat.Core.Equipment;

namespace VyshKat.Core.Services;

public class ParkService
{
    private readonly IPark _park;
    private readonly IServiceCenter _serviceCenter;
    public bool TryAcceptVehicle(Vehicle vehicle) // добавить транспорт
    {
        if (!_serviceCenter.CanAccept(vehicle))
        {
            return false;
        }

        _park.Add(vehicle);
        return true;
    }

    public void AddEquipment( // добавить оборудование 
        EquipmentItem equipment)
    {
        _park.Add(equipment);
    }
    public ParkService(
        IPark park,
        IServiceCenter serviceCenter)
    {
        _park = park;
        _serviceCenter = serviceCenter;
    }
}