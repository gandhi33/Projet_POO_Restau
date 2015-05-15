using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projet_2015
{
    private enum Forme {bar, carree, rectangulaire, ronde}

    class Table 
    {
        public Restaurant restaurant { get; protected set; }
        public int numeroTable { get; protected set; }
        public static int nbTotalTables { get; set; }
        public Forme formeTable;
        public int nbMaxPlaces { get; protected set; }
        public bool jumelable { get; protected set; }
        public int nbPlacesSiJumelage { get; protected set; }

        public Table(Restaurant R, Forme FormeTable, int NMP, bool Jum, int NPSJ)
        {
            restaurant = R;
            numeroTable = nbTotalTables + 1;
            nbTotalTables++;
            formeTable = FormeTable;
            nbMaxPlaces = NMP;
            jumelable = Jum;
            nbPlacesSiJumelage = NPSJ;

        }

        public void enregistrerTable()
        {
            
        } // A faire
    }
   
}
