using AuthenticationServiceReference;
using MyLibraryClient.Views.MyUcs;
using Prism.Commands;
using ReservationsServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyLibraryClient.Business
{
    public class AuthenticationBusiness
    {

        public DelegateCommand LoginCommand { get; set; }
        public Administrator administrator { get; set; }

        public AuthenticationBusiness()
        {
            this.administrator = new Administrator();
            LoginCommand = new DelegateCommand(LoginMethod);
        }
        AuthenticationServiceReference.AuthenticationServiceClient myservice = new AuthenticationServiceReference.AuthenticationServiceClient();
        private void LoginMethod()
        {
           if( myservice.Login(administrator.ad_login, administrator.ad_password)) { 
            MenuUC myMenu=new MenuUC();
            myMenu.DataContext = new MenuBusiness();
            MainWindow mainWindow=App.Current.MainWindow as MainWindow;
            mainWindow.gr_content.Children.Clear();
            mainWindow.gr_content.Children.Add(myMenu);}
            else
            {
                MessageBox.Show("Login or password Incorrect");
            }
        }
    }
}
