using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    abstract class Formule : Program
    {
        public abstract Restaurant restaurant { get; private set; }
        public abstract int dureePreparation { get; protected set; }
        public abstract int dureeConsommation { get; protected set; }
    }
}
