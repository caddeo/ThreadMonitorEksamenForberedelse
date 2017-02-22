using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Threading;

namespace ConsumerProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            CarQueue queue1 = new CarQueue("Queue 1");
            CarQueue queue2 = new CarQueue("Queue 2");
            CarQueue queue3 = new CarQueue("Queue 3");

            Producer producer = new Producer(queue1, queue2, queue3);

            Paywall stander1 = new Paywall(queue1);
            Paywall stander2 = new Paywall(queue2);
            Paywall stander3 = new Paywall(queue3);

            var threads = new List<Thread>()
            {
                new Thread(producer.Run),
                new Thread(stander1.Run),
                new Thread(stander2.Run),
                new Thread(stander3.Run)
            };

            Console.ReadKey();

        }
    }
}
