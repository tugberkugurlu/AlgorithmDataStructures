using System;
using System.Collections.Generic;

namespace GraphDfsBfs
{
    public static class GraphAlgorithms
    {
        public static IEnumerable<int> DfsVisit(this Node rootNode)
        {
            var visited = new HashSet<Node>(Node.ValueComparer);
            var traversed = new HashSet<int>();
            var stack = new Stack<Node>();

            DfsVisitImpl(rootNode, visited, traversed, stack);

            return traversed;
        }

        private static void DfsVisitImpl(Node node, HashSet<Node> visited, HashSet<int> traversed, Stack<Node> stack)
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