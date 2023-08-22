public enum EStatus
{
    Level, Attack, Defense,Health,Gold
}
public interface IStatus
{
    public int Level { get; set; }
    public string Job { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
}

public class Status : IStatus
{
    public Status()
    {
        Level = 1;
        Job = "전사";
        Attack = 10;
        Defense = 5;
        Health = 100;
        Gold = 1500;
    }
    public int Level { get; set; }
    public string Job { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
}