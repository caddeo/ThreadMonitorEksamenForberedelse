using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Model {
    // Consumer
    public class Betalingsstander {

        private BilKoe _queue;

        public Betalingsstander(BilKoe queue)
        {
            _queue = queue;
        }
        public void Run() {
            while (true) 
            {
                Thread.Sleep(2000);

                Console.WriteLine("Får fat på en bil fra "+_queue.Buffernavn);
                Bil bil = _queue.Get();
            }
        }
    }
}
