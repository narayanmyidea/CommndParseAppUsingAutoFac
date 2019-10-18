using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSturucture
{
    interface ISortAlgorithm
    {
        void Sort(ref int[] a);
    }

    
    [Description("This examples describes selection sort")]
    public class SelectionSort: ISortAlgorithm
    {
        public void Sort(ref int[] a)
        {
          for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        var te = a[i];
                        a[i] = a[j];
                        a[j] = te;

                    }
                }
            }
        }
  
    }
    [Description("This examples describes bubble sort")]
    public class BubbleSort: ISortAlgorithm
    {
        public void Sort(ref int[] a)
        {
            for(int i=0;i<a.Length;i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        var t = a[j];
                        a[j] = a[j + 1];
                        a[j+1] = t;
                    }
                }
            }

        }
    }

    [Description("Insertion Sort")]
    public class InsertionSort: ISortAlgorithm
    {
        public void Sort(ref int[] a)
        {
            for (int i = 0; i < a.Length-1; i++)
            {
               // var pl = 0;
                for (int j = i+1; j > 0; j--)
                {
                    if (a[j - 1] > a[j])
                    {
                        var pl = a[j];
                        a[j] = a[j - 1];
                        a[j-1] = pl;
                    }
                }
            }
        }
       
    }
}
