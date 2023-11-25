using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLibraryService.MyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        List<Student> GetStudents();

        [OperationContract]
        void AddStudent(Student student);

        [OperationContract]
        void DeleteStudent(int id);

        [OperationContract]
        Student GetStudent(int id);

        [OperationContract]
        void UpdateStudent(Student student);


    }
}
