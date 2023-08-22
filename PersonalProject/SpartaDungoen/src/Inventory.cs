public class Inventory
{
    public List<string> Items;

    public Inventory()
    {
        Items = new List<string>();
    }

    public string GetItem(int i)
    {
        return Items[i];
    }

    public void SetItem(string itemName)
    {
        Items.Add(itemName);
    }
}