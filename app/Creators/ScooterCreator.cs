using VyshKat.Core.Creators;
using VyshKat.Core.Interfaces;
using VyshKat.Core.Vehicles;

namespace VyshKat.App.Creators;

public class ScooterCreator : IItemCreator
{
    public string Code => "2";
    public string Name => "Электросамокат";

    public IInventoryItem Create()
    {
        int number = Input.ReadInt("Инвентарный номер: ", 1, int.MaxValue);
        string name = Input.ReadText("Название: ");
        int level = Input.ReadInt("Простота для новичка (1–10): ", 1, 10);
        int condition = Input.ReadInt("Состояние (1–100): ", 1, 100);
        double energy = Input.ReadPositiveDouble("Расход энергии за сутки (кВт·ч): ");

        return new Scooter(number, name, level, condition, energy);
    }
}
