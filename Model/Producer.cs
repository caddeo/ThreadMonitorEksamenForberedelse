using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Model {
    public class Producer {

        readonly List<CarQueue> _queues = new List<CarQueue>();

        private List<Car> _cars;

        public Producer(params CarQueue[] carQueues)
        {
            foreach (var queue in carQueues)
            {
                this._queues.Add(queue);
            }

            _cars = new List<Car>()
            {
                new Car("1"),
                new Car("2"),
                new Car("3"),
            };
        }

        public void Run()
        {
            var random = new Random((int)DateTime.Now.Ticks);

            while (true) {
                Thread.Sleep((int)(-Math.Log(1 - random.NextDouble()) * 1000));

                CarQueue lowestQueue = null;

                foreach(var queue in _queues)
                {
                    if(lowestQueue == null || queue.Count < lowestQueue.Count)
                    {
                        lowestQueue = queue;
                    }
                }

                var currentCar = _cars[random.Next(_cars.Count)];

                lowestQueue?.Put(currentCar);
                Console.WriteLine($" {currentCar.Name} entered the queue {lowestQueue?.Name}");
            }
        }
    }
}
