using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200403C
{
    class Pontszerzo
    {
        public int Helyezes { get; set; }
        public int SportolokSzama { get; set; }
        public string Sportag { get; set; }
        public string Versenyszam { get; set; }
        public int OlimpiaiPont => Helyezes == 1 ? 7 : (7 - Helyezes);
        public Pontszerzo(string s)
        {
            var t = s.Split(' ');

            Helyezes = int.Parse(t[0]);
            SportolokSzama = int.Parse(t[1]);
            Sportag = t[2];
            Versenyszam = t[3];
        }
    }
}
