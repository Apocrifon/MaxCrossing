using System;

namespace GraphMop
{
    class Program
    {
        static void Main()
        {
            Console.Write("Укажите кол-во вершин первой доли -> ");
            var leftPart = int.Parse(Console.ReadLine());
            Console.Write("Укажите кол-во вершин второй доли -> ");
            var rightPart = int.Parse(Console.ReadLine());
            var matrix = new Matrix(leftPart + rightPart);
            Console.WriteLine("Укажите ребра соединяющие вершины каждой доли, чтобы выйди из редактирование введите \"-1\"");
            matrix.SetMatrixEdges();
            matrix.PrintAdjacencyMatrix();
            Console.WriteLine();
            var graph = new Graph(leftPart, rightPart);
            graph.SetConnectionGraph(matrix.AdjacencyMatrix);
            Graph.PringGraph(graph.ConnectionGraph);
            Console.WriteLine();
            graph.SetWeightGraph();
            graph.SetDirectionInfo();
            Graph.PringGraph(graph.WeightedGraph);
            graph.SetIncrementGraph(); // либо прошлое работает правильно а это нет
            Console.WriteLine();
            Graph.PringGraph(graph.IncrementGraph);
            var alg = new Algorithm();
            do
            {
                alg.Roads.Clear();
                alg.CelectedPeaks.Clear();
                alg.CelectedPeaks.Add(0);
                alg.MinWay(graph.IncrementGraph, 0);
                if (alg.Roads.Count == 0)
                    break;
                graph.ChangeWeightGraph(alg.ChooseBestWay());
                graph.SetIncrementGraph();
            }
            while (alg.Roads.Count > 0);
            for (int i = 1; i < leftPart+1; i++)
            {
                for (int j = leftPart + 1; j < graph.WeightedGraph.GetLength(0)-1; j++)
                {
                    if (graph.ConnectionGraph[i,j]==1 && graph.WeightedGraph[i,j]==Graph.Reach.o)
                        Console.WriteLine(i + " "+ j);
                }
            }                    
        }
    }
}
