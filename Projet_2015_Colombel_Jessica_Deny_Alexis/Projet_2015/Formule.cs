using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    abstract class Formule
    {
        public abstract Restaurant restaurant { get; private set; }
        public abstract TimeSpan dureePreparation { get; protected set; }
        public abstract TimeSpan dureeConsommation { get; protected set; }
    }
}
