namespace My_App.Services
{
    public class VisitorCounter
    {
        private int _count = 0;
        private readonly object _lock = new();

        public int Increment()
        {
            lock (_lock)
            {
                return ++_count;
            }
        }

        public int GetCount()
        {
            lock (_lock)
            {
                return _count;
            }
        }
    }

}
