using VyshKat.Core.Interfaces;

namespace VyshKat.Core.Equipment;

public abstract class EquipmentItem : IInventoryItem
{
    public int InventoryNumber { get; }
    public string Name { get; }

    public int Condition { get; }

    protected EquipmentItem(
        int inventoryNumber,
        string name,
        int condition)
    {
        if (inventoryNumber <= 0)
        {
            throw new ArgumentException(
                "Номер должен быть больше нуля"
            );
        }
        if (condition < 0 || condition > 100)
        {
            throw new ArgumentException(
                "Состояние должно быть от 0 до 100"
            );
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Название не может быть пустым"
            );
        }

        Condition = condition;
        InventoryNumber = inventoryNumber;
        Name = name;
    }
}
