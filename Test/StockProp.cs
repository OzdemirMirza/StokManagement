using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class StockProp
    {
        public string Name { get; set; }
        public string Marka { get; set; }

        public string SipNO { get; set; }

        public string Miktar { get; set; }
        public string Birim { get; set; }
        public string BirimFiyat { get; set; }
        public string ToplamFiyat { get; set; }
        public string Termin { get; set; }
        public string Açıklama { get; set; }

        public StockProp(string iSİM, string marka, string sipNO, string miktar, string birim, string birimFiyat, string toplamFiyat, string termin, string açıklama)
        {
            Name = iSİM;
            Marka = marka;
            SipNO = sipNO;
            Miktar = miktar;
            Birim = birim;
            BirimFiyat = birimFiyat;
            ToplamFiyat = toplamFiyat;
            Termin = termin;
            Açıklama = açıklama;
        }
    }
}
