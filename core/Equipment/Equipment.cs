using VyshKat.Core.Interfaces;

namespace VyshKat.Core.Equipment;

public abstract class EquipmentItem : IInventoryItem
{
    public int InventoryNumber { get; }
    public string Name { get; }

    protected EquipmentItem(
        int inventoryNumber,
        string name)
    {
        if (inventoryNumber <= 0)
        {
            throw new ArgumentException(
                "Номер должен быть больше нуля"
            );
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Название не может быть пустым"
            );
        }

        InventoryNumber = inventoryNumber;
        Name = name;
    }
}