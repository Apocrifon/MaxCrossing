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
            Console.WriteLine();
            matrix.PrintAdjacencyMatrix();  //матрица смежности 2 долей
            Console.WriteLine();
            Graph.PringGraph(graph.ConnectionGraph); //матрица смежности графа
            Console.WriteLine();
            Graph.PringGraph(graph.WeightedGraph); //матрица нагруженного графа
            Console.WriteLine();
            Graph.PringGraph(graph.IncrementGraph); //матрица орграфа приращения
            Console.WriteLine();
            var alg = new Algorithm();
            do
            {
                alg.ClearLists();
                alg.MinWay(graph.IncrementGraph, 0);
                if (alg.Roads.Count == 0)
                    break;
                graph.ChangeWeightGraph(alg.ChooseBestWay());
                graph.SetIncrementGraph();
            }
            while (alg.Roads.Count > 0);
            graph.PringAnswer();           
        }
    }
}
