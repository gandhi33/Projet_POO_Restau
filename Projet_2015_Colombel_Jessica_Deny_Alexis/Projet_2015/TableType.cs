using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projet_2015
{
    class TableType : Table
    {
        /*public forme formeTable { get; private set; }

        public TableType(Restaurant Resto)
        {
            restaurant = Resto;
            numeroTable = restaurant.listeTables.Count + 1;
            nbMaxPlaces = 1;
            //positionCuisine = 0;
            formeTable = forme.Bar;
            //libre = true;
            jumelable = false;
        }

        public TableType(Restaurant Resto, int NbMaxPlaces, int PosCuisine, forme FTable, bool Jumelable)
        {
            restaurant = Resto;
            numeroTable = restaurant.listeTables.Count + 1;
            nbMaxPlaces = NbMaxPlaces;
            //positionCuisine = PosCuisine;
            formeTable = FTable;
            //libre = true;
            jumelable = Jumelable;
            /*if (Jumelable == true)
                tablesJumelables.Add(this);*/
        }
        
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
        }*/
    }
}
