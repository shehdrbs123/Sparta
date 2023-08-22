public class ItemDataContainer : DataReader
{
    private const int _name=0;
    private const int _desciption=1;
    private const int _type=2;
    private const int _abilityName=3;
    private const int _abilityValue=4;
    private List<Item> _items;

    public ItemDataContainer()
    {
        _items = new List<Item>();
    }
    public override void Process(string[] data)
    {
        Item newItem = new Item();
        newItem.Name = data[_name];
        newItem.Description = data[_desciption];
        newItem.Type = Enum.Parse<EItemType>(data[_type]);
        newItem.AbilityName = Enum.Parse<EStatus>(data[_abilityName]);
        newItem.AbilityValue = int.Parse(data[_abilityValue]);
    }
}