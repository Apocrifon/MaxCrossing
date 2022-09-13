using System;

namespace GraphMop
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Укажите кол-во вершин");
            var size = int.Parse(Console.ReadLine());
            var matrix = new Matrix(size);
            Console.WriteLine("Укажите ребра соединяющие вершины каждой доли, чтобы выйди из редактирование введите \"-1\"");
            while (true)
            {

                Console.WriteLine("Номер первой вершины");
                int FirstPoint = int.Parse(Console.ReadLine());
                if (FirstPoint == -1)
                    break;
                Console.WriteLine("Номер второй вершины");
                int SecondPoint = int.Parse(Console.ReadLine());
                if (FirstPoint != SecondPoint)
                    matrix.AdjacencyMatrix[FirstPoint - 1, SecondPoint - 1] = 1;
            }
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Console.Write(matrix.AdjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class Matrix
    {
        public readonly int Size;
        public readonly int[,] AdjacencyMatrix; // матрица смежности
        public int[,] WeightedGraph;  // нагруженный граф
        public int[,] IncrementGraph; // граф приращения
        public Matrix(int size)
        {
            Size = size;
            AdjacencyMatrix = new int[size, size]; 
            WeightedGraph = new int[size, size];
            IncrementGraph = new int[size, size];
        }   

        public void ChangeIncrementGraph(int[,] graph)
        {

        }

        public void ChangeWeightedGraph(int[,] matrix)
        {

        }

        public void
    }

}
