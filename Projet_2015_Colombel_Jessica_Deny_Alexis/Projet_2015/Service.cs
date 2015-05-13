using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class Service
    {
        public DateTime horaireOpenEmployesMidi { get; protected set; }
        public DateTime horaireCloseEmployesMidi { get; protected set; }
        public DateTime horaireOpenClientsMidi { get; protected set; }
        public DateTime horaireCloseClientsMidi { get; protected set; }

        public DateTime horaireOpenEmployesSoir { get; protected set; }
        public DateTime horaireCloseEmployesSoir { get; protected set; }
        public DateTime horaireOpenClientsSoir { get; protected set; }
        public DateTime horaireCloseClientsSoir { get; protected set; }

        public DateTime jour { get; protected set; }
        public List<Reservation> reservations { get; protected set; }

        public Service(DateTime HOEM, DateTime HCEM, DateTime HOCM, DateTime HCCM, DateTime HOES, DateTime HCES, DateTime HOCS, DateTime HCCS)
        {
            horaireOpenEmployesMidi = HOEM;
            horaireCloseEmployesMidi = HCEM;
            horaireOpenClientsMidi = HOCM;
            horaireCloseClientsMidi = HCCM;

            horaireOpenEmployesSoir = HOES;
            horaireCloseEmployesSoir = HCES;
            horaireOpenClientsSoir = HOCS;
            horaireCloseClientsSoir = HCCS;
        }

        public Service(DateTime HOEM, DateTime HCEM, DateTime HOCM, DateTime HCCM, DateTime HOES, DateTime HCES, DateTime HOCS, DateTime HCCS,
            DateTime J, List<Reservation> Resas):this(HOEM,HCEM,HOCM,HCCM,HOES,HCES,HOCS,HCCS)
        {
            jour = J;
            reservations = Resas;
        }
    }
}
