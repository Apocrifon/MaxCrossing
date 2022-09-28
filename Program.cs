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
            Console.WriteLine();
            var graph = new Graph(leftPart, rightPart);
            graph.SetConnectionGraph(matrix.AdjacencyMatrix);
            graph.SetWeightGraph();
            graph.SetDirectionInfo();

            graph.SetIncrementGraph();// либо прошлое работает правильно а это нет
            matrix.PrintAdjacencyMatrix();
            //Graph.PringGraph(graph.ConnectionGraph);
            //Console.WriteLine();
            //Graph.PringGraph(graph.WeightedGraph);
            //Console.WriteLine();
            //Graph.PringGraph(graph.IncrementGraph);
            var alg = new Algorithm();
            do
            {
                alg.ClearLists();
                alg.MinWay(graph.IncrementGraph, 0);
                if (alg.Roads.Count == 0)
                    break;
                graph.ChangeWeightGraph(alg.ChooseBestWay());

                graph.SetIncrementGraph();
                //Graph.PringGraph(graph.WeightedGraph);
                //Graph.PringGraph(graph.IncrementGraph);
                //Console.WriteLine();
            }
            while (alg.Roads.Count > 0);
            graph.PringAnswer();           
        }
    }
}
