public class FunctionReader
{
    private const string InVilliage = "InVilliage";
    private Dictionary<string, Command> _functionDic;

    public FunctionReader()
    {
        _functionDic = new Dictionary<string, Command>();

        SettingFunction();
    }

    private void SettingFunction()
    {
        _functionDic[InVilliage] = new InVilliage();
        //_functionDic[]
    }

    public Command GetFunction(string FunctionID)
    {
        
        return _functionDic[FunctionID];
    }
}
