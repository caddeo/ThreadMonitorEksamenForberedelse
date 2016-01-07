using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Bil
    {
        public static int lastnr = 0;
        private int nr;                 // nr for identifikation
        private DateTime startTid;      // tid for "indkørsel" 
        private DateTime slutTid;       // tid for "kø forladt" / "ved stander"

        public Bil()
        {
            ++lastnr;
            this.nr = lastnr;
            this.startTid = DateTime.Now;
        }

        public void SetSlutTid()
        {
            this.slutTid = DateTime.Now;
        }
        public int Nr
        {
            get { return this.nr; }
        }

        public DateTime StartTid
        {
            get { return this.startTid; }
        }
        public DateTime SlutTid
        {
            get { return this.slutTid; }
        }
    }
}
