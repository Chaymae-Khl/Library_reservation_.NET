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
        #region Propreties
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }
        public Administrator administrator { get; set; }
        public DelegateCommand MenuButton { get; set; }
        AuthenticationServiceReference.AuthenticationServiceClient myservice = new AuthenticationServiceReference.AuthenticationServiceClient();
        #endregion

        #region Constrictor
        public AuthenticationBusiness()
        {
            this.administrator = new Administrator();
            LoginCommand = new DelegateCommand(LoginMethod);
            LogoutCommand = new DelegateCommand(LogoutFunction);
            this.MenuButton = new DelegateCommand(MenuButtonFunction);

        }
        #endregion

        #region DelegateCommand functions
        private void MenuButtonFunction()
        {
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            mainWindow.gr_content.Children.Clear();
            MenuUC menu = new MenuUC();
            menu.DataContext = new MenuBusiness();
            mainWindow.gr_content.Children.Add(menu);
        }
        private void LogoutFunction()
        {
            MainWindow mainWindo=App.Current.MainWindow as MainWindow;
            mainWindo.gr_content.Children.Clear();
            LoginUC loginUC = new LoginUC();
            mainWindo.gr_content.Children.Add(loginUC);
        }

        private void LoginMethod()
        {
           if( myservice.Login(administrator.ad_login, administrator.ad_password)!=null) { 
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
        #endregion
    }
}
