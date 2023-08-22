public class CommandEquip : CommandInInventoryEquip
{
    public override void Execute()
    {
        int input = _inputMemory.preInput - basicSize.Value;

        string itemString = _currentPlayer.Inventory.GetItemString(input);
        Item item = _itemDataContainer.GetItem(itemString);

        Item currentEquiped = _currentPlayer.Equiped[(int)item.Type];
        if (currentEquiped == item)
        {
            _currentPlayer.Equiped[(int)item.Type] = null;
        }else
        {
            _currentPlayer.Equiped[(int)item.Type] = item;
        } 

        base.Execute();
    }
}