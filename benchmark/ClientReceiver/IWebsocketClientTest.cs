namespace ClientReceiver
{
    public abstract class IWebsocketClientTest
    {
        protected IListener listener;
        public abstract void Send(string message);
        public void SetListener(IListener listener)
        {
            this.listener = listener;
        }
    }
}