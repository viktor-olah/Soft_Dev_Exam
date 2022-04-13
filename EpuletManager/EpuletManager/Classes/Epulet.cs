using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EpuletManager.Classes
{

    enum epitesianyag
    {
        tégla,
        panel,
        fa
    }

    abstract class Epulet
    {
        string cim;
        int alapterulet;
        epitesianyag epitesianyagok;
        DateTime munkavégzésKezdete;
        DateTime munkavégzésVége;

        public string Cim
        {
            get => cim;
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    cim = value;
                }
                else
                {
                    throw new ArgumentException("A cím megadása kötelező!");
                }
            }
        }
        public int Alapterulet
        {
            get => alapterulet;
            set
            {
                if (value >= 20)
                {
                    alapterulet = value;
                }
                else
                {
                    throw new ArgumentException("Az alap terület nem lehet kisebb 20nm -nél!");
                }
            }
        }
        public DateTime MunkavégzésKezdete
        {
            get => munkavégzésKezdete;
            set
            {
                if (value >= DateTime.Today.Date)
                {
                    munkavégzésKezdete = value;
                }
                else
                {
                    throw new ArgumentException("A munkakezdés nem lehet korábbi a mai napnál!!");
                }
            }
        }
        public DateTime MunkavégzésVége
        {
            get => munkavégzésVége;
            set
            {
                if (value >= munkavégzésKezdete.Date)
                {
                    munkavégzésVége = value;
                }
                else
                {
                    throw new ArgumentException("A munka végzés vége nem lehet korábban a munka kezdeténél !!");
                }
            }
        }
        internal epitesianyag Epitesianyagok { get => epitesianyagok; private set => epitesianyagok = value; }

        protected Epulet(string cim, int alapterulet, DateTime munkavégzésKezdete, DateTime munkavégzésVége, epitesianyag epitesianyagok)
        {
            Cim = cim;
            Alapterulet = alapterulet;
            MunkavégzésKezdete = munkavégzésKezdete;
            MunkavégzésVége = munkavégzésVége;
            Epitesianyagok = epitesianyagok;
        }


        public abstract double Arkalkulacio();

        public override string ToString()
        {
            return $"{Cim} - {Alapterulet}nm";
        }

        public virtual string CSVFormatum()
        {
            return $"{Cim};{Alapterulet};{Epitesianyagok};{MunkavégzésKezdete.ToString("yyyy MM dd")};{MunkavégzésVége.ToString("yyyy MM dd")};";
        }

        public static void CSVSave(List<Epulet> epuletek)
        {
            FileStream newFile = new FileStream("epuletek.csv", FileMode.Create, FileAccess.Write);
            StreamWriter dataWrite = new StreamWriter(newFile);
            foreach (Epulet item in epuletek)
            {
                dataWrite.WriteLine(item.CSVFormatum());
            }

            dataWrite.Close();
            newFile.Close();
        }

        public static List<Epulet> CSVLoad()
        {
            List<Epulet> load = new List<Epulet>(File.ReadAllLines("epuletek.csv").Length);

            foreach (string item in File.ReadAllLines("epuletek.csv", Encoding.UTF8))
            {

                string[] soradat = item.Split(';');
                if (soradat[0] == "Csaladihaz")
                {
                    //return $"{Cim};{Alapterulet};{Epitesianyagok};{MunkavégzésKezdete};{MunkavégzésVége}";
                    //return "Csaladihaz;" + base.CSVFormatum() + $"{OttelokSzama};{GarazsVanE};{Tetok}";
                    //return "Tombhaz;" + base.CSVFormatum() + $"{LakasokSzama};{FenntartasiTipus};{LiftVanE}";

                    load.Add(new Csaladihaz(soradat[1], int.Parse(soradat[2]), DateTime.Parse(soradat[4]), DateTime.Parse(soradat[5]), (epitesianyag)Enum.Parse(typeof(epitesianyag), soradat[3]), int.Parse(soradat[6]), bool.Parse(soradat[7]), (tetotipusa)Enum.Parse(typeof(tetotipusa), soradat[8])));
                }
                else if (soradat[0] == "Tombhaz")
                {
                    load.Add(new Tombhaz(soradat[1], int.Parse(soradat[2]), DateTime.Parse(soradat[4]), DateTime.Parse(soradat[5]), (epitesianyag)Enum.Parse(typeof(epitesianyag), soradat[3]), int.Parse(soradat[6]), bool.Parse(soradat[8]), (LakasfenntartasTipusa)Enum.Parse(typeof(LakasfenntartasTipusa), soradat[7])));
                }

            }
            return load;
        }

    }
}
