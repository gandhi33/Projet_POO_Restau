using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class TableType : Table
    {
        public forme formeTable { get; private set; }
        public bool jumelable { get; private set; } // private IAssemblage jumelable

        public TableType(Restaurant Resto)
        {
            restaurant = Resto;
            numeroTable = restaurant.listeTables.Count + 1;
            nbMaxPlaces = 1;
            positionCuisine = 0;
            formeTable = forme.Bar;
            jumelable = false;
        }

        public TableType(Restaurant Resto, int NbMaxPlaces, int PosCuisine, forme FTable, bool Jumelable)
        {
            restaurant = Resto;
            numeroTable = restaurant.listeTables.Count + 1;
            nbMaxPlaces = NbMaxPlaces;
            positionCuisine = PosCuisine;
            formeTable = FTable;
            jumelable = Jumelable;
            if (Jumelable == true)
                tablesJumelables.Add(this);
        }
        
        public void ajouteTable()
        {
            int a;
            Console.WriteLine("Combien de places peut contenir cette table ?");
            gestErreurEntier(a);

        }
    }
}
