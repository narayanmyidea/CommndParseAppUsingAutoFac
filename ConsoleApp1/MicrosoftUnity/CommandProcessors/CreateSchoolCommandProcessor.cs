using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicrosoftUnity
{
    
    public interface IAttributeCommand
    {
        string Name { get; }

        AttributeCommandTypes Type { get; }
        void Execute();

        event EventHandler<string> LogStatus;

        int Priority { get; }

        void SetRepository<T>(T item) where T: IRepository;

        bool DoesSupport(string attribute, string entityType);

    }
    public class CreateSchoolCommandProcessor : IAttributeCommand
    {
        public AttributeCommandTypes Type => AttributeCommandTypes.C;

        private SchoolRepository _schoolRepository = null;
        public string Name => "Create's School";

        public void Execute()
        {
            LogStatus(this, "Adding school......");
            School s=new School(){Id = 1,Name = "KDHS Tegur"};
            _schoolRepository.AddStudent(s);
            Thread.Sleep(2000);
            LogStatus(this, "School added successfully......");
        }

        public event EventHandler<string> LogStatus;
        public int Priority => 1;
        public void SetRepository<T>(T item) where T : IRepository
        {
            _schoolRepository =item as SchoolRepository;
        }
        public bool DoesSupport(string attribute,string entityType)
        {

            return string.Equals(attribute, "/" + Type, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(entityType,SupportedEntityCommands.School.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }
    }
    public class ListSchoolCommandProcessor : IAttributeCommand
    {
        private SchoolRepository _schoolRepository = null;
        public AttributeCommandTypes Type => AttributeCommandTypes.L;

        public string Name => "List's School";
        public void Execute()
        {
            LogStatus(this, "Displaying all schools......");
            Thread.Sleep(2000);
            LogStatus(this, "school Id=1, Name=KDHS Tegur......");
        }

        public event EventHandler<string> LogStatus;
        public int Priority => 2;
        public void SetRepository<T>(T item) where T : IRepository
        {
            _schoolRepository = item as SchoolRepository;
        }
        public bool DoesSupport(string attribute, string entityType)
        {

            return string.Equals(attribute, "/" + Type, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(entityType, SupportedEntityCommands.School.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }
    }
    public class CreateStudentCommandProcessor : IAttributeCommand
    {
        private StudentRepository _studentRepository = null;
        public AttributeCommandTypes Type => AttributeCommandTypes.C;

        public string Name => "Create Student";

        public void Execute()
        {
            LogStatus(this, "Adding Student......");
            Student s = new Student(){ Id = 1, Name = "Narayan" };
            _studentRepository.AddStudent(s);
            Thread.Sleep(2000);
            LogStatus(this, "Student added successfully......");
        }

        public event EventHandler<string> LogStatus;
        public int Priority => 1;
        public void SetRepository<T>(T item) where T : IRepository
        {
            _studentRepository = item as StudentRepository;
        }
        public bool DoesSupport(string attribute, string entityType)
        {

            return string.Equals(attribute, "/" + Type, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(entityType, SupportedEntityCommands.Student.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }
    }
    public class ListStudentCommandProcessor : IAttributeCommand
    {
        private SchoolRepository _schoolRepository = null;
        public AttributeCommandTypes Type => AttributeCommandTypes.L;
        public string Name => "List's Student";
        public void Execute()
        {
            LogStatus(this, "Displaying all students......");
            Thread.Sleep(2000);
            LogStatus(this, "student Id=1, Name=Sagar......");
        }

        public event EventHandler<string> LogStatus;
        public int Priority => 2;
        public void SetRepository<T>(T item) where T : IRepository
        {
            _schoolRepository = item as SchoolRepository;
        }
        public bool DoesSupport(string attribute, string entityType)
        {
            return string.Equals(attribute, "/" + Type, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(entityType, SupportedEntityCommands.Student.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
