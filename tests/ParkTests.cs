using VyshKat.Core.Equipment;
using VyshKat.Core.Memory;
using VyshKat.Core.Vehicles;

namespace VyshKat.Tests;

public class ParkTests
{
    [Fact]
    public void RejectsDuplicateNumber()
    {
        Park park = new();
        park.Add(new Bicycle(1, "Велосипед", 7, 80));

        Assert.Throws<ArgumentException>(() => park.Add(new Helmet(1, "Шлем")));
        Assert.Single(park.GetAll());
    }

    [Fact]
    public void FindVehicleSkipsEquipment()
    {
        Park park = new();
        park.Add(new Helmet(1, "Шлем"));

        Assert.NotNull(park.Find(1));
        Assert.Null(park.FindVehicle(1));
    }

    [Fact]
    public void RemovesItem()
    {
        Park park = new();
        park.Add(new Helmet(1, "Шлем"));

        Assert.True(park.Remove(1));
        Assert.Null(park.Find(1));
        Assert.False(park.Remove(1));
    }
}
