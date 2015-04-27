using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    

    class Program
    {
        public static void gestErreurEntier(int a)
        {
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Veuillez entrer un entier valide.");
                gestErreurEntier(a);
            }
        }

        public static void gestErreurDouble(double a)
        {
            try
            {
                a = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Veuillez entrer un entier valide.");
                gestErreurDouble(a);
            }
        }

        public static enum forme { Rond, Carre, Rectangle, Bar };

        static void Main(string[] args)
        {
        }
    }
}
