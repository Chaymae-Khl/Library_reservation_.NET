using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLibraryService.MyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentService.svc or StudentService.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentService
    {
        private LibraryMangEntities myservice = new LibraryMangEntities();

        public void AddStudent(Student student)
        {
            myservice.Students.Add(student);
            myservice.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student exectinStudent=GetStudent(id);
            myservice.Students.Remove(exectinStudent);
            myservice.SaveChanges();
        }


        public Student GetStudent(int id)
        {
            return myservice.Students.Find(id);
         }

        public List<Student> GetStudents()
        {
            return myservice.Students.ToList();
        }

        public void UpdateStudent(Student student)
        {
            Student exectingStudent = GetStudent(student.id);
            myservice.Entry(exectingStudent).CurrentValues.SetValues(student);
            myservice.SaveChanges();
        }
    }
}
