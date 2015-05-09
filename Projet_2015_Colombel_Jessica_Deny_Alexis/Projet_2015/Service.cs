using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    abstract class Service
    {
        abstract public DateTime horaireOpenEmployes;
        abstract public DateTime horaireCloseEmployes;
        abstract public DateTime horaireOpenClients;
        abstract public DateTime horaireCloseClients;
    }
}
