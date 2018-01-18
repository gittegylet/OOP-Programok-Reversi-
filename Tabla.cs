using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Reversi
{
    class Tabla
    {

        char[,] t;

        StreamReader sr;

        public Tabla(string bemenetiFajl)
        {

            t = new char[8, 8];
            sr = new StreamReader(bemenetiFajl);

            int i = 0;

            while(!sr.EndOfStream)
            {
                char[] sor = sr.ReadLine().ToCharArray();

                for(int j = 0; j < sor.Length; j++)
                {

                    t[i, j] = sor[j];

                }
                i++;

            }
                  
        }

        public void Megjelenit()
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    Console.Write(t[i, j]);

                }

                Console.WriteLine();

            }

        }


        public void Osszegzo(char uresMezo, char jatekos1, char jatekos2)
        {

            int uresDb = 0;
            int x1Db = 0;
            int x2Db = 0;
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (t[i, j] == jatekos1) x1Db++;
                    else if (t[i, j] == jatekos2) x2Db++;
                    else if (t[i, j] == uresMezo) uresDb++;

                }
               
            }

            Console.WriteLine("\t1-es játékos korongjainak száma: " + x1Db);
            Console.WriteLine("\t2-es játékos korongjainak száma: " + x2Db);
            Console.WriteLine("\tÜres mezők száma: " + uresDb);

        }


        public bool VanForditas(char jatekos, int sor, int oszlop, int iranySor, int iranyOszlop)
        {

            int aktSor, aktOszlop;
            char ellenfel;
            bool nincsEllenfel;

            aktSor = sor + iranySor;
            aktOszlop = oszlop + iranyOszlop;
            ellenfel = 'K';

            if (jatekos == 'K') ellenfel = 'F';

            nincsEllenfel = true;

            while (aktSor >= 0 && aktSor < 8 && aktOszlop >= 0 && aktOszlop < 8 && t[aktSor, aktOszlop] == ellenfel)
            {
                aktSor = aktSor + iranySor;
                aktOszlop = aktOszlop + iranyOszlop;
                nincsEllenfel = false;

            }

            //if (aktSor >= 0 && aktSor <= 7 && aktOszlop >= 0 && aktOszlop <= 7) Console.WriteLine(t[aktSor, aktOszlop].ToString() + " " + aktSor + " " + aktOszlop);
            //else Console.WriteLine("Sor + Oszlop => " + aktSor + " " + aktOszlop);

            if (nincsEllenfel || aktSor < 0 || aktSor > 7 || aktOszlop < 0 || aktOszlop > 7 || t[aktSor, aktOszlop] != jatekos) return false;

            return true;
           
        }


        public bool ervenyesLepes(char jatekos, int sor, int oszlop)
        {

            if (t[sor, oszlop] == '#')
            {

                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {

                        if ((x != 0 || y != 0) && VanForditas(jatekos, sor + x, oszlop + y, x, y)) return true;

                    }

                }

            }

            return false;

        }


    }

}