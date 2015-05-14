using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Projet_2015
{
    class Restaurant
    {
        public string nomRestaurant { get; private set; }
        public Service service { get; protected set; }                     // Avoir juste les horaires pour créer des services dans la liste qui suit plus facilement
        public List<Service> listeServices { get; protected set; }
        public int nbMaxClients { get; private set; }
        public int nbMaxCuisiniers { get; private set; }
        public int nbMaxServeurs { get; private set; }
        public double ratioCuisiniersClients { get; private set; }
        public double ratioServeursClients { get; private set; }
        public List<Table> listeTables {get; private set; }
        public List<Formule> listeFormules { get; private set; }

        public Restaurant(string NomRestaurant, Service Service, List<Service> ListeServices, int NbMaxClients, int NbMaxCuisiniers, int NbMaxServeurs, double RatioCuisiniersClients, double RatioServeursClients, List<Table> ListeTables)
        {
            nomRestaurant = NomRestaurant;
            service = Service;
            listeServices = ListeServices;
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

        public Service trouveService(DateTime J)
        {
            int i = 0;
            while (i < listeServices.Count)
                if (listeServices[i].jour == J)
                {
                    return listeServices[i];
                }
            listeServices.Add(new Service(service.horaireOpenEmployesMidi, service.horaireCloseEmployesMidi, service.horaireOpenClientsMidi,
                service.horaireCloseClientsMidi, service.horaireOpenEmployesSoir, service.horaireCloseEmployesSoir, service.horaireOpenClientsSoir,
                service.horaireCloseClientsMidi, J, new List<Reservation>()));
            return listeServices[listeServices.Count - 1];
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
                    //Table table = new Table();
                    //listeTables.Add(table);
                }

            }
        }

        public override string ToString()
        {
            string ch = "Nom : " + nomRestaurant +
                        "\nNombre de Client : " + nbMaxClients +
                        "\nNombre de Serveur : " + nbMaxServeurs +
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

        public void EnregistrerResto()
        {
            // jij
        }

        public void ModifierInformation()
        {
            // kokok
        }

        public void AjoutFormule()
        {
            string Nom;
            TimeSpan Preparation, Consommation, zero;
            bool surPlace;
            zero = new TimeSpan(0, 0, 0);

            Console.WriteLine("Nom de la formule : ");
            Nom = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Durée de préparation : ");
            Preparation = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Duréee de consommation : ");
            Consommation = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (Consommation == zero)
            {
                surPlace = false;
            }
            else
            {
                surPlace = true;
            }

            listeFormules.Add(new Formule(Preparation, Consommation, surPlace));
            
            XDocument docInfo = new XDocument();
            docInfo = XDocument.Load("docInfo.xml");

            docInfo.Element("Formules").Add(new XElement("Formule", new XAttribute("IdFormule", Nom),
                new XElement("DureePreparation", Preparation), new XElement("DureeConsommation", Consommation), new XElement("SurPlace", surPlace)));

        }
        
    }
}
