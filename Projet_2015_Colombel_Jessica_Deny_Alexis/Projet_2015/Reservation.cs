using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Projet_2015
{
    class Reservation
    {
        public Restaurant restaurant { get; private set; }
        public Service service { get; private set; }
        public string nomClient { get; private set; }
        public string numTelephone { get; private set; }
        public DateTime jourResa { get; private set; }
        public DateTime horaireDebutResa { get; private set; }
        public DateTime horaireFinResa { get; private set; }
        public int nbConvives { get; private set; }
        public Formule formuleRetenue { get; private set; }
        public List<Table> tableAffectee { get; private set; }

        public Reservation()
        { }

        public Reservation(string Nom, string Numero, DateTime Jour, DateTime HeureDebut, DateTime HeureFin, int Convive, Formule formule, List<Table> table)
        {
 
        }

        public static int gestErreurEntier(int a)
        {
            try
            {
                a = int.Parse(Console.ReadLine());
                return a;
            }
            catch
            {
                Console.WriteLine("Veuillez entrer un entier valide.");
                gestErreurEntier(a);
                return a;
            }
        }
        public static double gestErreurDouble(double a)
        {
            try
            {
                a = double.Parse(Console.ReadLine());
                return a;
            }
            catch
            {
                Console.WriteLine("Veuillez entrer un entier valide.");
                gestErreurDouble(a);
                return a;
            }
        }
        public void ajoutReservation()
        {
            Console.WriteLine("Nom du Client?");
            nomClient = Console.ReadLine();
            Console.WriteLine("Prénom du Client?");
            nomClient += Console.ReadLine();
            
        }

        public void EnregistrerResa()
        {
            XmlDocument docRestau = new XmlDocument();
            docRestau.Load("docResto.xml");

            XmlElement elem = docRestau.Element("Restaurants").Add(new XElement("Restaurant", new XAttribute("Id", ), 
                new XElement("",), new XElement("",), new XElement("",), new XElement("",)); 
        }

        
        public Service quelService()
        {
                if (horaireDebutResa < restaurant.midi.horaireCloseClients - formuleRetenue.dureeConsommation && horaireDebutResa > restaurant.midi.horaireCloseClients)
                {
                    service = restaurant.midi;
                    return service;
                }
                else
                {
                    service = restaurant.soir;
                    return service;
                }
        }

        public Reservation(Restaurant Restaurant, DateTime JourResa, DateTime HoraireDebutResa, string NomClient, string NumTelephone, int NbConvives, Formule FormuleRetenue)
        {
            restaurant = Restaurant;
            jourResa = JourResa;
            horaireDebutResa = HoraireDebutResa;
            formuleRetenue = FormuleRetenue;
            service = quelService();
            horaireFinResa = horaireDebutResa + formuleRetenue.dureeConsommation;
            nomClient = NomClient;
            numTelephone = NumTelephone;
        }
    }
}
