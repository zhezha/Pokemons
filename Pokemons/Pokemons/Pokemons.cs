using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons
{
    class Pokemons
    {
        // number of nodes in the graph
        public int numNodes;
        // graph nodes
        public Node[] nodes;
        // start nodes for searching
        public List<int> startNodes;
        // longest chain
        public List<int> maxChain;

        // constructor
        // generate directed graph from given words
        public Pokemons(string[] words)
        {
            numNodes = words.Length;
            generateGraph(words);

        }

        // method to generate directed graph
        public void generateGraph(string[] words)
        {
            nodes = new Node[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                nodes[i] = new Node(i, words[i]);

                for (int j = 0; j < words.Length; j++)
                {
                    if (j == i)
                        continue;

                    if (words[j][words[j].Length - 1] == words[i][0])
                        nodes[i].EdgesIn.Add(j);

                    if (words[j][0] == words[i][words[i].Length - 1])
                        nodes[i].EdgesOut.Add(j);
                }
            }
        }

        // search entry
        public void searchGraph()
        {
            // longest chain
            maxChain = new List<int>();
            startNodes = generateStartNodes();

            // each time search from a start node
            foreach (int start in startNodes)
            {
                Node startNode = nodes[start];
                DFS(startNode);
            }

            Console.WriteLine("Chain length = " + maxChain.Count);
            Console.WriteLine("The words chain is: ");
            foreach (int id in maxChain)
            {
                Console.WriteLine("\t" + nodes[id].word);
            }
        }

        // Depth First Search started from startNode
        public void DFS(Node startNode)
        {
            // record current chain of searching
            List<int> currentChain = new List<int>();
            // the stack record all possible nodes to search on
            Stack<Node> stack = new Stack<Node>();

            // push startNode into stack
            stack.Push(startNode);

            while (stack.Any())
            {
                Node node = stack.Peek();

                // if node is already in currentChain
                if (currentChain.Contains(node.id))
                {
                    // if node is the last element in currentChain
                    // remove node from both stack and currentChain
                    if (currentChain[currentChain.Count - 1] == node.id)
                    {
                        stack.Pop();
                        currentChain.Remove(node.id);
                    }
                    // if node is not the last elment in currentChain
                    // just remove node from stack
                    else
                    {
                        stack.Pop();
                    }
                }
                // if node is not in currentChain
                else
                {
                    // add node into currentChain
                    currentChain.Add(node.id);

                    // if node has outgoing edges
                    // add its outgoing nodes into stack
                    if (node.EdgesOut.Count > 0)
                    {
                        foreach (int i in node.EdgesOut)
                        {
                            stack.Push(nodes[i]);
                        }
                    }
                    // if node has no outgoing edges
                    // finish this path and update maxChain
                    else
                    {
                        updateMaxChain(currentChain);
                        stack.Pop();
                        currentChain.Remove(node.id);
                    }
                }           
            }
        }

        // update maxChain with currentChain
        public void updateMaxChain(List<int> currentChain)
        {
            if (currentChain.Count > maxChain.Count)
            {
                maxChain.Clear();
                maxChain.AddRange(currentChain);
            }
        }

        // start search from the nodes that only have outgoing edges
        public List<int> generateStartNodes()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < numNodes; i++)
            {
                if (nodes[i].EdgesIn.Count == 0)
                    list.Add(i);
            }

            return list;
        }
    }
}
