using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLibraryService.MyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookService" in both code and config file together.
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        List<Book> GetBooks();

        [OperationContract]
        void AddBook(Book book);

        [OperationContract]
        void DeleteBook(int id);

        [OperationContract]
        Book GetBook(int id);

        [OperationContract]
        void UpdateBook(Book book);
    }
}
