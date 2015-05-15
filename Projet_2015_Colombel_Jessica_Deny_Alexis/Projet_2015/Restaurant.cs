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
        public List<ServiceParJour> listeServicesParJour{ get; protected set; }
        public int nbMaxClients { get; private set; }
        public int nbMaxCuisiniers { get; private set; }
        public int nbMaxServeurs { get; private set; }
        public double ratioCuisiniersClients { get; private set; }
        public double ratioServeursClients { get; private set; }
        public List<Table> listeTables {get; private set; }
        public List<Formule> listeFormules { get; private set; }

        public Restaurant(string NomRestaurant, List<ServiceParJour> ListeServicesParJour,
            int NbMaxClients, int NbMaxCuisiniers, int NbMaxServeurs, double RatioCuisiniersClients,
            double RatioServeursClients, List<Table> ListeTables, List<Formule> ListeFormules)
        {
            nomRestaurant = NomRestaurant;
            listeServicesParJour = ListeServicesParJour;
            nbMaxClients = NbMaxClients;
            nbMaxCuisiniers = NbMaxCuisiniers;
            nbMaxServeurs = NbMaxServeurs;
            ratioCuisiniersClients = RatioCuisiniersClients;
            ratioServeursClients = RatioServeursClients;
            listeTables = ListeTables;
            listeFormules = ListeFormules; 
        }

        public Restaurant()
        {            
        }

        
        public ServiceParJour trouveService(DateTime J)
        {
            int i = 0;
            while (i < listeServicesParJour.Count)
                if (listeServicesParJour[i].jour == J)
                {
                    return listeServicesParJour[i];
                }
            
            listeServicesParJour.Add(new ServiceParJour(service.horaireOpenEmployesMidi, service.horaireCloseEmployesMidi,
                service.horaireOpenClientsMidi, service.horaireCloseClientsMidi, service.horaireOpenEmployesSoir,
                service.horaireCloseEmployesSoir, service.horaireOpenClientsSoir, service.horaireCloseClientsMidi,
                J, new List<Reservation>()));
            return listeServicesParJour[listeServicesParJour.Count - 1];
        }

        // Demande des informations nécessaires à la création d'une nouvelle réservation.
        public void ajoutReservation()
        {
            Reservation a;
            Console.WriteLine("Nom du Client ?");
            string NomClient = Console.ReadLine();
            Console.WriteLine("Prénom du Client ?");
            NomClient += " " + Console.ReadLine();
            Console.WriteLine("Date de Réservation (yyyy,mm,dd) ?");
            DateTime JourResa = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Heure de réservation (hh,mm,ss) ?");
            DateTime HDR = DateTime.Parse(Console.ReadLine());
            ServiceParJour Service = trouveService(JourResa);
            Console.WriteLine("Nombre de convives ?");
            int NbConvives = Program.gestErreurEntier();
            // Récupération des différentes formules du restaurant
            Console.WriteLine("Quelle Formule (entrez le numéro) ?");
            for (int i = 0; i < listeFormules.Count; i++)
            {
                Console.WriteLine("" + i + " : " + listeFormules[i]);
            }
            int frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la formule souhaitée s'il vous plait.");
                frappe = Program.gestErreurEntier();
            }
            while (frappe < 0 && frappe > (listeFormules.Count - 1));
            Formule FormRet = listeFormules[frappe];
            DateTime HFR = HDR + FormRet.dureeConsommation;
            List<Table> TableAffectee = new List<Table>();
            string NumTel;
            // Si la réservation concerne une commande à emporter, pas besoin de table.
            if (FormRet.surPlace == false)
            {
                NumTel = Console.ReadLine();
                a = new Reservation(this, Service, NomClient, NumTel, JourResa, HDR, HFR, NbConvives, FormRet, TableAffectee);
            }
            else
            {
                // Tente de trouver une table adéquate en jumelant ou non, sinon refus de la réservation.
                try
                {
                    TableAffectee = Service.reservations[0].trouveTables(this, NbConvives, Service, HDR, HFR);
                }
                catch
                {
                    // Reconduction quand la réservation est refusée.
                    Console.WriteLine("La réservation est impossible, aucune table disponible pour ce nombre de convives !");
                    Console.WriteLine("0 : Annulez ?");
                    Console.WriteLine("1 : Autre réservation ?");
                    string frappe2;
                    do
                    {
                        Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                        frappe2 = Console.ReadLine();
                    }
                    while (frappe2 != "0" && frappe2 != "1");
                    int choix = int.Parse(frappe2);
                    switch (choix)
                    {
                        case 0:
                            Program.GererReservation(this);
                            break;
                        case 1:
                            ajoutReservation();
                            break;
                    }
                }
            }
            Console.WriteLine("Numéro de téléphone ?");
            NumTel = Console.ReadLine();
            // Si tout est bon, création de la réservation
            a = new Reservation(this, Service, NomClient, NumTel, JourResa, HDR, HFR, NbConvives, FormRet, TableAffectee);
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
                Table Table = new Table(this, FormeTable, NbMaxPlaces, Jumelage, NbPlacesSiJumelage);
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
                    Table Table = new Table(this, FormeTable, NbMaxPlaces, Jumelage, NbPlacesSiJumelage);
                }
                else
                {
                    FormeTable = Forme.rectangulaire;
                    Table Table = new Table(this, FormeTable, NbMaxPlaces, Jumelage, NbPlacesSiJumelage);
                }
            }
            else
            {
                FormeTable = Forme.ronde;
                Console.WriteLine("Combien de clients peut contenir cette table ?");
                int NbMaxPlaces = Program.gestErreurEntier();
                bool Jumelage = false;
                int NbPlacesSiJumelage = NbMaxPlaces;
                Table Table = new Table(this, FormeTable, NbMaxPlaces, Jumelage, NbPlacesSiJumelage);
            }
        }

        public void retireTable()
        {
            Console.WriteLine("Vérifiez que la table n'est pas réservée pour un service à venir (0 : Non / 1 : Oui) ?");
            bool a = Program.gestErreurBool();
            if (a == true)
            {
                modifReservation();
                Program.retourGesResas(this);
            }

            Console.WriteLine("Quel est le numéro de la table à retirer ?");
            int NumTable = Program.gestErreurEntier();
            do
            {
                Console.WriteLine("Veuillez entrer un numéro de table existant.");
                NumTable = Program.gestErreurEntier();
            }
            while (NumTable > listeTables.Count || NumTable == 0);
            listeTables.RemoveAt(NumTable - 1);
            Table.nbTotalTables--;
            Console.WriteLine("Table retirée !");
        }

        public void modifNomRestaurant()
        {
            Console.WriteLine("Quel est le nouveau du restaurant ?");
            nomRestaurant = Console.ReadLine();
            Console.WriteLine("Le nom du restaurant est désormais \"{0}\" !", nomRestaurant);
        }

        public void modifNbMaxCuisiniers()
        {
            Console.WriteLine("Quel est le nouveau nombre maximal de cuisiniers ?");
            nbMaxCuisiniers = Program.gestErreurEntier();
            Console.WriteLine("Ce nombre maximal est désormais de {0} !", nbMaxCuisiniers);
        }

        public void modifNbMaxServeurs()
        {
            Console.WriteLine("Quel est le nouveau nombre maximal de serveurs ?");
            nbMaxServeurs = Program.gestErreurEntier();
            Console.WriteLine("Ce nombre maximal est désormais de {0} !", nbMaxServeurs);
        }

        public void modifNbMaxClients()
        {
            Console.WriteLine("Quel est le nouveau nombre maximal de clients ?");
            nbMaxClients = Program.gestErreurEntier();
            Console.WriteLine("Ce nombre maximal est désormais de {0} !", nbMaxClients);
        }

        public void modifRatioCuisinierClient()
        {
            Console.WriteLine("Quel est le nouveau ratio cuisinier/client ?");
            ratioCuisiniersClients = Program.gestErreurDouble();
            Console.WriteLine("Ce ratio est désormais de {0} !", ratioCuisiniersClients);
        }

        public void modifRatioServeurClient()
        {
            Console.WriteLine("Quel est le nouveau ratio cuisinier/client ?");
            ratioServeursClients = Program.gestErreurDouble();
            Console.WriteLine("Ce ratio est désormais de {0} !", ratioServeursClients);
        }

        public void modifReservation()
        {
            Console.WriteLine("Quel est la date de cette réservation ?");
            DateTime Date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Quel est le nom du client ?");
            string nom = Console.ReadLine();
            Console.WriteLine("Quel est le prénom du client ?");
            nom += " " + Console.ReadLine();
            ServiceParJour Service = trouveService(Date);
            int rang;
            Reservation Reservation = trouveReservation(Service, nom, out rang);
            if (Reservation == null)
            {
                Console.WriteLine("0 : Retourner au menu de gestion des réservations ?");
                Console.WriteLine("1 : Recommencer la modification de réservation ?");
                int frappe;
                do
                {
                    Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                    frappe = Program.gestErreurEntier();
                }
                while (frappe < 0 && frappe > 1);
                switch(frappe)
                {
                    case 0:
                        Program.GererReservation(this);
                        break;
                    case 1:
                        modifReservation();
                        break;
                }
            }
            else
            {
                Service.reservations.RemoveAt(rang);
                Console.WriteLine("Début de la modification :");
                ajoutReservation();

                /*Console.WriteLine("+----------------------------------------------------------------------------+");
                Console.WriteLine("|                              QUE MODIFIER ?                                |");
                Console.WriteLine("+-----------+----------------------------------------------------------------+");
                Console.WriteLine("|  TAPEZ 1  | Le jour ?                                                      |");
                Console.WriteLine("+-----------+----------------------------------------------------------------+");
                Console.WriteLine("|  TAPEZ 2  | L'horaire ?                                                    |");
                Console.WriteLine("+-----------+----------------------------------------------------------------+");
                Console.WriteLine("|  TAPEZ 3  | La formule ?                                                   |");
                Console.WriteLine("+-----------+----------------------------------------------------------------+");
                Console.WriteLine("|  TAPEZ 4  | Le nombre de convives ?                                        |");
                Console.WriteLine("+-----------+----------------------------------------------------------------+");
                Console.WriteLine("|  Tapez 0  | Retourner au menu de gestion des réservations                  |");
                Console.WriteLine("+-----------+----------------------------------------------------------------+");

                int frappe;
                do
                {
                    Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                    frappe = Program.gestErreurEntier(int.Parse(Console.ReadLine()));
                }
                while (frappe < 0 && frappe > 6);
                switch(frappe)
                {
                    case 0:
                        Program.GererReservation(this);
                        break;
                    case 1:
                        Console.WriteLine("Quel jour ");
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }*/
            }
        }

        public void annulReservation()
        {
            Console.WriteLine("Quel est la date de cette réservation ?");
            DateTime Date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Quel est le nom du client ?");
            string nom = Console.ReadLine();
            Console.WriteLine("Quel est le prénom du client ?");
            nom += " " + Console.ReadLine();
            ServiceParJour Service = trouveService(Date);
            int rang;
            Reservation Reservation = trouveReservation(Service, nom, out rang);
            if (Reservation == null)
            {
                Console.WriteLine("0 : Retourner au menu de gestion des réservations ?");
                Console.WriteLine("1 : Recommencer la modification de réservation ?");
                int frappe;
                do
                {
                    Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                    frappe = Program.gestErreurEntier();
                }
                while (frappe < 0 && frappe > 1);
                switch (frappe)
                {
                    case 0:
                        Program.GererReservation(this);
                        break;
                    case 1:
                        modifReservation();
                        break;
                }
            }
            else 
            {
                Service.reservations.RemoveAt(rang);
                Console.WriteLine("Réservation annulée !");
            }
        }

        public Reservation trouveReservation(ServiceParJour Service, string NomClient, out int rangResa)
        {
            for (int i = 0; i < Service.reservations.Count; i++)
            {
                if (Service.reservations[i].nomClient == NomClient)
                {
                    rangResa = i;
                    return Service.reservations[i];
                }
            }
            Console.WriteLine("Ce client n'a pas réservé ce jour là ou est mal enregistré !");
            rangResa = -1;
            return null;
        }

        public void demandeInfo()
        {
            Console.WriteLine("Combien y a-t-il de places en cuisine ?");
            string NomRestaurant = Console.ReadLine();
            Console.WriteLine("Combien y a-t-il de places en cuisine ?");
            int NbMaxCuisiniers = Program.gestErreurEntier();
            Console.WriteLine("Combien y a-t-il de places en tant que serveur ?");
            int NbMaxServeurs = Program.gestErreurEntier();
            Console.WriteLine("Quel est le ratio Cuisiniers/Clients optimal ?");
            double RatioCuisiniersClients = Program.gestErreurDouble();
            Console.WriteLine("Quel est le ratio Serveurs/Clients optimal ?");
            double RatioServeursClients = Program.gestErreurDouble();
            Console.WriteLine("Combien y a-t-il de places au bar ?");
            int barTables = Program.gestErreurEntier();
            Console.WriteLine("Combien y a-t-il de tables autres qu'au bar ?");
            int TablesPasBar = Program.gestErreurEntier();
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
                        "\nCapacité maximum de Clients : " + nbMaxClients +
                        "\nNombre maximum de Serveurs : " + nbMaxServeurs +
                        "\nNombre maximum de Cuisiniers : " + nbMaxCuisiniers +
                        "\nRatio Cuisinier/Client : " + ratioCuisiniersClients +
                        "\nRatio Serveur/Client : " + ratioServeursClients +
                        "\nNombre de tables : " + listeTables.Capacity;                     

            return ch; 
            
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

            listeFormules.Add(new Formule(Nom, Preparation, Consommation, surPlace));
            
            XDocument docInfo = new XDocument();
            docInfo = XDocument.Load("docInfo.xml");

            docInfo.Element("Formules").Add(new XElement("Formule", new XAttribute("IdFormule", Nom),
                new XElement("DureePreparation", Preparation), new XElement("DureeConsommation", Consommation), new XElement("SurPlace", surPlace)));

        }
        
    }
}
