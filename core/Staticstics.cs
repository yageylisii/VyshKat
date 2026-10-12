
using VyshKat.Core.Interfaces;
using VyshKat.Core.Vehicles;

namespace VyshKat.Core.Services;

public class StatisticsService
{
    private readonly IPark _park;

    public StatisticsService(IPark park)
    {
        _park = park;
    }
    // количество вещей траснспорт + инвентарь в парке
    public int GetTotalCount()
    {
        return _park.GetAll().Count();
    }

    // получить суммарное потребление энергии
    public double GetTotalDailyEnergyConsumption()
    {
        return _park
            .GetAll()
            .OfType<IEnergyConsumer>()
            .Sum(item =>
                item.DailyEnergyConsumption);
    }

    // получить суммарное потребление энергии
    public IEnumerable<Vehicle>
        GetVehiclesForBeginners()
    {
        return _park
            .GetAll() // получить все объекты
            .OfType<Vehicle>() // по типу
            .Where(vehicle =>
                vehicle.CanBeRentedByBeginner() &&
                !vehicle.IsRented
            ); // для новичков и нге арендованные
    }
    // получить весь инвентарь
    public IEnumerable<IInventoryItem> GetAllItems()
    {
        return _park.GetAll();
    }
}