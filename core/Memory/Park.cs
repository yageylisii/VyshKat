// класс отвечающий за хранение устройст
using VyshKat.Core.Interfaces;
using VyshKat.Core.Vehicles;

namespace VyshKat.Core.Memory;

public class Park : IPark
{
    private readonly List<IInventoryItem> _items = new();

    public bool Remove(int inventoryNumber)
    {
        IInventoryItem? item = _items.FirstOrDefault(
            item =>
                item.InventoryNumber == inventoryNumber           
        ); // возвращаем первый схожий элемент или возращаем нул

        if (item is null)
        {
            return false;
        }

        _items.Remove(item);
        return true;
    }

    public void Add(IInventoryItem item)
    {
        if (Find(item.InventoryNumber) is not null)
        {
            throw new ArgumentException(
                "Такой инвентарный номер уже существует"
            );
        }
        _items.Add(item);
    }
    public IInventoryItem? Find( // 
        int inventoryNumber)
    {
        return _items.FirstOrDefault(
            item =>
                item.InventoryNumber ==
                inventoryNumber
        );
    }

    public Vehicle? FindVehicle( // ищем транспорт для аренды
        int inventoryNumber)
    {
        return _items
            .OfType<Vehicle>()
            .FirstOrDefault(
                vehicle =>
                    vehicle.InventoryNumber ==
                    inventoryNumber
            );
    }

    public IEnumerable<IInventoryItem> GetAll()
    {
        return _items;
    }
}