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
            BilKoe queue1 = new BilKoe("Kø1");
            BilKoe queue2 = new BilKoe("Kø2");
            BilKoe queue3 = new BilKoe("Kø3");

            Producer producer = new Producer(queue1, queue2, queue3);

            Betalingsstander stander1 = new Betalingsstander(queue1);
            Betalingsstander stander2 = new Betalingsstander(queue2);
            Betalingsstander stander3 = new Betalingsstander(queue3);

            Thread producerThread = new Thread(producer.Run);

            Thread consumerThread1 = new Thread(stander1.Run);
            Thread consumerThread2 = new Thread(stander2.Run);
            Thread consumerThread3 = new Thread(stander3.Run);

            consumerThread1.Start();
            consumerThread2.Start();
            consumerThread3.Start();

            producerThread.Start();

            Console.ReadKey();

        }
    }
}
