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
            Restaurant Kiki = new Restaurant();
            bool a = true;
            do
            {
                a=Menu();
            }
            while (a);

            return;
        }
               

        public static bool Menu()
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
            Console.WriteLine("| Requête 5 | Informations restaurants                                       |");
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
                    a = false;
                    break;
                case 1:
                    GererReservation();
                    a = Encore();
                    break;
                case 2:
                    GererRestaurant();
                    a = Encore();
                    break;
                case 3:
                    GererTable();
                    a = Encore();
                    break;
                case 4:
                    GererFormule();
                    a = Encore();
                    break;
                case 5:
                    //Kiki.ToString();
                    a = Encore();
                    break;
            }
            return a;
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
            while (frappe != "0" && frappe != "1" && frappe != "2" && frappe != "3" && frappe != "4" && frappe != "5");
            int choix = int.Parse(frappe);
            switch (choix)
            {
                case 0:
                    break;
            }

            if (choix == 0)
            {
                return;
            }
            if (choix == 1)
            {
                
            }
            if (choix == 2)
            {
                
            }
            if (choix == 3)
            {
                
            }
 
            
        }

        public static void GererRestaurant()
        {
            int choix = 0;

            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("");
            Console.WriteLine("1) Créer une nouvelle réservation");
            Console.WriteLine("2) Modifier une réservation");
            Console.WriteLine("3) Annuler une réservation");
            Console.WriteLine("");
            Console.WriteLine("Tapez 0 pour retourner au menu principal");

            choix = int.Parse(Console.ReadLine());

            if (choix == 0)
            {
                return;
            }
            if (choix == 1)
            {

            }
            if (choix == 2)
            {

            }
            if (choix == 3)
            {

            }
        }

        public static void GererTable()
        {
            int choix = 0;

            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("");
            Console.WriteLine("1) Rajouter une table");
            Console.WriteLine("2) Retirer une table de la salle");
            Console.WriteLine("");
            Console.WriteLine("Tapez 0 pour retourner au menu principal");

            choix = int.Parse(Console.ReadLine());

            if (choix == 0)
            {
                return;
            }
            if (choix == 1)
            {

            }
            if (choix == 2)
            {

            }
            
        }

        public static void GererFormule()
        {
            int choix = 0;

            Console.WriteLine("Que souhaitez-vous faire ?");
            Console.WriteLine("");
            Console.WriteLine("1) Créer une nouvelle formule");
            Console.WriteLine("2) Modifier une formule");
            Console.WriteLine("3) Supprimer une formule");
            Console.WriteLine("");
            Console.WriteLine("Tapez 0 pour retourner au menu principal");

            choix = int.Parse(Console.ReadLine());

            if (choix == 0)
            {
                return;
            }
            if (choix == 1)
            {

            }
            if (choix == 2)
            {

            }
            if (choix == 3)
            {

            }
        }       
 
        public static bool Encore()
        {
            int x = 2;

            do
            {
                Console.WriteLine("Souhaitez-vous faire autre chose ?");
                Console.WriteLine("Tapez 1 pour oui, tapez 0 pour quitter");
            }
            while (x != 0 || x != 1);
 
            if(x==0)
            {
                return false; 
            }
            else
            {
                return true;
            }

        }

    }
}
