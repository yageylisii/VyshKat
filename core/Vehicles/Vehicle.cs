using VyshKat.Core.Interfaces;


namespace VyshKat.Core.Vehicles;
public abstract class Vehicle : IInventoryItem
{   

    public int InventoryNumber {get;}
    public string Name {get;}
    public int LevelUsing {get;} // простота новичка (1-10)
    public int Statement {get;} // состояние 
    public bool IsRented { get; private set; }

    protected Vehicle (int _inventoryNumber, string _name, int _levelusing, int _statement)
    {   

        if (_levelusing < 1 || _levelusing > 10)
        {
            throw new ArgumentException(
                "Уровень должен быть от 1 до 10"
            );
        }
        if (_statement < 1 || _statement > 100)
        {
            throw new ArgumentException(
                "Состояние должно быть от 1 до 100"
            );
        }
        if (_inventoryNumber <= 0)
        {
            throw new ArgumentException(
                "ID должен быть больше нуля"
            );
        }
        if (string.IsNullOrWhiteSpace(_name))
        {
            throw new ArgumentException(
                "Название не может быть пустым"
            );
        }


        InventoryNumber = _inventoryNumber;
        Name = _name;
        LevelUsing = _levelusing;
        Statement = _statement;
    }

    public bool CanBeRentedByBeginner()
    {
        return LevelUsing >= 6;
    }

    public void Rent()
    {
        if (IsRented)
        {
            throw new InvalidOperationException(
                "Транспорт уже арендован"
            );
        }

        IsRented = true;
    }

    public void Return()
    {
        if (!IsRented)
        {
            throw new InvalidOperationException(
                "Транспорт не находится в аренде"
            );
        }

        IsRented = false;
    }

}