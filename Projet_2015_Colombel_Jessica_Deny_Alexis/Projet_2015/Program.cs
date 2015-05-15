using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class Program
    {      

        static void Main(string[] args)
        {
            //Menu(R);

            return;
        }
               

        public static void Menu(Restaurant R)
        {
            Console.WriteLine("Bienvenue Chez Kiki");
            Console.WriteLine();
            Console.WriteLine("+----------------------------------------------------------------------------+");
            Console.WriteLine("|                                     MENU                                   |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 1 | Gérer les réservations                                         |");
            Console.WriteLine("|  TAPEZ 1  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 2 | Gérer le restaurant                                            |");
            Console.WriteLine("|  TAPEZ 2  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 3 | Gérer les tables                                               |");
            Console.WriteLine("|  TAPEZ 3  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 4 | Gérer les formules                                             |");
            Console.WriteLine("|  TAPEZ 4  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 5 | Informations restaurant                                        |");
            Console.WriteLine("|  TAPEZ 5  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  Tapez 0  | Quitter                                                        |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            int frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = gestErreurEntier();
            }
            while (frappe < 0 && frappe > 5);
            switch(frappe)
            {
                case 0:
                    Console.WriteLine("Au revoir !");
                    Console.WriteLine("Appuyez sur la touche entrée pour quitter.");
                    Console.ReadLine();
                    break;
                case 1:
                    GererReservation(R);
                    break;
                case 2:
                    GererRestaurant(R);
                    break;
                case 3:
                    GererTable(R);
                    break;
                case 4:
                    GererFormule(R);
                    break;
                case 5:
                    R.ToString();
                    Console.WriteLine("Appuyez sur entrée pour revenir au menu principal...");
                    Console.ReadLine();
                    Menu(R);
                    break;
            }
        }

        public static void GererReservation(Restaurant R)
        {
            Console.WriteLine("+----------------------------------------------------------------------------+");
            Console.WriteLine("|                         GESTION DES RESERVATIONS                           |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 1 | Créer une nouvelle réservation                                 |");
            Console.WriteLine("|  TAPEZ 1  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 2 | Modifier une réservation                                       |");
            Console.WriteLine("|  TAPEZ 2  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 3 | Annuler une réservation                                        |");
            Console.WriteLine("|  TAPEZ 3  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  Tapez 0  | Retourner au menu principal                                    |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            int frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = gestErreurEntier();
            }
            while (frappe < 0 && frappe > 3);
            switch (frappe)
            {
                case 0:
                    Menu(R);
                    break;
                case 1:
                    R.ajoutReservation();
                    retourGesResas(R);
                    break;
                case 2:
                    R.modifReservation();
                    retourGesResas(R);
                    break;
                case 3:
                    R.annulReservation();
                    retourGesResas(R);
                    break;

            }           
        }

        public static void GererRestaurant(Restaurant R)
        {

            Console.WriteLine("+----------------------------------------------------------------------------+");
            Console.WriteLine("|                           GESTION DU RESTAURANT                            |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  TAPEZ 1  | Modifier le nom du restaurant                                  |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  TAPEZ 2  | Modifier le nombre max de cuisiniers                           |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  TAPEZ 3  | Modifier le nombre max de serveurs                             |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  TAPEZ 4  | Modifier le nombre max de clients                              |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  TAPEZ 5  | Modifier le ratio serveur/clients                              |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  TAPEZ 6  | Modifier le ratio cuisinier/clients                            |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  Tapez 0  | Retourner au menu principal                                    |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");

            int frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = gestErreurEntier();
            }
            while (frappe < 0 && frappe > 6);
            switch(frappe)
            {
                case 0:
                    Menu(R);
                    break;
                case 1:
                    R.modifNomRestaurant();
                    retourGesRestau(R);
                    break;
                case 2:
                    R.modifNbMaxCuisiniers();
                    retourGesRestau(R);
                    break;
                case 3:
                    R.modifNbMaxServeurs();
                    retourGesRestau(R);
                    break;
                case 4:
                    R.modifNbMaxClients();
                    retourGesRestau(R);
                    break;
                case 5:
                    R.modifRatioServeurClient();
                    retourGesRestau(R);
                    break;
                case 6:
                    R.modifRatioCuisinierClient();
                    retourGesRestau(R);
                    break;
            }
        }

        public static void GererTable(Restaurant R)
        {

            Console.WriteLine("+----------------------------------------------------------------------------+");
            Console.WriteLine("|                         GESTION DES TABLES                                 |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 1 | Ajouter une table dans la salle                                |");
            Console.WriteLine("|  TAPEZ 1  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 2 | Retirer une table de la salle                                  |");
            Console.WriteLine("|  TAPEZ 2  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  Tapez 0  | Retourner au menu principal                                    |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");

            int frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = gestErreurEntier();
            }
            while (frappe < 0 && frappe > 2);
            switch (frappe)
            {
                case 0:
                    Menu(R);
                    break;
                case 1:
                    R.ajoutTable();
                    retourGesTables(R);
                    break;
                case 2:
                    R.retireTable();
                    retourGesTables(R);
                    break;
            }
        }

        public static void GererFormule(Restaurant R)
        {

            Console.WriteLine("+----------------------------------------------------------------------------+");
            Console.WriteLine("|                           GESTION DES FORMULES                             |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 1 | Créer une nouvelle formule                                     |");
            Console.WriteLine("|  TAPEZ 1  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 2 | Modifier une formule                                           |");
            Console.WriteLine("|  TAPEZ 2  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 3 | Supprimer une formule                                          |");
            Console.WriteLine("|  TAPEZ 3  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  Tapez 0  | Retourner au menu principal                                    |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");

            int frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = gestErreurEntier();
            }
            while (frappe < 0 && frappe > 3);
            switch (frappe)
            {
                case 0:
                    Menu(R);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        public static int gestErreurEntier()
        {
            try
            {
                int a = int.Parse(Console.ReadLine());
                if (a < 0)
                {
                    Console.WriteLine("Veuillez entrer un entier valide supérieur ou égal à 0.");
                    a = gestErreurEntier();
                }
                return a;
            }
            catch
            {
                Console.WriteLine("Veuillez entrer un entier valide.");
                int a = gestErreurEntier();
                return a;
            }
        }
        
        public static double gestErreurDouble()
        {
            try
            {
                double a = double.Parse(Console.ReadLine());
                if (a < 0)
                {
                    Console.WriteLine("Veuillez entrer un nombre réel valide supérieur ou égal à 0.");
                    a = gestErreurDouble();
                }
                return a;
            }
            catch
            {
                Console.WriteLine("Veuillez entrer un nombre réel valide.");
                double a = gestErreurDouble();
                return a;
            }
        }

        public static bool gestErreurBool()
        {
            try
            {
                bool a = bool.Parse(Console.ReadLine());
                return a;
            }
            catch
            {
                Console.WriteLine("Veuillez entrer 0 ou 1.");
                bool a = gestErreurBool();
                return a;
            }
        }

        public static void retourGesResas(Restaurant R)
        {
            Console.WriteLine("Appuyez sur entrée pour revenir au menu de gestion des réservations...");
            Console.ReadLine();
            GererReservation(R);
        }

        public static void retourGesRestau(Restaurant R)
        {
            Console.WriteLine("Appuyez sur entrée pour revenir au menu de gestion du restaurant...");
            Console.ReadLine();
            GererRestaurant(R);
        }

        public static void retourGesTables(Restaurant R)
        {
            Console.WriteLine("Appuyez sur entrée pour revenir au menu de gestion de tables...");
            Console.ReadLine();
            GererTable(R);
        }
    }
}
