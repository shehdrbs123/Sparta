public class ResourceManager
{
    public StringContainer StringContainer { get; private set; }

    public VilliageDataContainer VilliageDataContainer { get; private set; }
    
    public ResourceManager()
    {
        StringContainer = new StringContainer();
        StringContainer.Init("Data\\String\\StringData_KR.txt");
        VilliageDataContainer = new VilliageDataContainer();
        VilliageDataContainer.Init("Data\\VilliageData_KR.txt");
    }
}