using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpOgDB3layer
{
    public interface ISubscriber
    {
        void Update(IPublisher publisher, string message);
    }
}
