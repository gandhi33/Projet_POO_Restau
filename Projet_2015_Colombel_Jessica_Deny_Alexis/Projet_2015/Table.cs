using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{

    abstract class Table : Program
    {
        abstract public Restaurant restaurant { get; protected set; }
        abstract public int numeroTable { get; protected set; }
        abstract public int nbMaxPlaces { get; protected set; }
        abstract public int positionCuisine { get; protected set; }
        abstract public int presVitrine { get; protected set; }
        public List<Table> tablesJumelables { get; private set; }
    }
   
}
