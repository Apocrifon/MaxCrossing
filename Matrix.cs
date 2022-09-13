using System;

namespace GraphMop
{
    class Matrix
    {
        public readonly int Size;
        public readonly int[,] AdjacencyMatrix; // матрица смежности для двух долей

        public Matrix(int size)
        {
            Size = size;
            AdjacencyMatrix = new int[size, size];
        }

        public void SetMatrixEdges()
        {
            while (true)
            {
                Console.Write("Номер первой вершины -> ");
                int FirstPoint = int.Parse(Console.ReadLine());
                if (FirstPoint == -1)
                    break;
                Console.Write("Номер второй вершины -> ");
                int SecondPoint = int.Parse(Console.ReadLine());
                if (FirstPoint != SecondPoint)
                    AdjacencyMatrix[FirstPoint - 1, SecondPoint - 1] = 1;
            }
        }

        public void PrintAdjacencyMatrix()
        {
            Console.Write("  ");
            for (int i = 0; i < Size; i++)
                Console.Write(i+1 + " ");
            Console.WriteLine();
            Console.Write(" ");
            for (int i = 0; i < Size; i++)
                Console.Write("__");
            Console.Write("__");
            Console.WriteLine();
            for (int i = 0; i < Size; i++)
            {
                Console.Write(i+1 + "|");
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(AdjacencyMatrix[i, j] + " ");
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.Write(" ");
            for (int i = 0; i < Size; i++)
                Console.Write("--");
            Console.Write("--");
            Console.WriteLine();
        }
    }
}
