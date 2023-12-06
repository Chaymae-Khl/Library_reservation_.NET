using MyLibraryClient.Views;
using MyLibraryClient.Views.MyUcs;
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

        public ObservableCollection<ReservationInfo> ListOfReservations { get; set; }
        public Reservation newReservation { get; set; }
        public ReservationInfo selectedRow { get; set; }
        ReservationsServiceReference.ReservationServiceClient myservice= new ReservationsServiceReference.ReservationServiceClient();
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                FilterReservations();
            }
        }

        private DateTime? _selectedDate;
        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                FilterReservationsByDates();
            }
        }
        #endregion

        #region Reservation DelegateCOmmand
        public DelegateCommand ReservationsOps {  get; set; }
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
            this.ReservationsOps = new DelegateCommand(resrevationsOpsFunction);
        }

       

        #endregion


        #region DelegateCommand functions
        private void removeReservationFunction()
        {
            if (selectedRow != null)
            {
                myservice.RemoveReservation(selectedRow.ReservationId);
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
           // ListOfReservations.Add(newReservation);
            MessageBox.Show("Reservation Added succesfly");
        }
        private void resrevationsOpsFunction()
        {
            ReservationList reservationList = new ReservationList();
            reservationList.DataContext = new ReservationBusiness();
            reservationList.Show();
        }
        #endregion

        #region Usefull Methods
        private void FilterReservations()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // If the search text is empty, show all books
                ListOfReservations.Clear();
                foreach (var rsrv in myservice.GetReservations())
                {
                    ListOfReservations.Add(rsrv);
                }
            }
            else
            {
                // Filter the books based on the search text
                var filteredList = myservice.GetReservations()
                    .Where(rsrv => rsrv.ReservationId.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                ListOfReservations.Clear();
                foreach (var rsrv in filteredList)
                {
                    ListOfReservations.Add(rsrv);
                }
            }
        }


        private void FilterReservationsByDates()
        {
            if (string.IsNullOrWhiteSpace(SearchText) && SelectedDate == null)
            {
                // If both search text and date are empty, show all reservations
                ListOfReservations.Clear();
                foreach (var rsrv in myservice.GetReservations())
                {
                    ListOfReservations.Add(rsrv);
                }
            }
            else
            {
                // Filter reservations based on search text and date
                var filteredList = myservice.GetReservations()
                    .Where(rsrv =>
                        (string.IsNullOrWhiteSpace(SearchText) || rsrv.ReservationId.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase)) &&
                        (!SelectedDate.HasValue || rsrv.DateOfReservation?.Date == SelectedDate.Value.Date))
                    .ToList();

                ListOfReservations.Clear();
                foreach (var rsrv in filteredList)
                {
                    ListOfReservations.Add(rsrv);
                }
            }
        }

        #endregion



    }
}
