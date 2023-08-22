public class FunctionReader
{
    private Dictionary<string, Command> _functionDic;

    public FunctionReader()
    {
        _functionDic = new Dictionary<string, Command>();

        SettingFunction();
    }

    private void SettingFunction()
    {
        _functionDic[nameof(CommandInVilliage)] = new CommandInVilliage();
        _functionDic[nameof(CommandInStatus)] = new CommandInStatus();
        _functionDic[nameof(CommandInInventory)] = new CommandInInventory();
    }

    public Command GetFunction(string FunctionID)
    {
        
        return _functionDic[FunctionID];
    }
}
