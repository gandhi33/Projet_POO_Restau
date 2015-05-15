using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class ServiceParJour : Service
    {
        public DateTime jour { get; protected set; }
        public List<Reservation> reservations { get; protected set; }

        public ServiceParJour(TimeSpan HOEM, TimeSpan HCEM, TimeSpan HOCM, TimeSpan HCCM, TimeSpan HOES, TimeSpan HCES, TimeSpan HOCS, TimeSpan HCCS,
            DateTime J, List<Reservation> Resas):base(HOEM,HCEM,HOCM,HCCM,HOES,HCES,HOCS,HCCS)
        {
            jour = J;
            reservations = Resas;
        }


    }
}
