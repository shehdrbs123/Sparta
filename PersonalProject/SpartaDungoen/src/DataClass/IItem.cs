public enum EItemType
{
    Hand=0,Shirt,Pants,Shoes,Head
}
public class Item
{
    public string NameID { get; set; }
    public string DescriptionID { get; set; }
    public EItemType Type { get; set; }
    public EStatus AbilityName { get; set; }
    public int AbilityValue { get; set; }
}