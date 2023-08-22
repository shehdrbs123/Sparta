
public abstract class Command
{
    protected static ResourceManager _resourceManager;
    protected static StringContainer _stringContainer;
    protected static VilliageDataContainer _villiageDataContainer;
    protected static Player _currentPlayer;
    protected static Villiage _CurrentVilliage;
    protected static ConsoleTypingPrinter _consoleTypingPrinter;
    protected static FunctionListContainer _functionListContainer;
    protected static ItemDataContainer _itemDataContainer;
    protected static CurrentFunctionListIds _currentFunctionListIdsIDs;
    protected static InputMemory _inputMemory;

    public static void Init(ResourceManager resourceManager, Player currentPlayer, Villiage currentVilliage, ConsoleTypingPrinter consoleTypingPrinter, CurrentFunctionListIds currentFunctionListIdsIds, InputMemory inputMemory)
    {
        _resourceManager = resourceManager;
        _currentPlayer = currentPlayer;
        _CurrentVilliage = currentVilliage;
        _consoleTypingPrinter = consoleTypingPrinter;
        _stringContainer = _resourceManager.StringContainer;
        _villiageDataContainer = _resourceManager.VilliageDataContainer;
        _functionListContainer = _resourceManager.FunctionListContainer;
        _itemDataContainer = _resourceManager.ItemDataContainer;
        _currentFunctionListIdsIDs = currentFunctionListIdsIds;
        _inputMemory = inputMemory;
    }
    public abstract void Execute();
}

