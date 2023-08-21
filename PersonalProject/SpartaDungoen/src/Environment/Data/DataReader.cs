

public abstract class DataReader
{
    public void Init(string path)
    {
        StreamReader sr = new StreamReader(path);
        string inputData = "END";
        while (inputData != "END")
        {
            inputData = sr.ReadLine();
            string[] data = inputData.Split('|');
            Process(data);
        }
        sr.Close();
    }

    public abstract void Process(string[] data);
}