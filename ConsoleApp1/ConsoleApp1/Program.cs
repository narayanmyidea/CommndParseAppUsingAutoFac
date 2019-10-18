using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> lambdaFunc2 = (x) => x > 5;

            Console.WriteLine(lambdaFunc2(10));
            Console.Read();
        }
    }
    //public static class factory
    //{
    //    public static SChoolManagement CreateStudentInstance()
    //    {
    //        return new Student();
    //    }
    //    public static SChoolManagement CreateSchoolInstance()
    //    {
    //        return new School();
    //    }
    //}
    //public abstract class SChoolManagement
    //{


    //}
    //public class Student: SChoolManagement
    //{


    //}
    //public class School: SChoolManagement
    //{


    //}
}
