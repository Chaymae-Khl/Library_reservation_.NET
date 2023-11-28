﻿using BookServiceReference;
using MyLibraryClient.Views.MyUcs;
using MyLibraryClient.Views.MyUcs.MyForms;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyLibraryClient.Business
{
    public class BookBusiness
    {
        BookServiceReference.BookServiceClient myservice  = new BookServiceReference.BookServiceClient();

        public ObservableCollection<Book> listOfObjects { get; set; } = new ObservableCollection<Book>();
        public Book selectedRow { get; set; }
         public Book book { get; set; }

        #region OperationsUc DelegateCommand
        public DelegateCommand MenuButton { get; set; }

        public DelegateCommand deleteButton { get; set; }
        public DelegateCommand AddButton { get; set; }

        public DelegateCommand UpdateButton { get; set; }
        #endregion

        #region Form DelegateCommand
        public DelegateCommand ManageStudentButton { get; set; }
        public DelegateCommand AddUpdateBook {  get; set; }
        #endregion



        public BookBusiness()
        {
            this.listOfObjects= myservice.GetBooks();
            this.book=new Book();

            #region Instances of OperationsUc DelegateCommand

            this.deleteButton = new DelegateCommand(deleteBook);
            this.AddButton=new DelegateCommand(AddButtonFunction);
            this.MenuButton = new DelegateCommand(MenuButtonFunction);
            this.UpdateButton = new DelegateCommand(UpdateButtonFunction);
            #endregion

            #region Instances of form DelegateCommand
            this.AddUpdateBook = new DelegateCommand(AddUpdateFunction);
            this.ManageStudentButton = new DelegateCommand(ManageStudentButtonFunction);
            #endregion

        }


        #region functions of OperationsUc delegateCommand
        private void MenuButtonFunction()
        {
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            mainWindow.gr_content.Children.Clear();
            MenuUC menu = new MenuUC();
            menu.DataContext = new MenuBusiness();
            mainWindow.gr_content.Children.Add(menu);
        }
        private void deleteBook()
        {
            if (selectedRow != null)
            {
                myservice.DeleteBook(selectedRow.id);
                this.listOfObjects.Remove(selectedRow);
            }
            else
                MessageBox.Show("Please Select a Book ");
        }
        private void AddButtonFunction()
        {
            BookForm myForm = new BookForm();
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            mainWindow.gr_content.Children.Clear();
            mainWindow.gr_content.Children.Add(myForm);
            myForm.labelContent.Content = "Add Form";
            myForm.DataContext = new BookBusiness();

        }
        private void UpdateButtonFunction()
        {
            if (selectedRow != null) {
                MainWindow mainWindow = App.Current.MainWindow as MainWindow;
                BookForm myForm = new BookForm();
                mainWindow.gr_content.Children.Clear();
                mainWindow.gr_content.Children.Add(myForm);
                myForm.labelContent.Content = "Update Form";
                myForm.DataContext = this;
                this.book = selectedRow;
            }
            else MessageBox.Show("Please select a book");
        }
        #endregion

        #region functions of form DelegateCommand

        private void ManageStudentButtonFunction()
        {
            Comeback();
        }
        private void AddUpdateFunction()
        {
            if(selectedRow != null)
            {
                myservice.UpdateBook(book);
                MessageBox.Show("Book updated Succefully");
                Comeback();
            }
            else { 
            myservice.AddBook(book);
            MessageBox.Show("Book Added successfly");
            }
            
        }

        #endregion


        #region Usefull Methods
        public void Comeback()
        {
            MainWindow mainWindow = App.Current.MainWindow as MainWindow;
            mainWindow.gr_content.Children.Clear();
            OperationsUC operations = new OperationsUC();
            operations.OpsTitle.Content = "Book Management";
            mainWindow.gr_content.Children.Add(operations);
            operations.DataContext = new BookBusiness();
        }
        #endregion



    }
}
