using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglePyramids
{
    class Program
    {
        //http://cbtsam.com/advance-csharp-tutorials/advance-csharp-tutorials-csharp-pyramid-program-example-for-type-2.php

        static void Main(string[] args)
        {
            int uLimit = 10;
            for (int loop = uLimit; loop >= 1; loop--)
            {
                for (int empty = 1; empty <= uLimit - loop; empty++)
                {
                    Console.Write(" ");
                }
                for (int empty = 1; empty <= loop; empty++)
                {
                    Console.Write("*");
                }
                for (int empty = 1; empty <= loop-1; empty++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int loop = 1; loop <= uLimit; loop++)
            {
                for (int empty = 1; empty <= uLimit - loop; empty++)
                {
                    Console.Write(" ");
                }
                for (int empty = 1; empty <= loop; empty++)
                {
                    Console.Write("*");
                }
                for (int empty = 1; empty <= loop - 1; empty++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.Read();
        }
        
        static void fibanocciPiramidTriangle()
        {
            for(int i=1;i<=5;i++)
            {
                for (int e = 1; e <= 5 - i; e++)
                {
                    Console.Write(" ");
                }
                //for (int lp = 1; lp <= i; lp++)
                //{
                    fabanocciArray(i,1);
                
                //}
                //for (int e = i-1;e >=1; e--)
                //{
                fabanocciArray(i-1,0);
                //}
                Console.WriteLine();
            }
        }
        static void fabanocciArray(double num,int asc=0)
        {
            double[] arr=new double[0];
            //1,2,3,5,8,13,21
            int n1 = 1, n2 = 1, i = 0;
            while (n2<=num)
            {
              
                var t = n1 + n2;
                n1 = n2;
                n2 = t;
                //Console.Write(n1);
                Array.Resize(ref arr, arr.Length+1);
                arr[i] = n1;
                i++;
            }

            if (asc == 1)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    Console.Write(arr[j]);
                }

            }
            if (asc == 0)
            {
                for (int j = arr.Length-1; j >=0; j--)
                {
                    Console.Write(arr[j]);
                }

            }
        }
        static void fabanocci(double num)
        {
            //1,2,3,5,8,13,21
            int n1 = 0,n2=1,i=1;
            while (i<= num)
            {
                var t = n1 + n2;
                n1 = n2;
                n2 = t;
                Console.Write(n1+" ");
                i++;
            }
        }
        static double factorial(double num)
        {
            //4!=4*3*2*1 =     24
            double numTotal = 0;
            if (num ==0)
            {
                return 1;
            }
            numTotal += num * factorial(num - 1);
            return numTotal;
        }
        static void printFibanacciTrianglePiramid()
        {
            int maxLimit = 15;
            for (int row = 1; row <= maxLimit; row++)
            {
                for (int sp = 1; sp <= maxLimit - row; sp++)
                {
                    Console.Write(" ");
                }
                for (int sp = 1; sp <= row; sp++)
                {
                    Console.Write("*");
                    Console.Write("");
                }
                for (int sp = 1; sp < row; sp++)
                {
                    Console.Write("*");
                    Console.Write("");
                }

                Console.WriteLine();
            }
        }
        static void printTrianglePiramid()
        {
            int maxLimit = 15;
            for (int row = 1; row <= maxLimit; row++)
            {
                for (int sp = 1; sp <= maxLimit - row; sp++)
                {
                    Console.Write(" ");
                }
                for (int sp = 1; sp <=row; sp++)
                {
                    Console.Write("*");
                    Console.Write("");
                }
                for (int sp = 1; sp < row; sp++)
                {
                    Console.Write("*");
                    Console.Write("");
                }

                Console.WriteLine();
            }
        }
        static void printOddNumbers()
        {
 /*------Csharp program to print a pyramid------
     9 7 5 3 1 
       7 5 3 1 
         5 3 1 
           3 1 
             1 
 --------------------------------------------*/

            for (int i = 5; i >= 1; i--)
            {
                for (int e = 1; e <= 5-i; e++)
                {
                    Console.Write("  ");
                }
                for (int e = (i*2)-1; e >= 1; e = e - 2)
                {
                    Console.Write(e+" ");
                }
                
                Console.WriteLine();
            }


        }
        static void printPyramidAlbhabets()
        {
            /* Csharp program to print a pyramid
            A
            B A
            C B A
            D C B A
            E D C B A */

            int upIndex = 70;
            for (int rIndex = 65; rIndex <= upIndex; rIndex++)
            {
                
                for (int pIndex = rIndex; pIndex >= 65; pIndex--)
                {
                    char chhh = (char)pIndex;
                    
                    Console.Write(chhh + " ");
                }
                Console.WriteLine();
            }

        }
        static void printPyramidNumbers()
        {
            //        1
            //      2 1
            //    3 2 1
            //  4 3 2 1
            //5 4 3 2 1
            int upIndex = 5;
            for (int rIndex = 1; rIndex <=upIndex; rIndex++)
            {
                for (int pIndex = 1; pIndex <= upIndex-rIndex; pIndex++)
                {
                    Console.Write("  ");
                }
                for (int pIndex = rIndex; pIndex>=1; pIndex--)
                {
                    Console.Write(pIndex+" ");
                }
                Console.WriteLine();
            }

        }

    }
}
