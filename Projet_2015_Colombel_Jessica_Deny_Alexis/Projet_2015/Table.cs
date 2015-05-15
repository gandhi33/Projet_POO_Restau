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
        protected static int nbTotalTables;
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

        public void ajoutTable()
        {
            Console.WriteLine("Type de table ?");
            Console.WriteLine("0 : bar\n1 : carrée\n2 : rectangulaire\n3 : ronde");
            int frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la forme de table souhaitée s'il vous plait.");
                frappe = Program.gestErreurEntier();
            }
            while (frappe < 0 && frappe > 3);
            Forme FormeTable;
            if (frappe == 0)
            {
                FormeTable = Forme.bar;
                int NbMaxPlaces = 1;
                bool Jumelage = false;
                int NbPlacesSiJumelage = 1;
                Table Table = new Table(restaurant, FormeTable, NbMaxPlaces, Jumelage, NbPlacesSiJumelage);
            }
            else if (frappe >= 1 && frappe <= 2)
            {
                Console.WriteLine("Combien de clients peut contenir cette table ?");
                int NbMaxPlaces = Program.gestErreurEntier();
                Console.WriteLine("Cette table est elle jumelable (0 : Oui / 1 : Non) ?");
                bool Jumelage = Program.gestErreurBool();
                Console.WriteLine("Combien de clients peut contenir cette table une fois jumelée ?");
                int NbPlacesSiJumelage = Program.gestErreurEntier();
                if (frappe == 1)
                {
                    FormeTable = Forme.carree;
                    Table Table = new Table(restaurant, FormeTable, NbMaxPlaces, Jumelage, NbPlacesSiJumelage);
                }
                else
                {
                    FormeTable = Forme.rectangulaire;
                    Table Table = new Table(restaurant, FormeTable, NbMaxPlaces, Jumelage, NbPlacesSiJumelage);
                }
            }
            else
            {
                FormeTable = Forme.ronde;
                Console.WriteLine("Combien de clients peut contenir cette table ?");
                int NbMaxPlaces = Program.gestErreurEntier();
                bool Jumelage = false;
                int NbPlacesSiJumelage = NbMaxPlaces;
                Table Table = new Table(restaurant, FormeTable, NbMaxPlaces, Jumelage, NbPlacesSiJumelage);
            }
        }

        public void enregistrerTable()
        {
            // A faire
        }

        public void supprimerTable()
        {
            // A faire
        }
    }
   
}
