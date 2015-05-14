using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projet_2015
{
    private enum Forme { bar, carree, rectangulaire, ronde}

    class Table 
    {
        public Restaurant restaurant { get; protected set; }
        public int numeroTable { get; protected set; }
        protected static int nbTotalTables;
        public int nbMaxPlaces { get; protected set; }
        //abstract public bool presVitrine { get; protected set; }
        public bool jumelable { get; protected set; }
        public int nbPlacesSiJumelage { get; protected set; }

        public Table(Restaurant R, int NMP, bool Jum, int NPSJ)
        {
            restaurant = R;
            numeroTable = nbTotalTables + 1;
            nbTotalTables++;
            nbMaxPlaces = NMP;
            //presVitrine = PV;
            jumelable = Jum;
            nbPlacesSiJumelage = NPSJ;

        }

        public void ajouteTable()
        {
            int a;
            Console.WriteLine("Combien de places peut contenir cette table ?");
            gestErreurEntier(out a);
            // Non fini

        }

        public void enregistrerTable()
        {
            // A faire
        }

        public void supprimerTable()
        {
            // A faire
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
