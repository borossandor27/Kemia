using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemia
{
    class Elem
    {
        readonly string evszam;
        string nev;
        string vegyjel;
        int rendszam;
        readonly string felfedezo;

        public string Evszam => evszam;

        public string Nev { get => nev; set => nev = value; }
        public string Vegyjel { get => vegyjel; set => vegyjel = value; }
        public int Rendszam { get => rendszam; set => rendszam = value; }

        public string Felfedezo => felfedezo;

        public Elem(string evszam, string nev, string vegyjel, int rendszam, string felfedezo)
        {
            this.evszam = evszam;
            this.Nev = nev;
            this.Vegyjel = vegyjel;
            this.Rendszam = rendszam;
            this.felfedezo = felfedezo;
        }
    }
}
