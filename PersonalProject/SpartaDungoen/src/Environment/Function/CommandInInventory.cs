public class CommandInInventory : Command
{
    public override void Execute()
    {
        //  Top Print
        string functionName = nameof(CommandInInventory);
        string title = _stringContainer.GetString(functionName+"Top");
        _consoleTypingPrinter.TopList.Add(title);
        _consoleTypingPrinter.TopList.Add("");

        // Info Print
        Inventory inventory = _currentPlayer.Inventory;
        
        
        //  Select Print
        CurrentFunctionListIdsIDs.FunctionListIds = _functionListContainer.GetFunctionList(functionName);
        
        int functionCount = CurrentFunctionListIdsIDs.Count;
        for (int i = 0; i < functionCount; i++)
        {
            string FunctionName = _stringContainer.GetString(CurrentFunctionListIdsIDs.FunctionListIds[i]);
            _consoleTypingPrinter.SelectList.Add(i + ". " + FunctionName);
        }

    }
}