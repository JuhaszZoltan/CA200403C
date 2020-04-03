using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CA200403C
{
    class Program
    {
        static List<Pontszerzo> pontszerzok;
        static void Main(string[] args)
        {
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            F08();
            Console.ReadKey();
        }

        private static void F05()
        {
            var sum = pontszerzok.Sum(x => x.OlimpiaiPont);
            Console.WriteLine($"F5: {sum}");
        }

        private static void F08()
        {
            var r = pontszerzok
                .OrderByDescending(x => x.SportolokSzama)
                .ToList()
                .First();

            Console.WriteLine($"F8: {r.Helyezes} {r.SportolokSzama} {r.Sportag} {r.Versenyszam}");
        }

        private static void F07()
        {
            var sw = new StreamWriter(@"..\..\Res\helsinki2.txt");

            pontszerzok.ForEach(x => sw.WriteLine(
                $"{x.Helyezes} {x.SportolokSzama} {x.OlimpiaiPont} " +
                $"{(x.Sportag == "kajakkenu" ? "kajak-kenu" : x.Sportag)} {x.Versenyszam}"));

            sw.Close();
        }

        private static void F06()
        {
            var r = pontszerzok
                .Where(x => x.Sportag == "uszas" || x.Sportag == "torna")
                .GroupBy(x => x.Sportag)
                .OrderBy(x => x.Count())
                .ToDictionary(x => x.Key, x => x.Count());

            Console.WriteLine($"F6: {(r["torna"] == r["uszas"] ? "egyenlo" : r.Last().Key)}");
        }

        private static void F04()
        {
            var r = pontszerzok.GroupBy(x => x.Helyezes)
                .ToDictionary(x => x.Key, x => x.Count());

            Console.WriteLine($"F4: a:{r[1]} - e:{r[2]} - b:{r[3]}");
        }

        private static void F03()
        {
            Console.WriteLine($"F3: {pontszerzok.Count}");
        }

        private static void F02()
        {
            pontszerzok = new List<Pontszerzo>();
            var sr = new StreamReader(@"..\..\Res\helsinki.txt", Encoding.Default);
            while (!sr.EndOfStream)
            {
                pontszerzok.Add(new Pontszerzo(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
