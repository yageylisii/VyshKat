using VyshKat.Core.Creators;
using VyshKat.Core.Equipment;
using VyshKat.Core.Interfaces;

namespace VyshKat.App.Creators;

public class ChargingCabinetCreator : IItemCreator
{
    public string Code => "5";
    public string Name => "Зарядный шкаф";

    public IInventoryItem Create()
    {
        int number = Input.ReadInt("Инвентарный номер: ", 1, int.MaxValue);
        string name = Input.ReadText("Название: ");
        double energy = Input.ReadPositiveDouble("Расход энергии за сутки (кВт·ч): ");

        return new ChargingCabinet(number, name, energy);
    }
}
