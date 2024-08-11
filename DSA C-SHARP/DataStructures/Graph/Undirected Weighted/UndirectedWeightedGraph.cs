﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_C_SHARP.DataStructures.Graph.Undirected_Weighted
{
    public class UndirectedWeightedGraph<T>
    {
        private Dictionary<T, List<(T, int)>> adjList;

        public UndirectedWeightedGraph() 
        {
            adjList = new Dictionary<T, List<(T, int)>>();
        }

        public void AddVertex(T vertex)
        {
            if (!adjList.ContainsKey(vertex))
            {
                adjList[vertex] = new List<(T, int)>();
            }
        }

        public void AddEdge(T vertex1, T vertex2, int weight)
        {
            if (!adjList.ContainsKey(vertex1))
                AddVertex(vertex1);


            if (!adjList.ContainsKey(vertex2))
                AddVertex(vertex2);

            adjList[vertex1].Add((vertex2, weight));
            adjList[vertex2].Add((vertex1, weight));
        }

        public IEnumerable<(T, int)> GetNeighbors(T vertex)
        {
            if (adjList.ContainsKey(vertex))
            {
                return adjList[vertex];
            }

            return new List<(T, int)>();
        }
    }
}