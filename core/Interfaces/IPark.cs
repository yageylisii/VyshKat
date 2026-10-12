using VyshKat.Core.Vehicles;


namespace VyshKat.Core.Interfaces;
public interface IPark
{
    void Add(IInventoryItem item);
    bool Remove(int inventoryNumber);

    IInventoryItem? Find(
        int inventoryNumber
    );

    Vehicle? FindVehicle(
        int inventoryNumber
    );
    
    IEnumerable<IInventoryItem> GetAll();


}