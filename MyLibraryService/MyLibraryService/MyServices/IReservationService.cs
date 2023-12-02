﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLibraryService.MyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReservationService" in both code and config file together.
    [ServiceContract]
    public interface IReservationService
    {
        [OperationContract]
        void MakeReservation(Reservation reservation);

        [OperationContract]
        void RemoveReservation(int id);

        [OperationContract]

        List<Reservation> GetReservations();

       
    }
}
