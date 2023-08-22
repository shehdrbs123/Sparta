public class CommandInStatus : Command
{
    public override void Execute()
    {
        // Top Print
        string functionName = nameof(CommandInStatus);
        string title = _stringContainer.GetString(functionName+"Top");
        _consoleTypingPrinter.TopList.Add(title);
        _consoleTypingPrinter.TopList.Add("");

        //Info Print
        string name = _currentPlayer.Name;
        string level = _stringContainer.GetString("Level");
        string Job = _stringContainer.GetString("Job");
        string Attack = _stringContainer.GetString("Attack");
        string Defense = _stringContainer.GetString("Defense");
        string Health = _stringContainer.GetString("Health");
        string Gold = _stringContainer.GetString("Gold");
        
        _consoleTypingPrinter.InfoList.Add($"이름 : {name} \n");
        _consoleTypingPrinter.InfoList.Add(string.Format(level, _currentPlayer.Status.Level));
        _consoleTypingPrinter.InfoList.Add(string.Format(Job, _currentPlayer.Status.Job));
        _consoleTypingPrinter.InfoList.Add(string.Format(Attack, _currentPlayer.Status.Attack));
        _consoleTypingPrinter.InfoList.Add(string.Format(Defense, _currentPlayer.Status.Defense));
        _consoleTypingPrinter.InfoList.Add(string.Format(Health, _currentPlayer.Status.Health));
        _consoleTypingPrinter.InfoList.Add(string.Format(Gold, _currentPlayer.Status.Gold));
        _consoleTypingPrinter.InfoList.Add(" ");

        
        // Select Print
        CurrentFunctionListIdsIDs.FunctionListIds = _functionListContainer.GetFunctionList(functionName);
        
        int functionCount = CurrentFunctionListIdsIDs.Count;
        for (int i = 0; i < functionCount; i++)
        {
            string FunctionName = _stringContainer.GetString(CurrentFunctionListIdsIDs.FunctionListIds[i]);
            _consoleTypingPrinter.SelectList.Add(i + ". " + FunctionName);
        }

    }
}