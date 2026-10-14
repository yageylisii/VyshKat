using VyshKat.Core.Creators;
using VyshKat.Core.Equipment;
using VyshKat.Core.Interfaces;
using VyshKat.Core.Services;
using VyshKat.Core.Vehicles;

namespace VyshKat.App;

public class ServiceRun
{
    private readonly ParkService _parkService;
    private readonly RentalService _rentalService;
    private readonly StatisticsService _statisticsService;
    private readonly IReadOnlyList<IItemCreator> _creators;

    // созаем все объекты в соотвествии с контейнером
    public ServiceRun(
        ParkService parkService,
        RentalService rentalService,
        StatisticsService statisticsService,
        IEnumerable<IItemCreator> creators)
    {
        _parkService = parkService;
        _rentalService = rentalService;
        _statisticsService = statisticsService;
        _creators = creators.ToList();
    }

    public void Run()
    {
        while (true)
        {
            Output.ShowMenu();
            string command = Input.ReadCommand();

            if (command == "0")
            {
                Output.ShowMessage("Работа завершена.");
                return;
            }

            try
            {
                switch (command)
                {
                    case "1": AddItem(); break;
                    case "2": RentVehicle(); break;
                    case "3": ShowStatistics(); break;
                    default: Output.ShowMessage("Нет такой команды."); break;
                }
            }
            catch (ArgumentException error)
            {
                Output.ShowMessage(error.Message);
            }
        }
    }

    private void AddItem()
    {
        Output.ShowAddMenu(_creators);
        string kind = Input.ReadCommand();

        IItemCreator? creator = _creators.FirstOrDefault(item => item.Code == kind);
        if (creator is null)
        {
            Output.ShowMessage("Нет такого вида техники или вещи.");
            return;
        }

        AddCreatedItem(creator.Create());
    }

    private void AddCreatedItem(IInventoryItem item)
    {
        if (item is Vehicle vehicle)
        {
            bool accepted = _parkService.TryAcceptThing(vehicle);
            Output.ShowMessage(accepted
                ? "Транспорт принят в парк."
                : "Транспорт не прошёл техосмотр (состояние должно быть не ниже 70).");
            return;
        }

        if (item is EquipmentItem equipment)
        {
            bool accepted = _parkService.TryAcceptThing(equipment);
            Output.ShowMessage(accepted
                ? "Вещь добавлена в парк."
                : "Вещь не прошла техосмотр (состояние должно быть не ниже 70).");
            return;
        }

        throw new ArgumentException("Этот тип предмета пока не поддерживается.");
    }

    private void RentVehicle()
    {
        int number = Input.ReadInt("Инвентарный номер транспорта: ", 1, int.MaxValue);
        bool isBeginner = Input.ReadYesNo("Арендатор новичок? (Да/Нет): ");

        bool rented = _rentalService.TryRent(number, isBeginner);
        Output.ShowMessage(rented
            ? "Транспорт выдан в аренду."
            : "Транспорт не найден, уже арендован или не подходит новичку.");
    }

    private void ShowStatistics()
    {
        Output.ShowStatistics(
            _statisticsService.GetTotalCount(),
            _statisticsService.GetTotalDailyEnergyConsumption(),
            _statisticsService.GetAllItems(),
            _statisticsService.GetVehiclesForBeginners());
    }
}
