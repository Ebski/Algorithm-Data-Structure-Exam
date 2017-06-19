using System;
using System.Collections.Generic;
using System.Data.Odbc;

namespace Graphs.Services.Model
{
    public class BinaryMinHeap<T>
    {
        private List<NestedNode> allNodes = new List<NestedNode>();
        private Dictionary<T, int> nodePosition = new Dictionary<T, int>();

        public class NestedNode
        {
            public int weight;
            public T key;
        }

        public bool containsData(T key)
        {
            return nodePosition.ContainsKey(key);
        }

        public void add(int weight, T key)
        {
            NestedNode node = new NestedNode();
            node.weight = weight;
            node.key = key;
            allNodes.Add(node);
            int size = allNodes.Count;
            int current = size - 1;
            int parentIndex = (current - 1) / 2;
            nodePosition[node.key] = current;

            while (parentIndex >= 0)
            {
                NestedNode parentNode = allNodes[parentIndex];
                NestedNode currentNode = allNodes[current];
                if (parentNode.weight > currentNode.weight)
                {
                    swap(parentNode, currentNode);
                    updatePositionOnMap(parentNode.key, currentNode.key, parentIndex, current);
                    current = parentIndex;
                    parentIndex = (parentIndex - 1) / 2;
                }
                else
                {
                    break;
                }
            }
        }

        public T min()
        {
            return allNodes[0].key;
        }

        public bool isEmpty()
        {
            return allNodes.Count == 0;
        }

        public void decrease(T data, int newWeight)
        {
            int position = nodePosition[data];
            allNodes[position].weight = newWeight;
            int parent = (position - 1) / 2;
            while (parent >= 0)
            {
                if (allNodes[parent].weight > allNodes[position].weight)
                {
                    swap(allNodes[parent], allNodes[position]);
                    updatePositionOnMap(allNodes[parent].key, allNodes[position].key, parent, position);
                    position = parent;
                    parent = (parent - 1) / 2;
                }
                else
                {
                    break;
                }
            }
        }

        public int getWeight(T key)
        {
            int position = nodePosition[key];
            if (position == null)
            {
                return 0;
            }
            else
            {
                return allNodes[position].weight;
            }
        }

        public NestedNode extractMinNode()
        {
            int size = allNodes.Count - 1;
            NestedNode minNode = new NestedNode();
            minNode.key = allNodes[0].key;
            minNode.weight = allNodes[0].weight;

            int lastNodeWeight = allNodes[size].weight;
            allNodes[0].weight = lastNodeWeight;
            allNodes[0].key = allNodes[size].key;
            nodePosition.Remove(minNode.key);
            nodePosition.Remove(allNodes[0].key);
            nodePosition.Add(allNodes[0].key, 0);
            allNodes.Remove(allNodes[size]);

            int currentIndex = 0;
            size--;
            while (true)
            {
                int left = 2 * currentIndex + 1;
                int right = 2 * currentIndex + 2;
                if (left > size)
                {
                    break;
                }
                if (right > size)
                {
                    right = left;
                }
                int smallerIndex = allNodes[left].weight <= allNodes[right].weight ? left : right;
                if (allNodes[currentIndex].weight > allNodes[smallerIndex].weight)
                {
                    swap(allNodes[currentIndex], allNodes[smallerIndex]);
                    updatePositionOnMap(allNodes[currentIndex].key, allNodes[smallerIndex].key, currentIndex,
                        smallerIndex);
                    currentIndex = smallerIndex;
                }
                else
                {
                    break;
                }
            }
            return minNode;
        }

        public T extractMin()
        {
            NestedNode node = extractMinNode();
            return node.key;
        }

        private void printPositionMap()
        {
            Console.WriteLine(nodePosition);
        }

        private void updatePositionOnMap(T key1, T key2, int pos1, int pos2)
        {
            nodePosition.Remove(key1);
            nodePosition.Remove(key2);
            nodePosition.Add(key1, pos1);
            nodePosition.Add(key2, pos2);
        }

        private void swap(NestedNode parentNode, NestedNode currentNode)
        {
            int weight = parentNode.weight;
            T data = parentNode.key;

            parentNode.key = currentNode.key;
            parentNode.weight = currentNode.weight;

            currentNode.key = data;
            currentNode.weight = weight; 
        }

        public void printHeap()
        {
            foreach (NestedNode node in allNodes)
            {
                Console.WriteLine(node.weight + " " + node.key);
            }
        }
    }
}
