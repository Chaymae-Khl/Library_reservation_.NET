using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLibraryService.MyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        private LibraryMangEntities myservice;

        public BookService()
        {
            myservice = new LibraryMangEntities();
            myservice.Configuration.LazyLoadingEnabled = false;
            myservice.Configuration.ProxyCreationEnabled = false;
        }

        public void AddBook(Book book)
        {
            myservice.Books.Add(book);
            myservice.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book exestingBook= GetBook(id);
            myservice.Books.Remove(exestingBook);
            myservice.SaveChanges();
         }

      
        public Book GetBook(int id)
        {
            return myservice.Books.Find(id);
        }

        public List<Book> GetBooks()
        {
            return myservice.Books.ToList();
        }

        public void UpdateBook(Book book)
        {
            Book exectingBook = GetBook(book.id);
           
                myservice.Entry(exectingBook).CurrentValues.SetValues(book);
                myservice.SaveChanges();
         
        }
    }
}
