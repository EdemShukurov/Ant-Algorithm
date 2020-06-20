using System;

namespace Ant_Algorithm.Helper
{
    public struct Vertexes : IEquatable<Vertexes>
    {
        public uint VertexFrom { get; }

        public uint VertexTo { get; }

        public Vertexes(uint from, uint to)
        {
            if (from == to)
                throw new ArgumentException($"Vertexes ({from.ToString()} and {to.ToString()}) must not be the same");

            VertexFrom = from;
            VertexTo = to;
        }

        public bool IsAllowedVertex(uint from)
        {
            return from == VertexFrom || from == VertexTo;
        }

        public uint GetNextVertex(uint currentVertex)
        {
            if (currentVertex == VertexFrom)
                return VertexTo;

            if (currentVertex == VertexTo)
                return VertexFrom;

            return 0;
        }

        public override bool Equals(object b)
        {
            return Equals((Vertexes)b);
        }

        public bool Equals(Vertexes other)
        {
            return (VertexFrom == other.VertexFrom && VertexTo == other.VertexTo) ||
                   (VertexFrom == other.VertexTo && VertexTo == other.VertexFrom);
        }

        public override int GetHashCode()
        {
            int hashCode = 327279461;
            hashCode = hashCode * -1521134295 + VertexFrom.GetHashCode();
            hashCode = hashCode * -1521134295 + VertexTo.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(Vertexes a, Vertexes b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vertexes a, Vertexes b)
        {
            return !(a == b);
        }
    }
}
