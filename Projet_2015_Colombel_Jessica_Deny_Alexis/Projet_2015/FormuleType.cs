using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class FormuleType : Formule
    {
        public abstract string nomFormule { get; private set; }
        public bool surPlace { get; private set; }
    }
}
