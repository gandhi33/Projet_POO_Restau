using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class Service
    {
        public DateTime Jour { get; protected set; }
        public DateTime horaireOpenEmployes { get; protected set; }
        public DateTime horaireCloseEmployes { get; protected set; }
        public DateTime horaireOpenClients { get; protected set; }
        public DateTime horaireCloseClients { get; protected set; }
    }
}
