namespace ConsolePrinter
{
    public interface IPrinter
    {
        public List<string> TopList { set; get; }
        public List<string> SelectList { set; get; }
        public List<string> BottomList { set; get; }

        public void Print();
    }

    public class ConsoleTypingPrinter : IPrinter
    {
        private List<string>[] _stringList;
        private int _typeSpeed;

        private enum EWritePos
        {
            Top = 0,
            Select,
            Bottom
        }

        public List<string> TopList
        {
            get { return _stringList[(int)EWritePos.Top]; }
            set { _stringList[(int)EWritePos.Top] = value; }
        }

        public List<string> SelectList
        {
            get { return _stringList[(int)EWritePos.Select]; }
            set { _stringList[(int)EWritePos.Select] = value; }
        }

        public List<string> BottomList
        {
            get { return _stringList[(int)EWritePos.Bottom]; }
            set { _stringList[(int)EWritePos.Top] = value; }
        }

        public ConsoleTypingPrinter(int typeSpeed)
        {
            _stringList = new List<string>[] { new List<string>(), new List<string>(), new List<string>() };
            foreach (var list in _stringList)
            {
                list.Capacity = 10;
            }

            _typeSpeed = typeSpeed;
        }

        public void Print()
        {
            bool isWriteAll = false;
            foreach (var writelist in _stringList)
            {
                foreach (var writeData in writelist)
                {
                    for (int i = 0; i < writeData.Length; ++i)
                    {
                        if (Console.KeyAvailable)
                            isWriteAll = true;
                        if (!isWriteAll)
                            Thread.Sleep(_typeSpeed);
                        Console.Write(writeData[i]);
                    }
                    Console.Write('\n');
                }

            }
        }
    }
}