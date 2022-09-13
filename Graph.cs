using System;

namespace GraphMop
{
    class Graph
    {
        public readonly int  Left;
        public readonly int Right;
        public readonly int Size;
        public int[,] ConnectionGraph; //матрица связности
        public int[,] WeightedGraph; // нагруженный граф
        public int[,] IncrementGraph; // граф приращения
        public int[,] Weight;
        public Graph(int left, int right)
        {
            Size = left+right+2;
            Left=left;
            Right=right;
            ConnectionGraph = new int[Size, Size];
            WeightedGraph= new int[Size, Size];
            IncrementGraph = new int[Size, Size];
        }

        public static void PringGraph(int[,] graph)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void SetConnectionGraph(int[,] matrix)
        {
            for (int i = 1; i < Left+1 ; i++)
            {
                ConnectionGraph[0,i] = 1;
                ConnectionGraph[i, 0] = 1;
            }
            for (int i = Size-2; i > Left ; i--)
            {
                ConnectionGraph[Size-1, i] = 1;
                ConnectionGraph[i, Size - 1] = 1;
            }
            for (int i = 0; i < Left+Right; i++)
            {
                for (int j = 0; j < Left + Right; j++)
                {
                    ConnectionGraph[i+1,j+1]=matrix[i,j];
                }
            }
        }

        public void SetWeightGraph()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (ConnectionGraph[i,j]== 1)
                        WeightedGraph[i, j] = 0;
                    else
                        IncrementGraph[i, j] = -1;
                }
            }
        }

        public void SetIncrementGraph()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (WeightedGraph[i, j] != 1)
                        IncrementGraph[i, j] = 0;
                    else
                        IncrementGraph[i, j] = -1;
                }
            }
        }
    }

}
