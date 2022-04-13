using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpuletManager.Classes
{
    enum LakasfenntartasTipusa
    {
        egyéni,
        szövetkezet,
        társasház
    }
    internal class Tombhaz : Epulet
    {
        int lakasokSzama;
        LakasfenntartasTipusa fenntartasiTipus;
        bool liftVanE;

        public Tombhaz(string cim, int alapterulet, DateTime munkavégzésKezdete, DateTime munkavégzésVége, epitesianyag epitesianyagok, int lakasokSzama, bool liftVanE, LakasfenntartasTipusa fenntartasiTipus) : base(cim, alapterulet, munkavégzésKezdete, munkavégzésVége, epitesianyagok)
        {
            LakasokSzama = lakasokSzama;
            LiftVanE = liftVanE;
            FenntartasiTipus = fenntartasiTipus;
        }

        public int LakasokSzama
        {
            get => lakasokSzama;
            private set
            {
                if (value >= 1)
                {
                    lakasokSzama = value;
                }
                else
                {
                    throw new ArgumentException("A lakások száma nem lehet kevesebb egynél !!");
                }
            }
        }
        public bool LiftVanE { get => liftVanE; private set => liftVanE = value; }
        internal LakasfenntartasTipusa FenntartasiTipus { get => fenntartasiTipus; set => fenntartasiTipus = value; }

        public override double Arkalkulacio()
        {
            return Alapterulet * LakasokSzama * 8000 + (LiftVanE ? 0 : 100000);
        }
        public override string CSVFormatum()
        {
            return "Tombhaz;" + base.CSVFormatum() + $"{LakasokSzama};{FenntartasiTipus};{LiftVanE}";
        }
    }
}
