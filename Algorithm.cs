using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMop
{
    class Algorithm
    {
        int CurentIndex;
        public List<int> CelectedPeaks;
        public List<List<int>> Roads;

        public Algorithm()
        {
            CelectedPeaks = new List<int>();
            Roads = new List<List<int>>();
        }

        public void MinWay(int[,] graph, int index)
        {
            for (int i = 1; i <graph.Length; i++)
            {
                bool findway=false;
                if (index == graph.Length - 1)
                {
                    findway=true;
                    Roads.Add(CelectedPeaks);
                    break;
                }
                if (graph[index, i] == 0 && i != 0)
                {
                    CelectedPeaks.Add(i);
                    MinWay(graph, i);
                }
                if (i == graph.Length && findway == false)
                    CelectedPeaks.RemoveAt(CelectedPeaks.Count - 1);
            }
        } 

    }
}
