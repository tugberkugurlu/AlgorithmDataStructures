using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GraphDfsBfs
{
    public class Node
    {
        private sealed class ValueEqualityComparer : IEqualityComparer<Node>
        {
            public bool Equals(Node x, Node y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Value == y.Value;
            }

            public int GetHashCode(Node obj)
            {
                return obj.Value;
            }
        }

        public static IEqualityComparer<Node> ValueComparer { get; } = new ValueEqualityComparer();

        protected bool Equals(Node other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public Node(int value) => Value = value;

        public LinkedList<Node> Nodes { get; } = new LinkedList<Node>();
        public int Value { get; }

        public void AddEdge(Node node) => Nodes.AddLast(node);
    }

    class Program
    {
        private static HashSet<Node> visited = new HashSet<Node>(Node.ValueComparer);
        private static HashSet<int> traversed = new HashSet<int>();
        private static Stack<Node> stack = new Stack<Node>();

        static void Main(string[] args)
        {
            var node2 = GenerateTestSet1();
            DfsVisit(node2);

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

        private static void DfsVisit(Node node)
        {
            Console.WriteLine("visited {0}", node.Value);
            var isVisited = visited.Contains(node);
            if (isVisited)
            {
                if (node.Nodes.First == null)
                {
                    if (stack.Count == 0)
                    {
                        return;
                    }

                    var visitedNode = stack.Pop();
                    traversed.Add(visitedNode.Value);

                    DfsVisit(visitedNode.Nodes.First.Value);
                }
                else
                {
                    var firstNeighbour = node.Nodes.First.Value;

                    if (!firstNeighbour.Equals(node))
                    {
                        DfsVisit(firstNeighbour);
                    }
                    else
                    {
                        if (stack.Count == 0)
                        {
                            return;
                        }

                        var visitedNode = stack.Pop();
                        traversed.Add(visitedNode.Value);

                        DfsVisit(visitedNode.Nodes.First.Value);
                    }
                }
            }
            else
            {
                stack.Push(node);
                visited.Add(node);

                foreach (var nodeToCheck in node.Nodes)
                {
                    DfsVisit(nodeToCheck);
                }
            }
        }
    }
}
