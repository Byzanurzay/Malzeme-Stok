using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeStok
{
    internal class Malzemeler
    {
        public class Malzeme
        {
            public string MalzemeKodu { get; set; }
            public string MalzemeAdi { get; set; }
            public int YillikSatis { get; set; }
            public decimal BirimFiyat { get; set; }
            public int MinStok { get; set; }
            public int TeminSuresi { get; set; }
         }
  }
}