using VyshKat.Core.Creators;
using VyshKat.Core.Equipment;
using VyshKat.Core.Interfaces;

namespace VyshKat.App.Creators;

public class HelmetCreator : IItemCreator
{
    public string Code => "3";
    public string Name => "Шлем";

    public IInventoryItem Create()
    {
        int number = Input.ReadInt("Инвентарный номер: ", 1, int.MaxValue);
        string name = Input.ReadText("Название: ");
        int condition = Input.ReadInt("Состояние (0–100): ", 0, 100);

        return new Helmet(number, name, condition);
    }
}
