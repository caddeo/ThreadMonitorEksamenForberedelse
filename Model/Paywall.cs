using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Model {
    // Consumer
    public class Paywall
    {

        private bool _running;
        private readonly CarQueue _carQueue;

        public Paywall(CarQueue carQueue)
        {
            _carQueue = carQueue;
        }

        public void Run()
        {
            _running = true;
            while (_running) 
            {
                Thread.Sleep(2000);

                Console.WriteLine($"Getting a car from {_carQueue.Name}");
                var car = _carQueue.Get();
            }
        }
    }
}
