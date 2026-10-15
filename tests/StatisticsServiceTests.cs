using VyshKat.Core.Equipment;
using VyshKat.Core.Memory;
using VyshKat.Core.Services;
using VyshKat.Core.Vehicles;

namespace VyshKat.Tests;

public class StatisticsServiceTests
{
    [Fact]
    public void CountsItemsAndEnergy()
    {
        Park park = new();
        park.Add(new Bicycle(1, "Велосипед", 7, 90));
        park.Add(new Scooter(2, "Самокат", 7, 90, 2.5));
        park.Add(new Helmet(3, "Шлем", 90));
        park.Add(new ChargingCabinet(4, "Шкаф", 1.5, 90));
        StatisticsService service = new(park);

        Assert.Equal(4, service.GetTotalCount());
        Assert.Equal(4.0, service.GetTotalDailyEnergyConsumption());
        Assert.Equal(4, service.GetAllItems().Count());
    }

    [Fact]
    public void ListsAvailableBeginnerVehicles()
    {
        Park park = new();
        Bicycle suitable = new(1, "Свободный", 6, 90);
        Bicycle difficult = new(2, "Сложный", 5, 90);
        Bicycle rented = new(3, "Занятый", 8, 90);
        rented.Rent();
        park.Add(suitable);
        park.Add(difficult);
        park.Add(rented);
        park.Add(new Helmet(4, "Шлем", 90));
        StatisticsService service = new(park);

        Assert.Equal([suitable], service.GetVehiclesForBeginners());
    }
}
