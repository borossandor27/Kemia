using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kemia
{
    class Program
    {
        static List<Elem> elemek = new List<Elem>();
        static void Main(string[] args)
        {
            Beolvas("felfedezesek.csv");
            Console.WriteLine($"\n3. feladat: Elemek száma: {elemek.Count}");
            Console.WriteLine($"\n4. feladat: Elemek száma: {elemek.FindAll(a => a.Evszam.Equals("Ókor")).Count}");
            string jel = Vegyjel();
            Elem keresett = elemek.Find(a => a.Vegyjel.ToLower() == jel);
            Console.WriteLine("\n6. feladat: Keresés");
            Console.WriteLine($"\tAz elem vegyjele: {keresett.Vegyjel}");
            Console.WriteLine($"\tAz elem neve: {keresett.Nev}");
            Console.WriteLine($"\tRendszáma: {keresett.Rendszam}");
            Console.WriteLine($"\tFelfedezés éve: {keresett.Evszam}");
            Console.WriteLine($"\tFelfedező: {keresett.Felfedezo}");

            string[] ev = elemek.FindAll(a => !a.Evszam.Equals("Ókor")).Select(b => b.Evszam).ToArray();
            int max = 0;
            for (int i = 0; i < ev.Length-1; i++)
            {
                if (int.Parse(ev[i+1])-int.Parse(ev[i]) > max )
                {
                    max = int.Parse(ev[i + 1]) - int.Parse(ev[i]);
                }
            }
            Console.WriteLine($"\n7. feladat: {max} év volt a leghosszabb időszak két elem felfedezése között.");
            Console.WriteLine("\n8 feladat: Statisztika");

            foreach (var item in elemek.FindAll(a => !a.Evszam.Equals("Ókor")).GroupBy(b => b.Evszam).Select(c => new { ev = c.Key, db = c.Count() }).Where(d => d.db > 3))
            {
                Console.WriteLine($"\t{item.ev}: { item.db} db");
            }
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }

        static void Beolvas(string forras)
        {
            try
            {
                using (StreamReader sr = new StreamReader(forras, Encoding.Default))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string[] sor = sr.ReadLine().Split(';');
                        elemek.Add(new Elem(sor[0], sor[1], sor[2], int.Parse(sor[3]), sor[4]));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message+"\nA program leáll!");
                Environment.Exit(0);
            }
        }

        static string Vegyjel()
        {
            List<char> abc = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            bool igen = true;
            string jel = "";
            do
            {
                igen = true;
                Console.Write("5. feladat: kérek egy vegyjelet: ");
                jel = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(jel) || jel.Length > 2)
                {
                    igen = false;
                    continue;
                }
                for (int i = 0; i < jel.Length; i++)
                {
                    if (!abc.Contains(jel[i]) )
                    {
                        igen = false;
                        continue;
                    } 
                }
            } while (!igen);
            return jel;
        }
    }
}
