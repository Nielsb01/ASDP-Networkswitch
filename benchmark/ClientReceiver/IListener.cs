namespace ClientReceiver
{
    public interface IListener
    {
        public void Receive(string message);
        public long GetSum();
        public int GetCount();
    }
}
