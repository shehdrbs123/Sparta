public class ResourceManager
{
    public StringContainer StringContainer { get; private set; }
    public VilliageDataContainer VilliageDataContainer { get; private set; }
    public FunctionListContainer FunctionListContainer { get; private set; }
    
    public ItemDataContainer ItemDataContainer { get; private set; }
    public StoreDataContainer StoreDataContainer { get; private set; }
    
    public DungoenDataContainer DungoenDataContainer { get; private set; }
    public DungoenListDataContainer DungoenListDataContainer { get; private set; }
    public ResourceManager()
    {
        StringContainer = new StringContainer();
        StringContainer.Init("Data\\String\\StringData_KR.txt");
        VilliageDataContainer = new VilliageDataContainer();
        VilliageDataContainer.Init("Data\\VilliageData_KR.txt");
        FunctionListContainer = new FunctionListContainer();
        FunctionListContainer.Init("Data\\FunctionList_KR.txt");
        ItemDataContainer = new ItemDataContainer();
        ItemDataContainer.Init("Data\\ItemList_KR.txt");
        StoreDataContainer = new StoreDataContainer();
        StoreDataContainer.Init("Data\\StoreData_KR.txt");
        DungoenListDataContainer = new DungoenListDataContainer();
        DungoenListDataContainer.Init("Data\\DungoenListData_KR.txt");
        DungoenDataContainer = new DungoenDataContainer();
        DungoenDataContainer.Init("Data\\DungoenData_KR.txt");
    }
}
