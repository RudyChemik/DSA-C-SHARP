using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Graph
{
    public class UndirectedUnweightedGraph<T>
    {
        private Dictionary<T, List<T>> adjList;

        public UndirectedUnweightedGraph()
        {
            adjList = new Dictionary<T, List<T>>();
        }

        public void AddVertex(T vertex)
        {
            if (!adjList.ContainsKey(vertex))
            {
                adjList[vertex] = new List<T>();
            }
        }

        public void AddEdge(T vertex1, T vertex2)
        {
            if (!adjList.ContainsKey(vertex1))
                AddVertex(vertex1);

            if (!adjList.ContainsKey(vertex2))
                AddVertex(vertex2);

            adjList[vertex1].Add(vertex2);
            adjList[vertex2].Add(vertex1);
        }

        public IEnumerable<T> GetNeighbors(T vertex)
        {
            if (adjList.ContainsKey(vertex))
            {
                return adjList[vertex];
            }

            return new List<T>();
        }


    }
}
