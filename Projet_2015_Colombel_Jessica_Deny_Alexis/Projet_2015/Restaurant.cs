using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projet_2015
{
    class Restaurant
    {
        [XmlAttribute("NomRestaurant")]
        public string nomRestaurant { get; private set; }
        [XmlElement("Midi")]
        public ServiceMidi midi { get; protected set; } //LISTE
        [XmlElement("Soir")]
        public ServiceSoir soir { get; protected set; } // LISTE
        [XmlElement("NombreMaxClients")]
        public int nbMaxClients { get; private set; }
        [XmlElement("NombreMaxCuisiniers")]
        public int nbMaxCuisiniers { get; private set; }
        [XmlElement("NombreMaxServeurs")]
        public int nbMaxServeurs { get; private set; }
        [XmlElement("RatioCuisiniersClients")]
        public double ratioCuisiniersClients { get; private set; }
        [XmlElement("RatioServeursClients")]
        public double ratioServeursClients { get; private set; }
        [XmlElement("ListeTables")]
        public List<Table> listeTables {get; private set; }

        public Restaurant(string NomRestaurant, ServiceMidi Midi, ServiceSoir Soir, int NbMaxClients, int NbMaxCuisiniers, int NbMaxServeurs, double RatioCuisiniersClients, double RatioServeursClients, List<Table> ListeTables)
        {
            nomRestaurant = NomRestaurant;
            midi = Midi;
            soir = Soir;
            nbMaxClients = NbMaxClients;
            nbMaxCuisiniers = NbMaxCuisiniers;
            nbMaxServeurs = NbMaxServeurs;
            ratioCuisiniersClients = RatioCuisiniersClients;
            ratioServeursClients = RatioServeursClients;
            listeTables = ListeTables;
        }

        // constructeur vide obligatoire pour la sérialisation
        public Restaurant()
        {           
        }

        /*public Restaurant()
        {
            demandeInfo();
        }*/

        public void demandeInfo()
        {
            Console.WriteLine("Combien y a-t-il de places en cuisine ?");
            nomRestaurant = Console.ReadLine();
            Console.WriteLine("Combien y a-t-il de places en cuisine ?");
            gestErreurEntier(nbMaxCuisiniers);
            Console.WriteLine("Combien y a-t-il de places en tant que serveur ?");
            gestErreurEntier(nbMaxServeurs);
            Console.WriteLine("Quel est le ratio Cuisiniers/Clients optimal ?");
            gestErreurDouble(ratioCuisiniersClients);
            Console.WriteLine("Quel est le ratio Serveurs/Clients optimal ?");
            gestErreurDouble(ratioServeursClients);
            Console.WriteLine("Combien y a-t-il de places au bar ?");
            gestErreurEntier(nbMaxClients);
            Console.WriteLine("Combien y a-t-il de tables ?");
            gestErreurEntier(listeTables.Capacity);
            listeTables.Capacity += nbMaxClients;
            for(int i=0; i<listeTables.Capacity; i++)
            {
                for(int j=0; j<nbMaxClients; j++)
                {
                    TableType table = new TableType(this);
                    listeTables.Add(table);
                }

            }
        }

        public override string ToString()
        {
            string ch = "Nom : " + nomRestaurant +
                        "\nNombre de Client : " + nbMaxClients +
                        "\nNombre de Serveur : " + nbMaxServeur +
                        "\nRatio Cuisinier/Client : " + ratioCuisiniersClients +
                        "\nRatio Serveur/Client : " + ratioServeursClients +
                        "\nNombre de table : " + listeTables.Capacity;                     

            return ch; 
            
        }


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

        

        
    }
}
