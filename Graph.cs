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
            foreach (Node node in nodes)
            {
                if(node.GetDistribution().Count > 0)
                {
                    Console.WriteLine(node.GetNodeId());
                    foreach (Lines distributions in node.GetDistribution())
                    {
                        Console.Write("Ligne " + distributions.GetId() + " : " + distributions.GetIdOfFromNode() + " -> " + distributions.GetIdOfToNode() + "\n");
                    }
                    Console.Write(new string ('-', 30) + "\n");
                }  
            }                
        }
        /* public void GetTableau()
        {
            int multipler = 10;
            string astérix = new string ('*', multipler);
            string bare = new string ('-', multipler);
            string space = new string (' ', 5);
            Console.WriteLine(astérix);
            Console.WriteLine("Producteurs"+ space + "Production" + "\n");
            foreach(Node node in nodes)
            {
                if (node is CentraleType){
                    Console.WriteLine(node.GetNodeId() + space + node.getProduction()+ space + node.getCO2());   
                }
            }
            Console.WriteLine("Consommateurs" + space + "Consommation" + "\n");
            foreach(ConsommateurType consommateur in nodes)
            {
                Console.WriteLine(consommateur.GetNodeId() + space + consommateur.getConsommation());
            }
        } */
    }
}