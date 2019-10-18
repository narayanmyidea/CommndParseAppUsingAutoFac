using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSturucture
{
    class Graphh
    {
        private int vertices;

        private List<int>[] adcencyList;

        public Graphh(int v)
        {
            vertices = v;
            adcencyList=new List<int>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                adcencyList[i] = new List<int>();
            }

            //10   ->20,30,40
            //20   ->10,50
            //40  ->10,30,50
            //30, ->10,40
            //50, ->20,40
        }

        public void AddAdjecy(int v, int[] nibours)
        {
           
            adcencyList[v] = nibours.ToList();

        }
    }

}
