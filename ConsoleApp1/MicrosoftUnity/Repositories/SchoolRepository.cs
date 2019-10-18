using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftUnity
{

    public interface IRepository
    {

    }
    public class SchoolRepository: IRepository
    {
        private List<School> _schoolList = new List<School>();
        public void AddStudent(School school)
        {
            _schoolList.Add(school);
        }
        public IList<School> GetAll()
        {
            return _schoolList;
        }
    }
    public class StudentRepository: IRepository
    {
        private List<Student> _studentList = new List<Student>();
        public void AddStudent(Student student)
        {
            _studentList.Add(student);
        }
        public IList<Student> GetAll()
        {
            return _studentList;
        }
    }
}
