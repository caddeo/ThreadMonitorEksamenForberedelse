using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Car
    {
        public string Name { get; protected set; }

        public DateTime StartTime { get; protected set; }

        public DateTime EndTime { get; protected set; }

        public Car(string name)
        {
            this.Name = name;
            this.StartTime = DateTime.Now;
        }

        public void SetEndTime()
        {
            this.EndTime = DateTime.Now;
        }
    }
}
