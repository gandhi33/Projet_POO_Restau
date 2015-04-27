using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class Reservation : Program
    {
        public Restaurant restaurant { get; private set; }
        public string nomClient { get; private set; }
        public string numTelephone { get; private set; }
        public string dateReservation { get; private set; }
        public int nbConvives { get; private set; }
        public Formule formuleRetenue { get; private set; }
        public List<Table> tableAffectee { get; private set; }
    }
}
