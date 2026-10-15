using VyshKat.Core.Memory;
using VyshKat.Core.Services;
using VyshKat.Core.Vehicles;

namespace VyshKat.Tests;

public class RentalServiceTests
{
    [Fact]
    public void RejectsDifficultVehicleForBeginner()
    {
        Park park = new();
        // велостпед не для новичка
        Bicycle bicycle = new(1, "Сложный велосипед", 5, 90);
        park.Add(bicycle);
        RentalService service = new(park);

        Assert.False(service.TryRent(1, isBeginner: true));
        Assert.False(bicycle.IsRented);
    }

    [Fact]
    public void RentsSuitableVehicleOnce()
    {
        Park park = new();
        // велостпед для новичка
        Bicycle bicycle = new(1, "Простой велосипед", 6, 90);
        park.Add(bicycle);
        RentalService service = new(park);

        Assert.True(service.TryRent(1, isBeginner: true));
        Assert.True(bicycle.IsRented);
        Assert.False(service.TryRent(1, isBeginner: true));
    }

    [Fact]
    public void RentsDifficultVehicleToExperienced()
    {
        Park park = new();
        Bicycle bicycle = new(1, "Сложный велосипед", 5, 90);
        park.Add(bicycle);
        RentalService service = new(park);

        Assert.True(service.TryRent(1, isBeginner: false));
        Assert.True(bicycle.IsRented);
    }

    [Fact]
    public void RejectsUnknownNumber()
    {
        RentalService service = new(new Park());

        Assert.False(service.TryRent(999, isBeginner: false));
    }
    // проверяем работу TryReturn
    [Fact]
    public void ReturnsRentedVehicle()
    {
        Park park = new();
        Bicycle bicycle = new(1, "Велосипед", 7, 90);
        park.Add(bicycle);
        RentalService service = new(park);

        Assert.True(service.TryRent(1, isBeginner: false));
        Assert.True(service.TryReturn(1));
        Assert.False(bicycle.IsRented);
        //Assert.True(service.TryRent(1, isBeginner: false));
    }

    [Fact]
    public void DoesNotReturnMissingOrAvailableVehicle()
    {
        Park park = new();
        park.Add(new Bicycle(1, "Велосипед", 7, 90));
        RentalService service = new(park);

        Assert.False(service.TryReturn(1));
        Assert.False(service.TryReturn(999));
    }
}
