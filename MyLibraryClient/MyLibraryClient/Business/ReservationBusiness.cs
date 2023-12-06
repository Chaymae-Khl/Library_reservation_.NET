using Prism.Commands;
using ReservationsServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyLibraryClient.Business
{
    internal class ReservationBusiness
    {
        #region Propreties

        public ObservableCollection<Reservation> ListOfReservations { get; set; }
        public Reservation newReservation { get; set; }
        public Reservation selectedRow { get; set; }
        ReservationsServiceReference.ReservationServiceClient myservice= new ReservationsServiceReference.ReservationServiceClient();
       
        #endregion

        #region Reservation DelegateCOmmand

        public DelegateCommand makeReservation {  get; set; }
        public DelegateCommand removeReservation { get; set; }

        #endregion


        #region Constrictor

        public ReservationBusiness()
        {
            this.ListOfReservations=myservice.GetReservations();
            this.newReservation=new Reservation();
            this.makeReservation = new DelegateCommand(makeReservationFunc);
            this.removeReservation = new DelegateCommand(removeReservationFunction);
        }

        #endregion


        #region DelegateCommand functions
        private void removeReservationFunction()
        {
            if (selectedRow != null)
            {
                myservice.RemoveReservation(selectedRow.id);
                MessageBox.Show("Reservation Removed");
                ListOfReservations.Remove(selectedRow);

            }
            else
                MessageBox.Show("Please Select a row");
        }

        private void makeReservationFunc()
        {
           
            newReservation.dateOfReserv= DateTime.Now;
            myservice.MakeReservation(newReservation);
            ListOfReservations.Add(newReservation);
            MessageBox.Show("Reservation Added succesfly");
        }

        #endregion
    }
}
