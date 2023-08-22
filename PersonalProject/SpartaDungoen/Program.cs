// See https://aka.ms/new-console-template for more information

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
    private ConsoleTypingPrinter _printer;

    private ResourceManager _resources;
    private Villiage _currentVilliage;
    private Player _currentPlayer;
    private FunctionReader _functionReader;
    public ThisisSpartaCore() { }
    public void Play()
    {
        LoadResourses();
        LoadData();
        InstanceInit();
        GameInit();
        GameStart();
    }

    private void InstanceInit()
    {
        _currentPlayer = new Player("_currentPlayer");
        _currentVilliage = _resources.VilliageDataContainer.GetVilliage("Sparta");
        _printer = new ConsoleTypingPrinter(100);
        _functionReader = new FunctionReader();
    }

    private void LoadResourses()
    {
        
    }
    
    private void LoadData()
    {
        _resources = new ResourceManager();
    }

    private void GameInit()
    {
        _printer.EndList.Add(" ");
        _printer.EndList.Add(_resources.StringContainer.GetString("RequestCommand"));
        
        Command.Init(_resources,_currentPlayer,_currentVilliage,_printer);
        string functionName = _currentVilliage.FunctionIDs[0]
        _functionReader.GetFunction(functionName).Execute();
    }

    private bool isGameOver = false;
    private void GameStart() 
    {
        int keyInput=0;
        _printer.Print();
        // 시작 화면 보여주기
        while (!isGameOver)
        {
            // 입력 받기
            while(!TryGetKey(_currentVilliage.FunctionIDs.Count,out keyInput)) { }
            
            // 상태 변경, 변경된 상태 적용, 화면 보여주기
            //상태의 변경
            string functionName = _currentVilliage.FunctionIDs[keyInput];
            _functionReader.GetFunction(functionName).Execute();
            
            
            // 화면 보여주기
            _printer.Print();
        }
    }

    private bool TryGetKey(int range, out int key)
    {
        char keyChar = '-';
        key = 0;
        bool isOk = false;
        
        Console.Write(">>");
        keyChar = Console.ReadKey(true).KeyChar;
        
        if ('0' <= keyChar && keyChar <= range+'0')
        {
            key = (int)keyChar - '0';
            isOk = true;
        }

        return isOk;
    }
    
}


