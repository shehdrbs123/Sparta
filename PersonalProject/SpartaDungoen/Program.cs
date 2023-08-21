// See https://aka.ms/new-console-template for more information


using ConsolePrinter;

public class Program
{
    public static void Main(string[] args)
    {
        ThisisSpartaCore core = new ThisisSpartaCore();
        core.Play();

    }
}
public class ThisisSpartaCore
{
    private StringContainer _stringResources;
    private Villiage _villiage;

    private const string stringDataPath = "Data\\String\\StringData_KR.txt";

    public ThisisSpartaCore()
    {
        _stringResources = new StringContainer();
    }
    public void Play()
    {
        LoadResourses();
        LoadData();
        GameInit();
        GameStart();
    }
    private void LoadResourses()
    {
        
    }
    
    private void LoadData()
    {
        _stringResources.Init(stringDataPath);
        
    }

    private void GameInit()
    {
        
    }
    
    private void GameStart()
    {
    }

    
}


