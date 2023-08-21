namespace PersonalProject_스파르타던전.DataClass;


public enum EItemType
{
    Hand,Shirt,Pants,Shoes,Head
}
public interface IItem
{
    string Name { get; }
    string Description { get; }
    EItemType Type { get; }
    EStatus AbilityName { get; }
    int AbilityValue { get; }
    
}