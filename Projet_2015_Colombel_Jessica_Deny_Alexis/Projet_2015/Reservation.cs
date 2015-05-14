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

        public int comptePlaces(List<Table> T)
        {
            if (T.Count == 1)
                return T[0].nbMaxPlaces;
            else
            {
                int i = 0, a = 0;
                while (i<T.Count)
                {
                    a += T[i].nbPlacesSiJumelage;
                    i++;
                }
                return a;
            }
        }

        public int chercheNumTable(List<Table> T, int n)
        {
            if (T.Count == 1)
            {
                    return T[0].numeroTable;
            }
            else
            {
                for (int i = 0; i < T.Count; i++)
                {
                    if (T[i].numeroTable == n)
                        return T[i].numeroTable;
                }
                return T[0].numeroTable;
            }
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
            docRestau.Load("docRestau.xml");

            docRestau.Element("Reservations").Add(new XElement("Reservation", new XAttribute("IdReservation", nomClient), 
                new XElement("NumTelephone",numTelephone), new XElement("JourResa",jourResa), new XElement("HoraireDebut",horaireDebutResa), new XElement("",))); 

            // Finir
        }

        public void ModifierResa()
        {
            // lalala
        }

        public List<Table> trouveTables(Restaurant R, int NbC, Service S, DateTime HDR, DateTime HFR)
        {

            List<Table> res = new List<Table>(); // Tables qui seront affectées
            List<Table> tablesBonNombrePlaces = new List<Table>(); // Tables qui ont le bon nombre de places
            
            // Rempli la liste des tables au bon nombre de place.
            for (int i = 0; i < R.listeTables.Count; i++)
            {
                if (NbC == R.listeTables[i].nbMaxPlaces)
                {
                    tablesBonNombrePlaces.Add(R.listeTables[i]);
                }
            }

            // Retire les tables qui sont déjà prise pour le service dans le tableau

            for (int j = 0; j < S.reservations.Count; j++)
            {
                for(int i = 0; i < tablesBonNombrePlaces.Count; i++)
                {
                    if (tablesBonNombrePlaces[i].numeroTable == chercheNumTable(S.reservations[j].tableAffectee, NbC))
                    {
                        if ((S.reservations[j].horaireDebutResa < HDR && S.reservations[j].horaireFinResa > HDR)
                            || (S.reservations[j].horaireDebutResa < HFR && S.reservations[j].horaireFinResa > HFR)
                            || (S.reservations[j].horaireDebutResa > HDR && S.reservations[j].horaireFinResa < HFR))
                        {
                            tablesBonNombrePlaces.RemoveAt(i);
                        }
                        
                    }
                }
            }
            // Affecte la première table de la liste des tables disponibles au bon nombre
            if (tablesBonNombrePlaces.Count != 0)
            {
                res.Add(tablesBonNombrePlaces[0]);
                return res;
            }

            // Si pas de tables dispo au bon nombre
            // Tables de capacité inférieur et que l'on peut jumeler

            List<Table> tablesNombreInf = new List<Table>();
            for (int i = 0; i < R.listeTables.Count; i++)
            {
                if (NbC > R.listeTables[i].nbMaxPlaces && R.listeTables[i].jumelable == true)
                {
                    tablesNombreInf.Add(R.listeTables[i]);
                }
            }
            for (int j = 0; j < S.reservations.Count; j++)
            {
                for (int i = 0; i < tablesNombreInf.Count; i++)
                {
                    if (tablesNombreInf[i].numeroTable == chercheNumTable(S.reservations[j].tableAffectee, NbC))
                    {
                        if ((S.reservations[j].horaireDebutResa < HDR && S.reservations[j].horaireFinResa > HDR)
                            || (S.reservations[j].horaireDebutResa < HFR && S.reservations[j].horaireFinResa > HFR)
                            || (S.reservations[j].horaireDebutResa > HDR && S.reservations[j].horaireFinResa < HFR))
                        {
                            tablesNombreInf.RemoveAt(i);
                        }
                        /*else
                        {
                            res.Add(tablesNombreInf[i]);
                            if (comptePlaces(res) >= NbC)
                            {
                                return res;
                            }
                        }*/
                    }
                }
            }
            while (comptePlaces(res) < NbC && tablesNombreInf.Count != 0)
            {
                    res.Add(tablesBonNombrePlaces[0]);
                    tablesNombreInf.RemoveAt(0);
            }
            if (comptePlaces(res) >= NbC)
            {
                return res;
            }
            res.Clear();

            // Si pas de jumelage possible, on peut prendre des tables plus grandes 

            List<Table> tablesNombreSup = new List<Table>();
            for (int i = 0; i < R.listeTables.Count; i++)
            {
                if (NbC < R.listeTables[i].nbMaxPlaces)
                {
                    tablesNombreSup.Add(R.listeTables[i]);
                }
            }
            if (tablesNombreSup.Count == 0)
                return res;
            int a = tablesNombreSup[0].nbMaxPlaces;
            Table b = tablesNombreSup[0];
            for (int i = 1; i < tablesNombreSup.Count; i++)
            {
                if (tablesNombreSup[i].nbMaxPlaces < a)
                {
                    a = tablesNombreSup[0].nbMaxPlaces;
                    b = tablesNombreSup[i];
                }
            }
            res.Add(b);
            return res;
        }    

        public Reservation(Restaurant Restaurant, DateTime JourResa, DateTime HoraireDebutResa, string NomClient,
            string NumTelephone, int NbConvives, Formule FormuleRetenue)
        {
            restaurant = Restaurant;
            jourResa = JourResa;
            horaireDebutResa = HoraireDebutResa;
            formuleRetenue = FormuleRetenue;
            DateTime HoraireFinResa = horaireDebutResa + formuleRetenue.dureeConsommation;
            horaireFinResa = HoraireFinResa;
            nbConvives = NbConvives;
            nomClient = NomClient;
            numTelephone = NumTelephone;
            Service Service = Restaurant.trouveService(JourResa);
            service = Service;
            try
            {
                tableAffectee = trouveTables(Restaurant, NbConvives, Service, HoraireDebutResa, HoraireFinResa);
            }
            catch
            {
                Console.WriteLine("La réservation est impossible, aucune table disponible pour ce nombre de convives !");
                // Je veux sortir du constructeur sans créer la réservation... Comment faire ??
                // Tu peux créer la réservation et ne pas l'enregistrer dans le XML.
                // De toute façon, puisqu'aucune table n'a été réservé, ça ne pose pas de problème.
            }
        }
    }
}
