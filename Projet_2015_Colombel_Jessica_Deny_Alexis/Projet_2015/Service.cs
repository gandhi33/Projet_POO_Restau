using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_2015
{
    class Service
    {
        public TimeSpan horaireOpenEmployesMidi { get; protected set; }
        public TimeSpan horaireCloseEmployesMidi { get; protected set; }
        public TimeSpan horaireOpenClientsMidi { get; protected set; }
        public TimeSpan horaireCloseClientsMidi { get; protected set; }

        public TimeSpan horaireOpenEmployesSoir { get; protected set; }
        public TimeSpan horaireCloseEmployesSoir { get; protected set; }
        public TimeSpan horaireOpenClientsSoir { get; protected set; }
        public TimeSpan horaireCloseClientsSoir { get; protected set; }
        

        public Service(TimeSpan HOEM, TimeSpan HCEM, TimeSpan HOCM, TimeSpan HCCM, TimeSpan HOES, TimeSpan HCES, TimeSpan HOCS, TimeSpan HCCS)
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

        public Service()
        {
            horaireOpenEmployesMidi = new TimeSpan(10,30,00);
            horaireCloseEmployesMidi = new TimeSpan(14, 30, 00);
            horaireOpenClientsMidi = new TimeSpan(11, 30, 00);
            horaireCloseClientsMidi = new TimeSpan(13,30,00);

            horaireOpenEmployesSoir = new TimeSpan(18, 00, 00);
            horaireCloseEmployesSoir = new TimeSpan(23, 30, 00);
            horaireOpenClientsSoir = new TimeSpan(19, 00, 00);
            horaireCloseClientsSoir = new TimeSpan(23, 00, 00); 
        }

        public void AjouteService()
        { 
            // Lalalala
        } // A faire

        public void EnregistrerService()
        {
            //Lalou
        } // A faire

    }
}
