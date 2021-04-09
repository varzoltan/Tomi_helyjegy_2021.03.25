using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tomi_helyjegy_2021._03._25
{
    class Program
    {
        struct Adat
        {
            public int ulesszam;
            public int kmtol;
            public int kmig;
            public int megtett_tavolsag;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[500];
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Downloads\eladott.txt");
            string elsosor = olvas.ReadLine();
            string[] elsosordb = elsosor.Split();
            int max_eladottJegy = int.Parse(elsosordb[0]);
            int max_megtettKm = int.Parse(elsosordb[1]);
            int max_jegyar = int.Parse(elsosordb[2]);
            int n = 0;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] db = sor.Split();
                adatok[n].ulesszam = int.Parse(db[0]);
                adatok[n].kmtol = int.Parse(db[1]);
                adatok[n].kmig = int.Parse(db[2]);
                adatok[n].megtett_tavolsag = int.Parse(db[2]) - int.Parse(db[1]);
                n++;
            }
            olvas.Close();
            Console.WriteLine("1.feladat\nBeolvasás kész!");

            //2.feladat
            Console.WriteLine($"2.Feladat:\n{adatok[n-1].ulesszam} a sorszáma és {adatok[n-1].megtett_tavolsag} km-t tett meg.");

            //3.Feladat
            for (int i =0;i<n;i++)
            {
                if (adatok[i].megtett_tavolsag == max_megtettKm)
                {
                    Console.Write(adatok[i].ulesszam+" ");
                }
            }

            //4
            int szorzat = 0;
            int tavolsag = 0;
            for (int i=0;i<n;i++)
            {
                tavolsag = megtettavolsag(adatok[i].megtett_tavolsag);
                szorzat += ertek(tavolsag * 71);              
            }
            Console.WriteLine("\n4.Feladat:\n" +szorzat+" forint bevétele volt.");

            //5
            int kmtolmax = 0;
            for (int i=0;i<n;i++)
            {
                if (adatok[i].kmtol>kmtolmax)
                {
                    kmtolmax = adatok[i].kmtol;
                }
            }
            int le = 0;
            int fel = 0;
            for (int i =0;i<n;i++)
            {
                if (kmtolmax== adatok[i].kmig)
                {
                    le++;
                }
                if (kmtolmax==adatok[i].kmtol)
                {
                    fel++;
                }
            }
            Console.WriteLine($"5.Feladat:\n{le} ember szállt le és {fel} ember szállt fel.");

            //6
            int[] megallohelyek = new int[n];
            for (int i = 0;i<n;i++)
            {

                int j = 0;
                while (j<=i)
                {
                    if (adatok[i].kmtol == megallohelyek[j])
                    {                       
                        j++;
                    }
                    else
                    {
                        megallohelyek[j] = adatok[i].kmtol; ;
                    }

                    /*if (adatok[i].kmig != megallohelyek[j])
                    {
                        megallohelyek[j] = adatok[i].kmig;
                    }
                    else
                    {
                        j++;
                    }*/
                }
                
            }

            for (int i=0;i<n;i++)
            {
                Console.Write($"{megallohelyek[i]} ");
            }
            Console.ReadKey();
        }

        //függvény a megtett távolság átalakítására
        static int megtettavolsag(int tavolsag)
        {
            int egesz = tavolsag / 10;
            if (tavolsag % 10 > 0)
            {
                return egesz + 1;
            }
            else
            {
                return egesz;
            }
        }
        static int ertek(int fizetendo)
        {
            int maradek = fizetendo % 10;
            if (maradek == 1 || maradek == 2)
            {
                return fizetendo - maradek;
            }
            else if (maradek == 3 || maradek == 4)
            {
                return fizetendo + (5-maradek);
            }
            else if (maradek == 6 || maradek == 7)
            {
                return fizetendo - (maradek - 5);
            }
            else if (maradek == 8 || maradek == 9)
            {
                return fizetendo + (10 - maradek);
            }
            else
            {
                return fizetendo;
            }
           /* if (fizetendo % 10 > 0 && fizetendo % 10 <= 2)
            {

            }
            else if (fizetendo % 10 > = 8 && fizetendo % 10 =< 9)
            {

            }
            else if (fizetendo % 10 > = 3 && fizetendo%10<5)
            {

            }
            else if (fizetendo % 10 > 5 )
            {

            }*/
        }


    }
}
