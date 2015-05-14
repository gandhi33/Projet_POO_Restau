using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Projet_2015
{
    class Formule
    {
        public string nomFormule { get; private set; }
        public TimeSpan dureePreparation { get; protected set; }
        public TimeSpan dureeConsommation { get; protected set; }
        public bool surPlace { get; protected set; }

        public Formule(TimeSpan Preparation, TimeSpan Consommation, bool SurPlace)
        {
            dureePreparation = Preparation;
            dureeConsommation = Consommation;
            surPlace = SurPlace; 
        }

        /*public void AjoutFormule()
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

            Formule Nom = new Formule(Preparation, Consommation, surPlace); // ZUT ZUT ZUT

            XDocument docInfo = new XDocument();
            docInfo.Load("docInfo.xml");

            XElement elem = docInfo.Element("Formules").Add(new XElement("Formule", new XAttribute("IdFormule", Nom), 
                new XElement("DureePreparation", Preparation), new XElement("DureeConsommation",Consommation), new XElement("SurPlace",surPlace))); 
            
        }*/

        public void SupprimeFormule()
        {
            // huhu
        }

        public void ModifierFormule()
        {
            // lala
        }

    }
}
