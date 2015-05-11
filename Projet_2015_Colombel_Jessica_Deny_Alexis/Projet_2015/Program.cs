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
            int choix = 0;
            
            Console.WriteLine("Bienvenue Chez Kiki");
            Console.WriteLine();
            
            do
            {
                Console.WriteLine("Que souhaitez-vous faire (tapez le numéro) ? ");
                Console.WriteLine();
                Console.WriteLine("1) Gérer les réservations");
                Console.WriteLine("2) Gérer le restaurant");
                Console.WriteLine("3) Gérer les tables");
                Console.WriteLine("4) Gérer les formules");
                Console.WriteLine("5) Informations restaurants ?");
                Console.WriteLine();
                Console.WriteLine("Tapez 0 pour quitter l'application");
                choix = int.Parse(Console.ReadLine());

                if (choix == 0)
                {
                    return;
                }
                if (choix == 1)
                {
                    GererReservation();
                    a = Encore();
                }
                if (choix == 2)
                {
                    GererRestaurant();
                    a = Encore();
                }
                if (choix == 3)
                {
                    GererTable();
                    a = Encore();
                }
                if (choix == 4)
                {
                    GererFormule();
                    a = Encore();
                }
                if (choix == 5)
                {
                    Kiki.ToString();
                    a = Encore();
                }

            }
            while (a);

            return;

        }
               

        public static void GererReservation()
        {
            int choix=0; 

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
            Console.WriteLine("1) Acheter une table");
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
            if(x==1)
            {
                return true;
            }
        }

    }
}
