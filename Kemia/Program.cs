using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

            string vegyjel = "";
            //Regex reg = new Regex(@"^[a-zA-Z'.]{1,2}$");
            do
            {
                Console.Write("5. feladat: kérek egy vegyjelet: ");
                vegyjel = Console.ReadLine();
            } while (!Regex.IsMatch(vegyjel,
                               @"^['a-zA-Z'.]{1,2}$"));


            Elem keresett = elemek.Find(a => a.Vegyjel.ToLower() == vegyjel);
            Console.WriteLine("\n6. feladat: Keresés");
            Console.WriteLine($"\tAz elem vegyjele: {keresett.Vegyjel}");
            Console.WriteLine($"\tAz elem neve: {keresett.Nev}");
            Console.WriteLine($"\tRendszáma: {keresett.Rendszam}");
            Console.WriteLine($"\tFelfedezés éve: {keresett.Evszam}");
            Console.WriteLine($"\tFelfedező: {keresett.Felfedezo}");

            int[] evek = elemek.FindAll(a => !a.Evszam.Equals("Ókor")).Select(b => int.Parse(b.Evszam)).ToArray();
            int max = evek.Skip(1).Zip(evek, (second, first) => new { a = first, b = second }).Max(c => Math.Abs(c.a - c.b));
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

    }
}
