using ConsolePrinter;

public delegate void Function(params Object[] param); 
public class FunctionReader
{
    private static FunctionReader _instance;
    public static FunctionReader Instance
    {
        get
        {
            if (_instance == null)
                _instance = new FunctionReader();
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    private Dictionary<string, List<Function>> FunctionDic;
    
    private FunctionReader()
    {
        FunctionDic = new Dictionary<string, List<Function>>();
        
        
    }

    public List<Function> GetFunction(string key)
    {
        return FunctionDic[key];
    }

    private void InViliage(IPrinter printer, Villiage villiage)
    {
        
    }


}
