using Microsoft.Extensions.DependencyInjection;
using VyshKat.App;
using VyshKat.App.Creators;
using VyshKat.Core.Creators;
using VyshKat.Core.Interfaces;
using VyshKat.Core.Memory;
using VyshKat.Core.Services;

//создаем контейнер
ServiceCollection services = new();

// прописываем зависимости
services.AddSingleton<IPark, Park>(); // пердает всем один и тот же объект
services.AddTransient<IServiceCenter, ServiceCenter>(); // передает каждый раз новый
services.AddTransient<ParkService>();
services.AddTransient<RentalService>();
services.AddTransient<StatisticsService>();
services.AddTransient<IItemCreator, BicycleCreator>();
services.AddTransient<IItemCreator, ScooterCreator>();
services.AddTransient<IItemCreator, HelmetCreator>();
services.AddTransient<IItemCreator, DocStationCreator>();
services.AddTransient<IItemCreator, ChargingCabinetCreator>();
services.AddTransient<ServiceRun>();

//передаем зависимости в serviceRun
using ServiceProvider provider = services.BuildServiceProvider();
ServiceRun serviceRun = provider.GetRequiredService<ServiceRun>();
serviceRun.Run();
