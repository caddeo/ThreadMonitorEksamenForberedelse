using System;
using System.Collections.Generic;
using System.Threading;

namespace Model {

    // Unbounded buffer - bilkø
    
    public class CarQueue {

        private readonly Queue<Car> _queue = new Queue<Car>();

        // Thread locking object
        private readonly object _queuelock = new object();

        public int Count
        {
            get
            {
                lock (_queuelock)
                {
                    return _queue.Count;
                }
            }
        }

        public string Name { get; protected set; }

        public CarQueue(string name) 
        {
            this.Name = name;
        }

        public void Put(Car car)
        {
            lock(_queuelock)
            {
                if(_queue.Count == 0)
                {
                    Console.WriteLine("Waiting for a new car");
                    Monitor.Pulse(_queuelock);
                }

                _queue.Enqueue(car);
                Console.WriteLine($"{car.Name} entered the _queue: {Name}");
                Console.WriteLine("There's now "+_queue.Count+" in the _queue");
            }
        }
        
        public Car Get() 
        {
            lock(_queuelock)
            {
                if(_queue.Count == 0)
                {
                    // Waiting for a car to enter the _queue
                    Console.WriteLine("Waiting for car to enter");
                    Monitor.Wait(_queuelock);
                }

                // Let the car in the front of the _queue leave
                var car = _queue.Dequeue();
                Console.WriteLine($"Car ({car.Name}) left the queue");

                car.SetEndTime();
                return car;
            }
        }
    }

}
