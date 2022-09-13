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
            var graph = new Graph(leftPart, rightPart);
            graph.SetConnectionGraph(matrix.AdjacencyMatrix);
            graph.SetWeightGraph();
            graph.SetIncrementGraph();
            Graph.PringGraph(graph.IncrementGraph);

        }
    }
}
