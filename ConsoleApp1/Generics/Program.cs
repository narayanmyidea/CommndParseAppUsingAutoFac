using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
//using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Generics
{
    public static class MyExtension
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            Console.WriteLine("Where Condition is called");
            foreach (var v in source)
            {
                if (condition(v))
                    yield return v;
            }
        }
        public static IEnumerable<R> Select<T,R>(this IEnumerable<T> source, Func<T, R> transform)
        {
            Console.WriteLine("Select clause is called");
            foreach (var v in source)
            {
                yield return transform(v);
            }
        }

    }
    public static class Program
    {
        private static Random ra = new Random();
        static Random random
        {
            get { return ra;}
        }
        static void  Main(string[] args)
        {
            Action ac1 = () => { Console.WriteLine("MEthod 1"); };
            Action ac2 = () => { throw new Exception("SDFSDFsdf"); };
            Action ac3 = () => { Console.WriteLine("MEthod 3"); };

            Action all = ac1;
            all += ac2;
            all += ac3;
            foreach (Action a in all.GetInvocationList())
            {
                try
                {
                    a();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                
            }
            Console.Read();

            //List<Employee> m=new List<Employee>();
            //m.MyExtension();

            //IMYDBContext context=new IMYDBContext();
            //IQueryable<ControlLoop> loops = context.ControlLoops.Where(k => k.Id > 0);
            //context.Database.Log = (m) => { Console.WriteLine(m); };
            //foreach (ControlLoop loop in loops)
            //{

            //}

            ////string firstName = "Bob";
            ////string lastName = "Smith";
            ////// Initialize with allocated length (MaxCapacity) equal to initial value length.
            ////StringBuilder builder = new StringBuilder(firstName.Length, firstName.Length);

            ////// Append initial value.
            ////builder.Append(firstName);
            ////// Attempt to insert additional value to builder already at MaxCapacity character count.
            ////builder.Insert(3,"DDDD",1);
            ////builder.Insert(firstName.Length - 1, lastName, 1);

            //Stopwatch stp=new Stopwatch();
            //stp.Start();


            ////var project1Macros = Macro.ReadCaste();
            ////var project1ControlLoops = ControlLoop.ReadCaste() ;


            ////read from second project
            //ConnectionManager.connectionStr =
            //    "Data Source=localhost\\cpo;Initial Catalog=XLB4000_PROJECT_R2003;Integrated Security=SSPI;";

            //Console.WriteLine(GC.GetTotalMemory(false));
            //var project2Macros = Macro.ReadCaste();
            //var project3ControlLoops = ControlLoop.ReadCaste() ;

            //Console.WriteLine(GC.GetTotalMemory(true));
            //stp.Stop();
            //Console.WriteLine("Elapsed Time"+stp.Elapsed.TotalSeconds);

            //GC.Collect();
            ////project1Macros = new List<Macro>();
            ////project1ControlLoops = new List<ControlLoop>();
            ////project2Macros = new List<Macro>();
            ////project3ControlLoops = new List<ControlLoop>();
            Console.Read();
        }

        static void kk()
        {
            Macro project1Macros = new Macro();
            project1Macros = null;
        }
    }

    class ConnectionManager
    {
        public static   string connectionStr= "Data Source=localhost\\cpo;Initial Catalog=XLB4000_PROJECT_R2002;Integrated Security=SSPI;";
       
    }

    public class IMYDBContext:DbContext
    {
        public IMYDBContext():base("Data Source=localhost\\cpo;Initial Catalog=XLB4000_PROJECT_R2002;Integrated Security=SSPI;")
        {
            
        }
        public DbSet<ControlLoop> ControlLoops { get; set; }
    }
    public class Macro
    {
        public static IList<Macro> Read()
        {
            IList<Macro> list = new List<Macro>();
            using (SqlConnection conn = new SqlConnection(ConnectionManager.connectionStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand("select * from XLBMacro",conn))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            Macro m = new Macro();
                            m.Id = reader.GetInt32(0);
                            m.Name = reader.GetString(1);
                            m.XML = reader.GetString(2);
                            m.Version = reader.GetString(3);
                            m.Type = reader.GetInt32(4);
                            list.Add(m);
                        }
                       
                    }
                }
            }
            

            return list;
        }
        public static IList<Macro> ReadCaste()
        {
            IList<Macro> list = new List<Macro>();
            using (SqlConnection conn = new SqlConnection(ConnectionManager.connectionStr))
            {
                conn.Open();

                using (IDbCommand cmd= new SqlCommand("select * from XLBMacro", conn))
                {

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Macro m = new Macro();
                            //m.Id = reader.GetInt32(0);
                            //m.Name =reader.GetString(1);
                            //m.XML = reader.GetString(2);
                            //m.Version = reader.GetString(3);
                            //m.Type = reader.GetInt32(4);

                            m.Id = (int)reader[0];
                            m.Name =(string) reader[1];
                            m.XML = (string)reader[2];
                            m.Version =(string) reader[3];
                            m.Type = (int)reader[4];
                            list.Add(m);
                        }

                    }
                }
            }


            return list;
        }

         public int Id { get; set; }
          public string Name { get; set; }
          public string XML { get; set; }

          public string Version { get; set; }
          public int Type { get; set; }
//          ~Macro()

//    {
//Console.WriteLine("DEsctructor is called");
//    }
         
    }
    [Table("XLBControlLoop")]
    public class ControlLoop
    {
        public static IList<ControlLoop> Read()
        {
            IList<ControlLoop> list = new List<ControlLoop>();
            using (SqlConnection conn = new SqlConnection(ConnectionManager.connectionStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand("select * from XLBControlLoop", conn))
                {

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            ControlLoop m = new ControlLoop();
                            m.Id = reader.GetInt32(0);
                            m.Name = reader.GetString(1);
                            m.plantId = reader.GetInt32(2);
                            m.XML = reader.GetString(3);
                             list.Add(m);
                        }

                    }
                }
            }


            return list;
        }
        public static IList<ControlLoop> ReadCaste()
        {
            IList<ControlLoop> list = new List<ControlLoop>();
            using (SqlConnection conn = new SqlConnection(ConnectionManager.connectionStr))
            {
                conn.Open();
                using (IDbCommand cmd = new SqlCommand("select * from XLBControlLoop", conn))
                {

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ControlLoop m = new ControlLoop();
                            //m.Id = reader.GetInt32(0);
                            //m.Name = reader.GetString(1);
                            //m.plantId = reader.GetInt32(2);
                            //m.XML = reader.GetString(3);

                            m.Id = (int)reader[0];
                            m.Name = (string)reader[1];
                            m.plantId = (int)reader[2];
                            m.XML = (string)reader[3];
                            list.Add(m);
                        }

                    }
                }
            }


            return list;
        }
        [Column("ControlLoopID")]
        public int Id { get; set; }
        [Column("ControlLoopName")]
        public string Name { get; set; }
        [Column("ControlLoopXML")]
        public string XML { get; set; }

        [Column("PlantID")]
        public int plantId { get; set; }

        
        [Column("ControlLoopGuid")]
        public Guid LoopGuid { get; set; }
    }
}
