using VyshKat.Core.Interfaces;
namespace VyshKat.Core.Vehicles;

public class Scooter : Vehicle, IEnergyConsumer
{
    public double DailyEnergyConsumption {get;} // потребление в день

    public Scooter (int _id, string _name, int _level, int _statement, double _dailyEnergyConsumption)
    : base(_id, _name, _level, _statement)
    {   
        if (_dailyEnergyConsumption <= 0)
        {
            throw new ArgumentException(
                "Потребление должно быть больше 0"
            );
        }
        DailyEnergyConsumption = _dailyEnergyConsumption;
        
    }
}