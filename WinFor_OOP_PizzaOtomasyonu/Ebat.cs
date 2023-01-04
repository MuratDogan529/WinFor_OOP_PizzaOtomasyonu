using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFor_OOP_PizzaOtomasyonu
{
    internal class Ebat
    {
        public string Adi { get; set; }
        public double Carpan { get; set; }
        //control c ve k bas yorum satırına dönsün
        //Form1 de .Adi diyerekte combo boxa yazdırdık.
        public override string ToString()
        {
            return string.Format ("{0}-{1}",Adi,Carpan);
        }
    }
}
