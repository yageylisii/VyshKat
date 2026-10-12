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
        double dailyEnergyConsumption)
        : base(inventoryNumber, name)
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