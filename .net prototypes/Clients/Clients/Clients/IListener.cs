using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
    public interface IListener
    {
        public void Receive(string message);
    }
}
