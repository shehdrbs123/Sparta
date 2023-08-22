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
        _functionDic[nameof(CommandInInventoryEquip)] = new CommandInInventoryEquip();
        _functionDic[nameof(CommandEquip)] = new CommandEquip();
    }

    public Command GetFunction(string functionId)
    {
        
        return _functionDic[functionId];
    }
}
