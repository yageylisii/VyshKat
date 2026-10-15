using VyshKat.Core.Creators;
using VyshKat.Core.Equipment;
using VyshKat.Core.Interfaces;

namespace VyshKat.App.Creators;

public class DocStationCreator : IItemCreator
{
    public string Code => "4";
    public string Name => "Док-станция";

    public IInventoryItem Create()
    {
        int number = Input.ReadInt("Инвентарный номер: ", 1, int.MaxValue);
        string name = Input.ReadText("Название: ");
        int condition = Input.ReadInt("Состояние (0–100): ", 0, 100);

        return new DocStation(number, name, condition);
    }
}
