using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GraphMop
{
    class Graph
    {
        public readonly int  Left;
        public readonly int Right;
        public readonly int Size;
        public int[,] WeightedGraph;  // нагруженный граф
        public int[,] IncrementGraph; // граф приращения
        public int[,] Weight;
        public Graph(int left, int right)
        {
            Size = left+right+2;
            Left=left;
            Right=right;
            WeightedGraph = new int[Size, Size];
        }

        public void SetWeightGraph(int[,] matrix)
        {
            for (int i = 1; i < Left+1 ; i++)
            {
                WeightedGraph[0,i] = 1;
                WeightedGraph[i, 0] = 1;
            }
            for (int i = Size-2; i > Left ; i--)
            {
                WeightedGraph[Size-1, i] = 1;
                WeightedGraph[i, Size - 1] = 1;
            }
            for (int i = 0; i < Left+Right; i++)
            {
                for (int j = 0; j < Left + Right; j++)
                {
                    WeightedGraph[i+1,j+1]=matrix[i,j];
                }
            }
        }
    }

}
