using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
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
