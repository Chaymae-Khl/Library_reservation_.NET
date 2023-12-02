using MyLibraryClient.Views.MyUcs;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryClient.Business
{
    class MenuBusiness
    {
        public DelegateCommand StudentButton { get; set; }
        public DelegateCommand BookButton { get; set; }

        public DelegateCommand ReservationButton { get; set; }

        public MenuBusiness()
        {
            StudentButton = new DelegateCommand(studentbuttonclick);
            BookButton = new DelegateCommand(bookbuttonclick);
            ReservationButton = new DelegateCommand(reservationButtonclick);
        }

        private void reservationButtonclick()
        {
            MainWindow mainWindow=App.Current.MainWindow as MainWindow;
            ReservationUc reservationUc = new ReservationUc();
            mainWindow.gr_content.Children.Clear();
            mainWindow.gr_content.Children.Add(reservationUc);
            reservationUc.DataContext=new ReservationBusiness();
        }

        private void bookbuttonclick()
        {
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            OperationsUC opsUC = new OperationsUC();
            opsUC.OpsTitle.Content = "Book management";
            mainWindow.gr_content.Children.Clear();
            mainWindow.gr_content.Children.Add(opsUC);
            opsUC.DataContext = new BookBusiness();
        }

        private void studentbuttonclick()
        {
            MainWindow mainWindow=App.Current.MainWindow as MainWindow;
            OperationsUC opsUC = new OperationsUC();
            opsUC.OpsTitle.Content = "Student management";
            mainWindow.gr_content.Children.Clear();
            mainWindow.gr_content.Children.Add(opsUC);
            opsUC.DataContext = new StudentBusiness();
        }
    }




}
