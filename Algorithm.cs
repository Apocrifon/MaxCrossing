using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphMop
{
    class Algorithm
    {
        public List<int> CelectedPeaks;
        public List<List<int>> Roads;

        public Algorithm()
        {
            CelectedPeaks = new List<int>();
            Roads = new List<List<int>>();
        }

        public void MinWay(Graph.Weight[,] graph, int index)
        {
            for (int i = 1; i <graph.GetLength(0); i++)
            {
                if (index == graph.GetLength(0) - 1)
                {
                    Roads.Add(CelectedPeaks.GetRange(0,CelectedPeaks.Count).ToList());
                    break;
                }
                if (graph[index, i] == Graph.Weight.zero && i != 0)
                {
                    CelectedPeaks.Add(i);
                    MinWay(graph, i);
                }
                if (i == graph.GetLength(0) - 1 && CelectedPeaks.Count>0)
                    CelectedPeaks.RemoveAt(CelectedPeaks.Count - 1);
            }   
        } 

    }
}
