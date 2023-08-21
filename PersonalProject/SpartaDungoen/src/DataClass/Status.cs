namespace PersonalProject_스파르타던전.DataClass;


public enum EStatus
{
    Level, Attack, Defense,Health,Gold
}
public interface IStatus
{
    public int Level { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
}