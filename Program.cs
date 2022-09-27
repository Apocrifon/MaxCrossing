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
            //Console.WriteLine();    
            //var graph = new Graph(leftPart, rightPart);
            //graph.SetConnectionGraph(matrix.AdjacencyMatrix);
            //Graph.PringGraph(graph.ConnectionGraph);
            //Console.WriteLine();
            //graph.SetWeightGraph();  
            //graph.SetDirectionInfo();
            //Graph.PringGraph(graph.WeightedGraph);
            //graph.SetIncrementGraph(); // либо прошлое работает правильно а это нет
            //Console.WriteLine();
            //Graph.PringGraph(graph.IncrementGraph);
            var a = new Algorithm();
            var b = new int[,]
            { {-1,0,-1,-1 },
              {1,-1,0,-1 },
              {-1,1,-1,0 },
              {-1,-1,1,-1 },
            };
            a.MinWay(b,0);
            foreach (var x in a.Roads)
                foreach (var item in x)
                {
                    Console.WriteLine(item);
                }


        }
    }
}
