using System.IO;

namespace Practice.Scripts.Managers
{
    
    public abstract class IDataReader
    {
        public virtual void Init(string path)
        {
            StreamReader sr = new StreamReader(path);
            string inputData = "";
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                inputData = sr.ReadLine();
                if (inputData == "END")
                    break;
                string[] data = inputData.Split('|');
                Process(data);
            }
            sr.Close();
        }

        public abstract void Process(string[] data);
    }
}