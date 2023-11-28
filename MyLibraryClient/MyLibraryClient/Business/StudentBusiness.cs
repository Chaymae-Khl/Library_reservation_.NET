using MyLibraryClient.Views.MyUcs;
using MyLibraryClient.Views.MyUcs.MyForms;
using Prism.Commands;
using StudentsServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MyLibraryClient.Business
{
    public class StudentBusiness
    {
        public ObservableCollection<Students> listOfObjects { get; set; } = new ObservableCollection<Students>();
        StudentsServiceReference.StudentServiceClient myservice = new StudentsServiceReference.StudentServiceClient();

        #region OperationsUc DelegateCommand
        public DelegateCommand deleteButton { get; set; }
        public DelegateCommand AddButton { get; set; }

        public DelegateCommand UpdateButton { get; set; }
        public DelegateCommand MenuButton { get; set; }
        #endregion

        #region Form DelegateCommand

        public DelegateCommand ManageStudentButton { get; set; }
        public DelegateCommand AddUpdateStudent {  get; set; }

        #endregion


        public Students selectedRow { get; set; }
        public Students students { get; set; }
        public StudentBusiness()
        {
            this.listOfObjects=myservice.GetStudents();
            this.students=new Students();

            #region Instances Of OperationsUc deligeatecommand
            this.deleteButton = new DelegateCommand(DeleteFunction);
            this.AddButton = new DelegateCommand(AddButtonFunction);
            this.UpdateButton = new DelegateCommand(UpdateButtonFunction);
            this.MenuButton = new DelegateCommand(MenuButtonFunction);
            #endregion

            #region Instances of Form DelegateCommand
            this.ManageStudentButton = new DelegateCommand(ManageStudentButtonFunction);
            this.AddUpdateStudent = new DelegateCommand(addUpdateStd);
            #endregion
        }


        #region function of Form delagateCommand

        private void ManageStudentButtonFunction()
        {
            Comeback();
        }


        private void addUpdateStd()
        {
            if(selectedRow!=null) {
                myservice.UpdateStudent(students);
                MessageBox.Show("Student updated Successfly");
                Comeback();

            }
            else
            {
                myservice.AddStudent(students);
                MessageBox.Show("Student Added Succesfly");
            }
        }

        #endregion




        #region  Functions of OperationsUc DelegateCommand
        private void AddButtonFunction()
        {
           MainWindow mainWindow=App.Current.MainWindow as MainWindow; 
           StudentForm myform=new StudentForm();
           mainWindow.gr_content.Children.Clear();
           mainWindow.gr_content.Children.Add(myform);
            //myform.hidenInput.Visibility= Visibility.Collapsed;
            //myform.hiddenLabel.Visibility= Visibility.Collapsed;
           myform.labelContent.Content = "Add Form";
           myform.DataContext = this;

        }

        private void DeleteFunction()
        {
            if (selectedRow != null)
            {
                myservice.DeleteStudent(selectedRow.id);
                listOfObjects.Remove(selectedRow);
            }
            else
                MessageBox.Show("Please Select a student");

        }

        private void UpdateButtonFunction()
        {
            if (selectedRow != null)
            {
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            StudentForm myform = new StudentForm();
            mainWindow.gr_content.Children.Clear();
            mainWindow.gr_content.Children.Add(myform);
            //myform.hidenInput.Visibility = Visibility.Visible;
            //myform.hiddenLabel.Visibility = Visibility.Visible;
            myform.labelContent.Content = "Edit Form";
            myform.DataContext = this;
            this.students = selectedRow;
            }
            else
                MessageBox.Show("Please select a row to update");
        }


        private void MenuButtonFunction()
        {
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            mainWindow.gr_content.Children.Clear();
            MenuUC menu =new MenuUC();
            menu.DataContext = new MenuBusiness();
            mainWindow.gr_content.Children.Add(menu);
        }
        #endregion


        #region Usefull Methods
        public void Comeback()
        {
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            mainWindow.gr_content.Children.Clear();
            OperationsUC operations = new OperationsUC();
            operations.OpsTitle.Content = "Student Management";
            mainWindow.gr_content.Children.Add(operations);
            operations.DataContext = new StudentBusiness();
        }
        #endregion


    }
}
