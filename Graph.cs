using System;
using System.Collections.Generic;

namespace PROJET
{
    public class Graph
    {
        private List<Node> nodes = new List<Node>();
        private int nbrNodes = 0;

        public Boolean checkForAvailability()
        {
            return this.nbrNodes > 1;
        }

        public void CreateNode(Node node)
        {
            this.nodes.Add(node);
            this.nbrNodes++;   
        }

        public int getNumberOfNodes()
        {
            return this.nbrNodes;
        }

        public void GetGraph()
        {
            foreach (Node node in nodes)
            {
                if(node.GetDistribution().Capacity > 0)
                {
                    Console.WriteLine("\n Lignes de distribution du node " + node.GetNodeId());
                    foreach (Lines distributions in node.GetDistribution())
                    {
                        Console.Write("Ligne " + distributions.GetId() + " : " + distributions.GetIdOfFromNode() + " -> " + distributions.GetIdOfToNode() + "\n");
                    }
                }  
            }                
        }
    }
}