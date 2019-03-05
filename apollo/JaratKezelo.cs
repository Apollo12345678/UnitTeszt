using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apollo
{
    class JaratKezelo
    {
        List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (Kereses(jaratSzam)==null)
            {
               jaratok.Add(new Jarat(jaratSzam, repterHonnan, repterHova, indulas));
            }
        }

        public void Keses(string jaratSZam, int keses)
        {
            if (Kereses(jaratSZam)!=null)
            {
                Kereses(jaratSZam).setKeses(keses);
            }
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            if (Kereses(jaratSzam) != null)
            {
                return Kereses(jaratSzam).getIndulas();
            }
            else
            {
                return new DateTime(1,1,1,1,1,1);
            }
            
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            List<string> vissza = new List<string>();
            foreach(var i in jaratok)
            {
                if (i.getHonnanRepter().Equals(repter))
                {
                    vissza.Add(i.getJaratszam());
                }
            }
            return vissza;
        }

        private Jarat Kereses(string jaratSzam)
        {
            foreach(var i in jaratok)
            {
                if (i.getJaratszam().Equals(jaratSzam))
                {
                    return i;
                }
            }
            return null;
        }

        public int getListDarab()
        {
            return jaratok.Count;
        }

        class Jarat
        {
            public string JaratSzam;
            public string HonnanRepter;
            public string HovaRepter;
            public DateTime Indulas;
            public int Keses;

            public Jarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas)
            {
                this.JaratSzam = jaratSzam;
                this.HonnanRepter = honnanRepter;
                this.HovaRepter = hovaRepter;
                this.Indulas = indulas;
                this.Keses = 0;
            }

            public string getJaratszam()
            {
                string vissza = this.JaratSzam;
                return vissza;
            }

            public void setKeses(int keses)
            {
                if (this.Keses + keses < 0)
                {
                    throw new NegativKesesException("Negativ keses exception");
                }else
                {
                    this.Keses += keses;
                }
                
            }

            public DateTime getIndulas()
            {
                DateTime ido = this.Indulas;
                return ido.AddMinutes(this.Keses);
            }

            public string getHonnanRepter()
            {
                string vissza = this.HonnanRepter;
                return vissza;
            }
        }

        [Serializable()]
        public class NegativKesesException : Exception
        {
            public NegativKesesException() : base() { }
            public NegativKesesException(string message) : base(message) { }
            public NegativKesesException(string message, System.Exception inner) : base(message, inner) { }

            // A constructor is needed for serialization when an
            // exception propagates from a remoting server to the client. 
            protected NegativKesesException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }


    }
}
