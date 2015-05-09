﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class Restaurant
    {
        public string nomRestaurant { get; private set; }
        public Midi midi { get; protected set; }
        public Soir soir { get; protected set; }
        public int nbMaxClients { get; private set; }
        public int nbMaxCuisiniers { get; private set; }
        public int nbMaxServeurs { get; private set; }
        public double ratioCuisiniersClients { get; private set; }
        public double ratioServeursClients { get; private set; }
        public List<Table> listeTables {get; private set; }

        public Restaurant(string NomRestaurant, Midi Midi, Soir Soir, int NbMaxClients, int NbMaxCuisiniers, int NbMaxServeurs, double RatioCuisiniersClients, double RatioServeursClients, List<Table> ListeTables)
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

        public Restaurant()
        {
            demandeInfo();
        }

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
