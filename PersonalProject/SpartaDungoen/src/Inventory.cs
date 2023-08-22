public class Inventory
{
    private List<string> ItemNames;

    public Inventory()
    {
        ItemNames = new List<string>();
    }

    public string GetItemString(int i)
    {
        return ItemNames[i];
    }

    public void AddItemName(string itemName)
    {
        ItemNames.Add(itemName);
    }

    public int Count
    {
        get { return ItemNames.Count; }
    }
}