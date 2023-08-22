public class Player
{
    public string Name { get; set; }
    public Inventory Inventory{ get; set; }
    public Status Status { get; set; }
    public Item[] Equiped { get; set; }
    public Player(string name)
    {
        Name = name;
        Inventory = new Inventory();
        Status = new Status();
        Equiped = new Item[Enum.GetNames<EItemType>().Length];
    }
    
}