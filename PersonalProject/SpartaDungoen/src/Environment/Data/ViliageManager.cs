
public class ViliageManager : DataReader
{
    private List<Villiage> _villiages;

    public ViliageManager() : base()
    {
        _villiages = new List<Villiage>();
    }
    public override void Process(string[] data)
    {
        Villiage villiage = new Villiage();
        
        villiage.Name = data[0];
        int FunctionCount = int.Parse(data[1]);
        villiage.Function.Capacity = FunctionCount;
        
        for (int i = 0; i < FunctionCount; ++i)
        {
            villiage.Function.Add(data[2+i]);
        }

    }
}