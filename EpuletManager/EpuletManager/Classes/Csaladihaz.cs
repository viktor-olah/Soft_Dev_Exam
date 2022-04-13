using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpuletManager.Classes
{
    enum tetotipusa
    {
        cserép,
        zsindely,
        nád
    }

    internal class Csaladihaz : Epulet
    {
        int ottelokSzama;
        bool garazsVanE;
        tetotipusa tetok;

        public Csaladihaz(string cim, int alapterulet, DateTime munkavégzésKezdete, DateTime munkavégzésVége, epitesianyag epitesianyagok, int ottelokSzama, bool garazsVanE, tetotipusa tetok) : base(cim, alapterulet, munkavégzésKezdete, munkavégzésVége, epitesianyagok)
        {
            OttelokSzama = ottelokSzama;
            GarazsVanE = garazsVanE;
            Tetok = tetok;
        }

        public int OttelokSzama
        {
            get => ottelokSzama;
            set
            {
                if (value >= 1 )
                {
                    ottelokSzama = value;
                }
                else
                {
                    throw new ArgumentException("A lakók száma nem lehet kevesebb mint 1 !!");
                }
            }
        }
        public bool GarazsVanE { get => garazsVanE; set => garazsVanE = value; }
        internal tetotipusa Tetok { get => tetok; set => tetok = value; }


        public override double Arkalkulacio()
        {
            return Alapterulet * OttelokSzama * 10000;
        }

        public override string CSVFormatum()
        {
            return "Csaladihaz;" + base.CSVFormatum() + $"{OttelokSzama};{GarazsVanE};{Tetok}";
        }
    }
}
