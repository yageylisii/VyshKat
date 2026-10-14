using VyshKat.Core.Interfaces;

namespace VyshKat.Core.Creators;
public interface IItemCreator
{
    string Code { get; }  // номер команды
    string Name { get; }  // название для меню
    IInventoryItem Create();
}