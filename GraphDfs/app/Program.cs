using System;
using System.Collections.Generic;

namespace app
{
    public static class Program
    {
        // https://www.khanacademy.org/computing/computer-science/algorithms/graph-representation/a/representing-graphs
        // http://www.geeksforgeeks.org/graph-and-its-representations/

        static void Main(string[] args)
        {
            var undirectedGraph = new [,] 
            {            /* 0  1  2  3  4 */

                /* 0 */   { 0, 1, 0, 0, 1 },
                /* 1 */   { 1, 0, 1, 1, 1 },
                /* 2 */   { 0, 1, 0, 1, 0 },
                /* 3 */   { 0, 1, 1, 0, 1 },
                /* 4 */   { 1, 1, 0, 1, 0 }

                /*  
                    0---1
                    |  /|\      
                    | / | 2
                    |/  |/ 
                    4---3
                */
            };

            System.Console.WriteLine(HasPathDfs(undirectedGraph, 4, 3));
            System.Console.WriteLine(string.Join(", ", TopologySortDfs(undirectedGraph, 4)));
        }

        public static int[] TopologySortDfs(int[,] undirectedGraph, int root) 
        {
            var rootNode = undirectedGraph.GetNode(root);
            var visitJournal = new HashSet<int>();
            var sortedList = new List<int>();
            TopologySortDfs(rootNode, root, undirectedGraph, visitJournal, sortedList);

            return sortedList.ToArray();
        }

        public static void TopologySortDfs(int[] rootNode, int root, int[,] undirectedGraph, HashSet<int> visitJournal, List<int> sortedList) 
        {
            if(visitJournal.Contains(root)) 
            {
                return;
            }

            visitJournal.Add(root);

            for (int i = 0; i < rootNode.Length; i++)
            {
                if(rootNode[i] != 0)
                {
                    var childNode = undirectedGraph.GetNode(i);
                    TopologySortDfs(childNode, i, undirectedGraph, visitJournal, sortedList);
                }
            }

            sortedList.Add(root);  
        }

        public static bool HasPathDfs(int[,] undirectedGraph, int source, int destination) 
        {
            var sourceNode = undirectedGraph.GetNode(source);
            var destinationNode = undirectedGraph.GetNode(destination);
            var visitJournal = new HashSet<int>();

            return HasPathDfs(source, 
                sourceNode, 
                destination, 
                destinationNode, 
                undirectedGraph, 
                visitJournal);
        }

        public static bool HasPathDfs(int source, int[] sourceNode, int destination, int[] destinationNode, int[,] undirectedGraph, HashSet<int> visitJournal) 
        {
            if(visitJournal.Contains(source)) 
            {
                return false;
            }

            visitJournal.Add(source);
            if(sourceNode[destination] == 1) 
            {
                return true;
            }

            for (int i = 0; i < sourceNode.Length; i++)
            {
                if(sourceNode[i] != 0) 
                {
                    var childNode = undirectedGraph.GetNode(i);

                    return HasPathDfs(i, childNode, destination, 
                        destinationNode, undirectedGraph, visitJournal);
                }
            }

            return false;
        }

        public static int[] GetNode(this int[,] undirectedGraph, int node) 
        {
            var nodeArray = new int[undirectedGraph.GetLength(0)];
            for (int i = 0; i < undirectedGraph.GetLength(0); i++)
            {
                nodeArray[i] = undirectedGraph[node, i];
            }

            return nodeArray;
        }
    }
}
