using System;

namespace GraphMop
{
    class Program
    {
        static void Main()
        {
            //Console.Write("Укажите кол-во вершин первой доли -> ");
            //var leftPart = int.Parse(Console.ReadLine());
            //Console.Write("Укажите кол-во вершин второй доли -> ");
            //var rightPart = int.Parse(Console.ReadLine());
            //var matrix = new Matrix(leftPart + rightPart);
            //Console.WriteLine("Укажите ребра соединяющие вершины каждой доли, чтобы выйди из редактирование введите \"-1\"");
            //matrix.SetMatrixEdges();
            //matrix.PrintAdjacencyMatrix();
            //var weightedGraph = new Graph(leftPart,rightPart);
            var graph = new Graph(4, 2);
            graph.SetWeightGraph(new int[6,6]);
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write(graph.WeightedGraph[i, j]); 
                }
                Console.WriteLine();
            }
        }
    }
}
