public class CommandInInventoryEquip : Command
{
    public static int? basicSize;

    public override void Execute()
    {
        //  Top Print
        string functionName = nameof(CommandInInventoryEquip);
        _currentFunctionListIdsIDs.FunctionListIds = _functionListContainer.GetFunctionList(functionName);
        if (!basicSize.HasValue)
            basicSize = _currentFunctionListIdsIDs.FunctionListIds.Count;
        string title = _stringContainer.GetString(functionName+"Top");
        _consoleTypingPrinter.TopList.Add(title);
        _consoleTypingPrinter.TopList.Add("");

        // Info Print
        Inventory inventory = _currentPlayer.Inventory;
        
        _consoleTypingPrinter.InfoList.Add(_stringContainer.GetString("ItemList"));
        for (int i = 0; i < inventory.Count; i++)
        {
            Item item = _itemDataContainer.GetItem(inventory.GetItemString(i));
            string abilityValue = item.AbilityValue >= 0 ? "+" + item.AbilityValue : "-" + item.AbilityValue;
            string name = _stringContainer.GetString(item.NameID);
            string description = _stringContainer.GetString(item.DescriptionID);
            string AbilityType = item.AbilityName.ToString();
            string Equip = "[E]";
            
            if (_currentPlayer.Equiped[(int)item.Type] == null)
            {
                Equip = "";
            }

            string result = string.Format($"- {i+basicSize}. {Equip,4} {name,-10}|{AbilityType,-10} {abilityValue,-6}|{description}");
            _consoleTypingPrinter.InfoList.Add(result);
        }
        _consoleTypingPrinter.InfoList.Add("");
        
        //  Select Print
        
        
        int functionCount = _currentFunctionListIdsIDs.Count;
        for (int i = 1; i < basicSize; i++)
        {
            string FunctionName = _stringContainer.GetString(_currentFunctionListIdsIDs.FunctionListIds[i]);
            _consoleTypingPrinter.SelectList.Add(i + ". " + FunctionName);
        }
        
        for (int i = 0; i < inventory.Count; i++)
        {
            _currentFunctionListIdsIDs.FunctionListIds.Add("CommandEquip");    
        }
    }
}