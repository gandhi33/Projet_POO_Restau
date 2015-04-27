using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    abstract class Service : Restaurant
    {
        public abstract int heureOpenEmployes;
        public abstract int minuteOpenEmployes;
        public abstract int heureOpenClients;
        public abstract int minuteOpenClients;
    }
}
