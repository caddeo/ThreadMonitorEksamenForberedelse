using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Model {
    public class Producer {
        // Felter

        List<BilKoe> queues = new List<BilKoe>();

        public Producer(BilKoe queue1, BilKoe queue2, BilKoe queue3)
        {
            queues.Add(queue1);
            queues.Add(queue2);
            queues.Add(queue3);
        }

        private Random generator = new Random((int)DateTime.Now.Ticks);

        Bil drivingcar = new Bil();

        public void Run() {
            while (true) {
                Thread.Sleep((int)(-Math.Log(1 - generator.NextDouble()) * 1000));

                BilKoe lowest = null;

                foreach(var queue in queues)
                {
                    if(lowest == null || queue.Count < lowest.Count)
                    {
                        lowest = queue;
                    }
                }

                lowest.Put(drivingcar);
                Console.WriteLine(drivingcar.Nr + " satte sig ind i kø " + lowest.Buffernavn);
            }
        }
    }
}
