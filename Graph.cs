using System;
using System.Collections.Generic;

namespace PROJET
{
    public class Graph
    {
        private List<Node> nodes = new List<Node>();
        private int nbrNodes = 0;

        public Boolean checkForAvailability(){
            return this.nbrNodes > 1;
        }
        
        public void CreateNode(Node node){
            this.nodes.Add(node);
            this.nbrNodes++;  
        }

        public void GetGraph()
        {
            Console.WriteLine("GRAPHE" + "\n");
            foreach (Node node in nodes)
            {
                if (node is ConcentrationNode)
                {
                    foreach(Lines ligneDe in node.GetReception()){
                        Console.WriteLine(ligneDe.GetFrom().GetNodeId() + " -----> " + node.GetNodeId());
                    }
                    Console.WriteLine(new string ('-', 50));
                    foreach(Lines ligneVers in node.GetDistribution()){
                        Console.WriteLine(node.GetNodeId() + " -----> " + ligneVers.GetTo().GetNodeId());
                    }
                    Console.WriteLine(new string ('-', 50));
                }
                if (node is DistributionNode)
                {
                    foreach(Lines ligneVers in node.GetDistribution()){
                        Console.WriteLine(node.GetNodeId()  + " -----> "  + ligneVers.GetTo().GetNodeId());
                    }
                }  
            }                
        }
        public List<Node> getList()
        {
            return nodes;
        }
    }
}