using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS
{
    class Program
    {
        LinkedList<int>[] tree;
        int vertices;

        public Program(int v)
        {
            vertices = v;
            tree = new LinkedList<int>[v];
            for(int i=0; i<tree.Length; i++)
            {
                tree[i] = new LinkedList<int>();
            }
        }

        // Add edge in the graph
        public void AddEdge(int parent, int child)
        {
            tree[parent].AddLast(child);
        }

        // Breadth First Search traversal using the starting node
        public void BreadthFirstSearch(int start)
        {
            // Use hash to track the visited node in the tree
            HashSet<int> itemCovered = new HashSet<int>();
            LinkedList<int> list = new LinkedList<int>();

            // Adding the node in the list
            list.AddLast(start);

            // It runs until the length of the list
            while(list.Count > 0)
            {
                start = list.First();
                Console.Write(start + " ");
                list.RemoveFirst();

                // Run through the tree nodes and add to hash and the list
                foreach(var i in tree[start])
                {
                    if (!itemCovered.Contains(i))
                    {
                        itemCovered.Add(i);
                        list.AddLast(i);
                    }
                }
            }
        }

        // Depth First Search traversal using the starting node
        public void DepthFirstSearch(int start)
        {
            // Boolean value if node covered
            bool[] itemCovered = new bool[vertices];
            // call the recursive function
            DFS_Recursive(start, itemCovered);
            
        }

        // Helper function that find the depth first search traversal recursively
        public void DFS_Recursive(int start, bool[] itemCovered)
        {
            // marked the node as visited
            itemCovered[start] = true;
            Console.Write(start + " ");

            // recursively go through all non visited node
            foreach(int i in tree[start])
            {
                if(!itemCovered[i])
                {
                    DFS_Recursive(i, itemCovered);
                }
            }
        }


        // Driver code
        static void Main(string[] args)
        {
            Program p = new Program(13);

            // Edges of the tree from maze
            p.AddEdge(0, 1);
            p.AddEdge(0, 2);              
            p.AddEdge(1, 3); 
            p.AddEdge(1, 4); 
            p.AddEdge(4, 5); 
            p.AddEdge(4, 6); 
            p.AddEdge(5, 7);  
            p.AddEdge(5, 8);  
            p.AddEdge(8, 9);  
            p.AddEdge(8, 10);  
            p.AddEdge(10, 11);  
            p.AddEdge(10, 12);  

            // Calling the BFS function traversal starting at 0 and print the output
            Console.WriteLine("Breadth First Search output: ");
            p.BreadthFirstSearch(0);
            
            // Calling the DFS function traversal starting at 0 and print the output
            Console.WriteLine("\n\nDepth First Search output: ");
            p.DepthFirstSearch(0);
        }
    }
}
