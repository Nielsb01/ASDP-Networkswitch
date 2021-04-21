namespace ClientReceiver
{
    public abstract class IWebsocketClientTest
    {
        protected IListener Listener;
        public abstract void Send(string message);
        public void SetListener(IListener listener)
        {
            this.Listener = listener;
        }
    }
}