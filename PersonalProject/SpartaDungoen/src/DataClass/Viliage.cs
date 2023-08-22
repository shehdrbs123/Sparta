public class Villiage
{
    public string NameID{ set; get; }
    public List<string> FunctionIDs { private set; get; }

    public Villiage()
    {
        FunctionIDs = new List<string>();
    }
}