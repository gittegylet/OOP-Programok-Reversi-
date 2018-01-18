using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Program
    {
        static void Main(string[] args)
        {

            Tabla ujJatek = new Tabla("allas.txt");

            Console.WriteLine("\n5. feladat: A betöltött tábla\n");

            ujJatek.Megjelenit();


            Console.WriteLine("\n6. feladat: Összegzés");

            ujJatek.Osszegzo('#', 'K', 'F');


            string adatok = "F;4;1;0;1";

            Console.WriteLine("\n8. feladat: [jatekos;sor;oszlop;iranySor;iranyOszlop] = {0}", adatok);

            string[] adatLista = adatok.Split(';');

            bool forditas = ujJatek.VanForditas(adatLista[0][0], int.Parse(adatLista[1]), int.Parse(adatLista[2]), int.Parse(adatLista[3]), int.Parse(adatLista[4]));

            if (forditas) Console.WriteLine("\tVan fordítás!");
            else Console.WriteLine("\tNincs fordítás!");


            adatok = "K;1;3";

            Console.WriteLine("\n9. feladat: [jatekos;sor;oszlop] = {0}", adatok);

            adatLista = adatok.Split(';');

            bool vanForditas = ujJatek.ervenyesLepes(adatLista[0][0], int.Parse(adatLista[1]), int.Parse(adatLista[2]));

            if (vanForditas) Console.WriteLine("\tSzabályos lépés!");
            else Console.WriteLine("\tSzabálytalan lépés!");

            Console.ReadKey();


        }
    }
}
