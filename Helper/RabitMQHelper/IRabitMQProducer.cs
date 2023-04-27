using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.RabitMQHelper
{
    public interface IRabitMQProducer
    {
        public void SendData<T>(T data);
    }
}
