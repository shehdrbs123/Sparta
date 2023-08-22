
public abstract class Command
{
    protected static ResourceManager _resourceManager;
    protected static StringContainer _stringContainer;
    protected static VilliageDataContainer _villiageDataContainer;
    protected static Player _currentPlayer;
    protected static Villiage _currentVilliage;
    protected static ConsoleTypingPrinter _consoleTypingPrinter;

    public static void Init(ResourceManager resourceManager, Player currentPlayer, Villiage currentVilliage, ConsoleTypingPrinter consoleTypingPrinter)
    {
        _resourceManager = resourceManager;
        _currentPlayer = currentPlayer;
        _currentVilliage = currentVilliage;
        _consoleTypingPrinter = consoleTypingPrinter;
        _stringContainer = _resourceManager.StringContainer;
        _villiageDataContainer = _resourceManager.VilliageDataContainer;
    }
    public abstract void Execute();
}

