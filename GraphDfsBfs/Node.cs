using System.Collections.Generic;

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
}