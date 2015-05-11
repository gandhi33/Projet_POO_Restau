using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projet_2015
{
    class Formule
    {        
        public string nomFormule { get; private set; }
        public TimeSpan dureePreparation { get; protected set; }
        public TimeSpan dureeConsommation { get; protected set; }
        public bool surPlace { get; private set; }

        public Formule(string Nom, TimeSpan Preparation, TimeSpan Consommation, bool SurPlace)
        {
            nomFormule = Nom;
            dureePreparation = Preparation;
            dureeConsommation = Consommation;
            surPlace = SurPlace; 
        }

    }
}
