﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLibraryService.MyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReservationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReservationService.svc or ReservationService.svc.cs at the Solution Explorer and start debugging.
    public class ReservationService : IReservationService
    {
        private LibraryMangEntities myservice = new LibraryMangEntities();


        public void MakeReservation(Reservation reservation)
        {
            myservice.Reservations.Add(reservation);
            myservice.SaveChanges();
        }

        public void RemoveReservation(int id)
        {
           Reservation exectingReserv =myservice.Reservations.Find(id);
            myservice.Reservations.Remove(exectingReserv);
            myservice.SaveChanges();
        }
    }
}
