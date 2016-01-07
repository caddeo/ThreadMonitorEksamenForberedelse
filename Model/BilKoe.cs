using System;
using System.Collections.Generic;
using System.Threading;

namespace Model {

    // Unbounded buffer - bilkø
    
    public class BilKoe {

        private Queue<Bil> queue = new Queue<Bil>();
        private string buffernavn;     // navn på buffer - for at kunne skelne mellem objekter
        private object _queuelock = new object();

        public BilKoe(string buffernavn) 
        {
            this.buffernavn = buffernavn;
        }

        public void Put(Bil enBil)
        {
            lock(_queuelock)
            {
                // Hvis der ikke er nogen ind
                // Så lad køen vide at der er en på vej
                if(queue.Count == 0)
                {
                    Console.WriteLine("Bil på vej");
                    Monitor.Pulse(_queuelock);
                }

                queue.Enqueue(enBil);
                Console.WriteLine(enBil.Nr + " Satte sig i kø #"+buffernavn);
                Console.WriteLine("Der er nu "+queue.Count+" i køen");
            }
        }
        
        public Bil Get() 
        {
            lock(_queuelock)
            {
                if(queue.Count == 0)
                {
                    // Venter på pulse fra Put (hvis nogen sætter sig ind i køen)
                    Console.WriteLine("Venter på der kommer en bil<--------------------");
                    Monitor.Wait(_queuelock);
                }

                // Finder den sidste bil og smider den ud
                Bil bil = queue.Dequeue();
                Console.WriteLine("Bil "+bil.Nr+" forlod bilen");

                bil.SetSlutTid();
                return bil;
            }
            // Denne metode skal du selv kode ...
        }
        
        public int Count        // antal biler i køen 
        { get 
            {
                lock(_queuelock)
                {
                    return queue.Count;
                }
            }
        }

        public string Buffernavn
        {
            get { return this.buffernavn; }
        }
    }

}
