using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftUnity.CommandHandlers
{
    public class CommandMetaInfo
    {
        public CommandTypes Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
    public interface ICommandHandler
    {
        CommandMetaInfo CommandMeta { get; set; }
        void Execute(string[] attributes);

        event EventHandler<string> LogStatus;
    }
    public class SchoolCommandHandler : ICommandHandler
    {
        private Lazy<IEnumerable<IAttributeCommand>> _attributeCommands;
        private IRepository _schoolRepository;
        public SchoolCommandHandler(Lazy<IEnumerable<IAttributeCommand>> attributeCommands, IEnumerable<IRepository> repositories)
        {
            _attributeCommands = attributeCommands;
            _schoolRepository = repositories.First(c=>c is SchoolRepository);

            CommandMeta = new CommandMetaInfo();
            CommandMeta.Type = CommandTypes.E;
            CommandMeta.Name = SupportedEntityCommands.School.ToString();
            CommandMeta.Description = "School Entity Command";
        }

        public CommandMetaInfo CommandMeta { get; set; }
        
        public void Execute(string[] attributes)
        {
            var cmds = _attributeCommands.Value.Where(c =>
            {
                var ret = false;
                foreach (var attribute in attributes)
                {
                    if (ret == false)
                        ret = c.DoesSupport(attribute, SupportedEntityCommands.School.ToString());
                }

                return ret;
            });
            foreach (var attributeCommand in cmds.OrderBy(c=>c.Priority))
            {
                attributeCommand.LogStatus += LogStatus;
                attributeCommand.SetRepository(_schoolRepository);
                attributeCommand.Execute();
            }
        }

        public event EventHandler<string> LogStatus;
    }
    public class StudentCommandHandler : ICommandHandler
    {
        private Lazy<IEnumerable<IAttributeCommand>> _attributeCommands;
        private IRepository _studentRepository;
        public StudentCommandHandler(Lazy<IEnumerable<IAttributeCommand>> attributeCommands, IEnumerable<IRepository> repositories)
        {
            _attributeCommands = attributeCommands;
            _studentRepository = repositories.First(c => c is StudentRepository);

            CommandMeta = new CommandMetaInfo();
            CommandMeta.Type = CommandTypes.E;
            CommandMeta.Name = SupportedEntityCommands.Student.ToString();
            CommandMeta.Description = "Student entity command";
        }

        public CommandMetaInfo CommandMeta { get; set; }
        
        public void Execute(string[] attributes)
        {
            var cmds = _attributeCommands.Value.Where(c =>
            {
                var ret = false;
                foreach (var attribute in attributes)
                {
                    if(ret==false)
                    ret= c.DoesSupport(attribute, SupportedEntityCommands.Student.ToString());
                }

                return ret;
            });
            foreach (var attributeCommand in cmds.OrderBy(c => c.Priority))
            {
                attributeCommand.LogStatus += LogStatus;
                attributeCommand.SetRepository(_studentRepository);
                attributeCommand.Execute();
            }
        }

        public event EventHandler<string> LogStatus;
    }
}
