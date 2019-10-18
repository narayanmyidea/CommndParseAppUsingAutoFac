using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Autofac;
using MicrosoftUnity.CommandHandlers;

namespace MicrosoftUnity
{
    public sealed class MyApplication: IMyApplication
    {
        private readonly IEnumerable<ICommandHandler> _commands;
        public MyApplication(IEnumerable<ICommandHandler> commands)
        {
            _commands = commands;
        }
        public void Launch(string[] args)
        {
            //Debugger.Launch();
            
            string entity = args.FirstOrDefault(c => c.StartsWith("/" + CommandTypes.E + ":")).Split(':')[1];

            var attributes = args.Where(c => c.StartsWith("/C") || c.StartsWith("/L"));

            var cmd = _commands.FirstOrDefault(c => c.CommandMeta.Name.ToString() == entity);
            cmd.LogStatus += Log;
            cmd.Execute(attributes.ToArray());
        }
        public static void Log(object sender, string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IMyApplication
    {
        void Launch(string[] args);
    }

    class ClientApplication
    {
        private static IContainer Container { get; set; }
        // /E:Student /C
        static void Main(string[] args)
        {
           
            WireUp();
            using (var scope = Container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IMyApplication>();
                app.Launch(args);
            }
            Console.Read();
        }

        public static void WireUp()
        {
            var builder = new ContainerBuilder();

            // Register individual components
            builder.RegisterType<SchoolCommandHandler>().As<ICommandHandler>();
            builder.RegisterType<StudentCommandHandler>().As<ICommandHandler>();
            builder.RegisterType<CreateSchoolCommandProcessor>().As<IAttributeCommand>();
            builder.RegisterType<ListSchoolCommandProcessor>().As<IAttributeCommand>();
            builder.RegisterType<CreateStudentCommandProcessor>().As<IAttributeCommand>();
            builder.RegisterType<ListStudentCommandProcessor>().As<IAttributeCommand>();
            builder.RegisterType<MyApplication>().As<IMyApplication>();
            builder.RegisterType<SchoolRepository>().As<IRepository>();
            builder.RegisterType<StudentRepository>().As<IRepository>();
            Container = builder.Build();
        }
      
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class School
{
    public int Id { get; set; }
    public string Name { get; set; }

}