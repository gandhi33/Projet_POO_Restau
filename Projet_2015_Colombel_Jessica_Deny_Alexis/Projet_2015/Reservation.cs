﻿using System;
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
        public ServiceParJour service { get; private set; }
        public string nomClient { get; private set; }
        public string numTelephone { get; private set; }
        public DateTime jourResa { get; private set; }
        public DateTime horaireDebutResa { get; private set; }
        public DateTime horaireFinResa { get; private set; }
        public int nbConvives { get; private set; }
        public Formule formuleRetenue { get; private set; }
        public List<Table> tableAffectee { get; private set; }

        public Reservation(Restaurant Restaurant, ServiceParJour ServiceParJour, string NomClient,
            string NumTelephone, DateTime JourResa, DateTime HoraireDebutResa, DateTime HoraireFinResa,
            int NbConvives, Formule FormuleRetenue, List<Table> TableAffectee)
        {
            restaurant = Restaurant;
            service = ServiceParJour;
            nomClient = NomClient;
            numTelephone = NumTelephone;
            jourResa = JourResa;
            horaireDebutResa = HoraireDebutResa;
            horaireFinResa = HoraireFinResa;
            nbConvives = NbConvives;
            formuleRetenue = FormuleRetenue;
            tableAffectee = TableAffectee;
        }
      
// A faire
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

        public void EnregistrerResa()
        {
            XDocument docRestau = new XDocument();
            docRestau = XDocument.Load("docRestau.xml");

            //docRestau.Element("Reservations").Add(new XElement("Reservation", new XAttribute("IdReservation", nomClient), 
              //  new XElement("NumTelephone",numTelephone), new XElement("JourResa",jourResa), new XElement("HoraireDebut",horaireDebutResa), new XElement("",))); 

            // Finir
        } // A finir

        public void ModifierResa()
        {
            // lalala
        } // A finir

        public List<Table> trouveTables(Restaurant R, int NbC, ServiceParJour S, DateTime HDR, DateTime HFR)
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
        
    }
}
