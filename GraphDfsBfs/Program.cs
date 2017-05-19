using System;

namespace GraphDfsBfs
{
    class Program
    {
        static void Main(string[] args)
        {
            var node2 = GenerateTestSet1();
            var traversed = node2.DfsVisit();

            foreach (var val in traversed)
            {
                Console.WriteLine(val);
            }
        }

        private static Node GenerateTestSet1()
        {
            var node0 = new Node(0);
            var node2 = new Node(2);
            var node1 = new Node(1);
            var node3 = new Node(3);

            node0.AddEdge(node2);
            node0.AddEdge(node1);
            node1.AddEdge(node2);
            node2.AddEdge(node3);
            node3.AddEdge(node3);

            return node2;
        }
    }
}
