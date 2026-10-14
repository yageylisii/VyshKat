using VyshKat.Core.Interfaces;

namespace VyshKat.Core.Equipment;
public class ChargingCabinet :
    EquipmentItem,
    IEnergyConsumer
{
    public double DailyEnergyConsumption { get; } // потребление в день

    public ChargingCabinet(
        int inventoryNumber,
        string name,
        double dailyEnergyConsumption,
        int condition)
        : base(inventoryNumber, name, condition)
    {   
        if (dailyEnergyConsumption <= 0)
        {
            throw new ArgumentException(
                "Потребление должно быть больше нуля"
            );
        }
        DailyEnergyConsumption =
            dailyEnergyConsumption;
    }
}