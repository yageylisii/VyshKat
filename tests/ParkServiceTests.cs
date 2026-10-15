using Microsoft.Extensions.DependencyInjection;
using VyshKat.Core.Interfaces;
using VyshKat.Core.Equipment;
using VyshKat.Core.Memory;
using VyshKat.Core.Services;
using VyshKat.Core.Vehicles;

namespace VyshKat.Tests;

public class ParkServiceTests
{   
    // принимаем велосипед 
    [Fact]
    public void AddsAcceptedVehicle()
    {
        var inspection = new FakeServiceCenter(accept: true);
        
        // создаем DI контейнер
        ServiceCollection services = new();
        services.AddSingleton<IPark, Park>();
        services.AddSingleton<IServiceCenter>(inspection);
        services.AddTransient<ParkService>();
        using ServiceProvider provider = services.BuildServiceProvider();
        
        // контейнер подставляет IPark и IServiceCenter в конструктор
        ParkService parkService = provider.GetRequiredService<ParkService>();
        IPark park = provider.GetRequiredService<IPark>();

        Bicycle bicycle = new(1, "Велосипед", 7, 80);

        bool accepted = parkService.TryAcceptThing(bicycle);

        Assert.True(accepted);
        Assert.Same(bicycle, inspection.LastInspectedItem);
        Assert.Same(bicycle, park.FindVehicle(1));
    }
    // не принимаем велосипед
    [Fact]
    public void SkipsRejectedVehicle()
    {
        var inspection = new FakeServiceCenter(accept: false);
        ServiceCollection services = new();
        services.AddSingleton<IPark, Park>();
        services.AddSingleton<IServiceCenter>(inspection);
        services.AddTransient<ParkService>();
        using ServiceProvider provider = services.BuildServiceProvider();
        
        ParkService parkService = provider.GetRequiredService<ParkService>();
        IPark park = provider.GetRequiredService<IPark>();
        
        Bicycle bicycle = new(2, "Велосипед", 7, 80);
        bool accepted = parkService.TryAcceptThing(bicycle);

        Assert.False(accepted);
        Assert.Same(bicycle, inspection.LastInspectedItem);
        Assert.Null(park.Find(2));
    }

    [Theory]
    // запускаем один и тот же тест с разными данными
    [InlineData(69, false)]
    [InlineData(70, true)]
    public void RequiresConditionAtLeast70(int condition, bool expected)
    {
        IPark park = new Park();
        ParkService service = new(park, new ServiceCenter());
        Bicycle bicycle = new(3, "Велосипед", 7, condition);

        Assert.Equal(expected, service.TryAcceptThing(bicycle));
        Assert.Equal(expected, park.FindVehicle(3) is not null);
    }

    [Theory]
    [InlineData(69, false)]
    [InlineData(70, true)]
    public void ChecksEquipmentCondition(int condition, bool expected)
    {
        IPark park = new Park();
        ParkService service = new(park, new ServiceCenter());
        Helmet helmet = new(4, "Шлем", condition);

        Assert.Equal(expected, service.TryAcceptThing(helmet));
        Assert.Equal(expected, park.Find(4) is not null);
    }

    private class FakeServiceCenter(bool accept) : IServiceCenter
    {
        public IInventoryItem? LastInspectedItem { get; private set; }

        public bool CanAccept(IInventoryItem item)
        {
            LastInspectedItem = item;
            return accept;
        }
    }
}
