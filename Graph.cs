using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;

namespace GraphMop
{
    class Graph
    {
        public readonly int  Left;
        public readonly int Right;
        public readonly int Size;
        public int[,] ConnectionGraph; //матрица связности
        public Reach[,] WeightedGraph; // нагруженный граф
        public Weight[,] IncrementGraph; // граф приращения
        public Direction[,] DirectionInfo;
        //public int[,] Weight;
        public enum Reach
        {
            z=0,
            o=1,
            x=-1
        };
        public enum Direction
        {
            back = 0,
            front =1,
        };

        public enum Weight
        {
            inf=1,
            zero=0,
            nw=-1
        };

        public Graph(int left, int right)
        {
            Size = left+right+2;
            Left=left;
            Right=right;
            ConnectionGraph = new int[Size, Size];
            DirectionInfo = new Direction[Size, Size];
            WeightedGraph = new Reach[Size, Size];
            IncrementGraph = new Weight[Size, Size];

        }

        public static void PringGraph(int[,] graph)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    Console.Write(graph[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void PringGraph(Direction[,] graph)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    Console.Write(graph[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void PringGraph(Reach[,] graph)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    Console.Write(graph[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void PringGraph(Weight[,] graph)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    Console.Write((int)graph[i, j] + "\t");
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
                for (int j = 0; j < Size; j++)
                    WeightedGraph[i, j] = Reach.x;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (ConnectionGraph[i, j] == 1)
                    {
                        WeightedGraph[i, j] = Reach.z;
                        WeightedGraph[j, i] = Reach.z;
                    }
                }
            }
        }

        public void SetDirectionInfo()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = i; j < Size; j++)
                {
                    if (ConnectionGraph[i, j] == 1)
                    {
                        DirectionInfo[i, j] = Direction.front;
                        DirectionInfo[j, i] = Direction.back;
                    }
                }
            }
        }

        public void SetIncrementGraph()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (WeightedGraph[i, j] == Reach.z && DirectionInfo[i, j] == Direction.front)
                        IncrementGraph[i, j] = Weight.zero;
                    else if (WeightedGraph[i, j] == Reach.o && DirectionInfo[i, j] == Direction.front)
                        IncrementGraph[i, j] = Weight.inf;
                    else if (WeightedGraph[i, j] == Reach.z && DirectionInfo[i, j] == Direction.back)
                        IncrementGraph[i, j] = Weight.inf;
                    else if (WeightedGraph[i, j] == Reach.o && DirectionInfo[i, j] == Direction.back)
                        IncrementGraph[i, j] = Weight.zero;
                    else
                        IncrementGraph[i, j] = Weight.nw;
                }
            }
        }

        public void PrintMaxCrosing()
        {
            for (int i = 1; i < Left; i++)
            {
                for (int j = Left; j < IncrementGraph.Length-1; j++)
                {
                    if (IncrementGraph[i,j]==Weight.inf)
                        Console.Write(i+1 + " " + j+1);
                }
                Console.WriteLine();
            }
        }

        public void ChangeWeightGraph(List <int> way)
        {
            for (int i = 0; i < way.Count-1; i++)
            {
                WeightedGraph[i, i + 1] = Reach.o;
                WeightedGraph[i + 1, i] = Reach.o;
            }
        }
    }




}
//public enum Reach
//{
//    z = 0,
//    o = 1,
//    x = -1
//};
//public enum Direction
//{
//    back = 0,
//    front = 1,
//};