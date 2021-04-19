using System.Threading.Tasks;

namespace ConsoleApp1
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