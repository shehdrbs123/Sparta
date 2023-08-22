
public class InVilliage : Command
{
    public override void Execute()
    {
        string title = _stringContainer.GetString("InVilliageTop");
        string name = _stringContainer.GetString(_currentVilliage.NameID);
        
        _consoleTypingPrinter.TopList.Add(string.Format(title,name));
        _consoleTypingPrinter.TopList.Add(" ");
        ConsolePaint titlePainting = new ConsolePaint(0,0,name.Length,ConsoleColor.Yellow,ConsoleColor.Black);
        _consoleTypingPrinter.Paints.Add(titlePainting);

        int functionCount = _currentVilliage.FunctionIDs.Count;
        for (int i = 0; i < functionCount; i++)
        {
            string FunctionName = _stringContainer.GetString(_currentVilliage.FunctionIDs[i]);
            _consoleTypingPrinter.SelectList.Add(i + ". " + FunctionName);
        }
      
    }
}