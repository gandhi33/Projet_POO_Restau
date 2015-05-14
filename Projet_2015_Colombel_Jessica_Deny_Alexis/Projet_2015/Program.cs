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
            Menu();

            return;
        }
               

        public static void Menu()
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
            string frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = Console.ReadLine();
            }
            while (frappe != "0" && frappe != "1" && frappe != "2" && frappe != "3" && frappe != "4" && frappe != "5");
            int choix = int.Parse(frappe);
            switch(choix)
            {
                case 0:
                    Console.WriteLine("Au revoir !");
                    Console.WriteLine("Appuyez sur la touche entrée pour quitter.");
                    Console.ReadLine();
                    break;
                case 1:
                    GererReservation();
                    break;
                case 2:
                    GererRestaurant();
                    break;
                case 3:
                    GererTable();
                    break;
                case 4:
                    GererFormule();
                    break;
                case 5:
                    //Kiki.ToString();
                    break;
            }
        }

        public static void GererReservation()
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
            string frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = Console.ReadLine();
            }
            while (frappe != "0" && frappe != "1" && frappe != "2" && frappe != "3");
            int choix = int.Parse(frappe);
            switch (choix)
            {
                case 0:
                    Menu();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;

            }           
        }

        public static void GererRestaurant()
        {
            int choix = 0;

            Console.WriteLine("+----------------------------------------------------------------------------+");
            Console.WriteLine("|                           GESTION DU RESTAURANT                            |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 1 | Modifier le nom du restaurant                                  |");
            Console.WriteLine("|  TAPEZ 1  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 2 | Modifier les horaires d'ouverture                              |");
            Console.WriteLine("|  TAPEZ 2  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("| Requête 3 | Modifier les autres infos                                      |");
            Console.WriteLine("|  TAPEZ 3  |                                                                |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");
            Console.WriteLine("|  Tapez 0  | Retourner au menu principal                                    |");
            Console.WriteLine("+-----------+----------------------------------------------------------------+");

            string frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = Console.ReadLine();
            }
            while (frappe != "0" && frappe != "1" && frappe != "2" && frappe != "3");

            choix = int.Parse(frappe);
            switch(choix)
            {
                case 0:
                    Menu();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        public static void GererTable()
        {
            int choix = 0;

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

            string frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = Console.ReadLine();
            }
            while (frappe != "0" && frappe != "1" && frappe != "2");

            choix = int.Parse(frappe);
            switch (choix)
            {
                case 0:
                    Menu();
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        public static void GererFormule()
        {
            int choix = 0;

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

            string frappe;
            do
            {
                Console.WriteLine("Entrez le numéro de la requête souhaitée s'il vous plait.");
                frappe = Console.ReadLine();
            }
            while (frappe != "0" && frappe != "1" && frappe != "2" && frappe != "3");

            choix = int.Parse(frappe);
            switch (choix)
            {
                case 0:
                    Menu();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
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

    }
}
