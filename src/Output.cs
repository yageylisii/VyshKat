using VyshKat.Core.Creators;
using VyshKat.Core.Interfaces;
using VyshKat.Core.Vehicles;

namespace VyshKat.App;

public static class Output
{
    public static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1 — Добавить транспорт или вещь");
        Console.WriteLine("2 — Арендовать транспорт");
        Console.WriteLine("3 — Показать статистику");
        Console.WriteLine("0 — Выход");
        Console.Write("Команда: ");
    }

    public static void ShowAddMenu(IEnumerable<IItemCreator> creators)
    {
        foreach (IItemCreator creator in creators)
        {
            Console.WriteLine($"{creator.Code} — {creator.Name}");
        }

        Console.Write("Тип: ");
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static void ShowStatistics(
        int totalCount,
        double totalEnergy,
        IEnumerable<IInventoryItem> items,
        IEnumerable<Vehicle> beginnerVehicles)
    {
        Console.WriteLine($"Всего единиц: {totalCount}");
        Console.WriteLine($"Суммарный расход энергии за сутки: {totalEnergy:0.##} кВт·ч");

        Console.WriteLine("Весь инвентарь:");
        foreach (IInventoryItem item in items)
        {
            Console.WriteLine($"    № {item.InventoryNumber}: {item.Name} ({item.GetType().Name})");
        }

        Console.WriteLine("Свободный транспорт для новичков:");
        foreach (Vehicle vehicle in beginnerVehicles)
        {
            Console.WriteLine($"  № {vehicle.InventoryNumber}: {vehicle.Name}");
        }
    }
}
