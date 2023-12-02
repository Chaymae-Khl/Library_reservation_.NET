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
        public ObservableCollection<Reservation> ListOfReservations { get; set; }

        ReservationsServiceReference.ReservationServiceClient myservice= new ReservationsServiceReference.ReservationServiceClient();
        
        public DelegateCommand makeReservation {  get; set; }
       public DelegateCommand removeReservation { get; set; }
       public Reservation newReservation { get; set; }
      
       public Reservation selectedRow { get; set; }
        public ReservationBusiness()
        {
            this.ListOfReservations=myservice.GetReservations();
           
            this.newReservation=new Reservation();
            this.makeReservation = new DelegateCommand(makeReservationFunc);
            this.removeReservation = new DelegateCommand(removeReservationFunction);
        }

        private void removeReservationFunction()
        {
            if (selectedRow != null)
            {
                myservice.RemoveReservation(selectedRow.id);
                ListOfReservations.Remove(selectedRow);
                MessageBox.Show("Reservation Removed");

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
    }
}
