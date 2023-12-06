using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private LibraryMangEntities myservice;

        public ReservationService()
        {
            myservice = new LibraryMangEntities();
            myservice.Configuration.LazyLoadingEnabled = false;
            myservice.Configuration.ProxyCreationEnabled = false;

        }

        public List<ReservationInfo> GetReservations()
        {
            using (var context = new LibraryMangEntities()) // Replace YourDbContext with the actual name of your DbContext
            {
                // Retrieve reservations from the database including related entities
                var reservations = context.Reservations
                    .Include(r => r.Book)
                    .Include(r => r.Student)
                    .ToList();

                // Project the data into ReservationInfo
                var reservationInfoList = reservations.Select(r => new ReservationInfo
                {
                    ReservationId = r.id,
                    StudentId = r.id_Student ?? 0,
                    StudentFirstName = r.Student?.firstName, // Assuming Student has a FirstName property
                    BookId = r.id_Book ?? 0,
                    BookTitle = r.Book?.title, // Assuming Book has a Title property
                    DateOfReservation = r.dateOfReserv
                }).ToList();

                return reservationInfoList;
            }
            //return myservice.Reservations.ToList();
        }

       

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
