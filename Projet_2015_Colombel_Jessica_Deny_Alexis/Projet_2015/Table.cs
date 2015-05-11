using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projet_2015
{
    
    class Table 
    {
        public Restaurant restaurant { get; protected set; }
        public int numeroTable { get; protected set; }
        public int nbMaxPlaces { get; protected set; }
        //abstract public int presVitrine { get; protected set; }
        public bool jumelable { get; protected set; }

        public void ajouteTable()
        {
            int a;
            Console.WriteLine("Combien de places peut contenir cette table ?");
            gestErreurEntier(out a);

        }

        public static void gestErreurEntier(out int a)
        {
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Veuillez entrer un entier valide.");
                gestErreurEntier(out a);
            }
        }
        public static void gestErreurDouble(out double a)
        {
            try
            {
                a = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Veuillez entrer un entier valide.");
                gestErreurDouble(out a);
            }
        }
    }
   
}
