using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class LogProb
    {
      
        public string Name { get; set; }

        public string Durum { get; set; }
        public string Marka { get; set; }

        public string Kisi { get; set; }

        

        public LogProb(string name, string durum, string marka, string kisi)
        {

            
            Name = name;
            Durum = durum;
            Marka = marka;
            Kisi = kisi;
            
        }

    }
}
