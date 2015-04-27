using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class Midi : Service
    {
        public int heureOpenEmployes { get; private set; }
        public int minuteOpenEmployes { get; private set; }
        public int heureOpenClients { get; private set; }
        public int minuteOpenClients { get; private set; }
    }
}
