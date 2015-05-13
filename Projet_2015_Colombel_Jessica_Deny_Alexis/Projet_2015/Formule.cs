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
        public TimeSpan dureePreparation { get; protected set; }
        public TimeSpan dureeConsommation { get; protected set; }
        public bool surPlace { get; protected set; }

        public Formule(TimeSpan Preparation, TimeSpan Consommation, bool SurPlace)
        {
            dureePreparation = Preparation;
            dureeConsommation = Consommation;
            surPlace = SurPlace; 
        }

    }
}
